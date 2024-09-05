using System;
using static Ignite.Console;

public abstract class KeyListener {

	private ConsoleKey listeningKey;
    private bool running;

	public KeyListener(ConsoleKey consoleKey) {
        this.running = true;
		this.listeningKey = consoleKey;
        this.Init();
	}

	private void Init() {
        do {
            Printl(Console.ReadKey(true).Key.ToString());
            if (Console.ReadKey(true).Key == listeningKey) {
                this.OnKeyPress();
            }
        } while (running);
    }

    public void TerminateRunner () => this.running = false;

    public abstract void OnKeyPress();
}
