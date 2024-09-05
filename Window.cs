using static Ignite.Screen;
using static Ignite.Console;

public class Window {

    private const int defaultDisplay = 0;

    private int display = 1;

    private Draw instance;

    private int smallHeight;
    private int smallWidth;

    private int maximisedHeight;
    private int maximisedWidth;

    private int startLocationX;
    private int startLocationY;

    private uint backgroundColor;

    private Rectangle mainContainer;

    private bool isMaxized;

    private ExitListener exitListener;

	public Window(int display = defaultDisplay, uint color = Color.Gray) {
        this.isMaxized = false;
        this.display = display;
        this.instance = new Draw(display);
        this.smallWidth = this.CalculateWidth();
        this.smallHeight = this.CalculateHeight();
        this.maximisedHeight = Monitors[display].Resolution.Height;
        this.maximisedWidth = Monitors[display].Resolution.Width;
        this.startLocationX = this.CalculateStartX();
        this.startLocationY = this.CalculateStartY();
        this.backgroundColor = color;
        this.mainContainer = this.CreateMainWindow();
        this.exitListener = new ExitListener(this);
    }

    //Terminates All Listeners and everything for said window
    public void Terminate() {
        exitListener.Terminate();
        _= this.DestructMainWindowNoReInit();
    }

    //Removes the old container, and creates a new one
    public Rectangle CreateMainWindow() {
        _ = this.DestructMainWindow();
        var mainR = this.isMaxized
            ? new Rectangle (0, 0, this.maximisedWidth, this.maximisedHeight, this.backgroundColor, fill: true)
            : new Rectangle (this.CalculateStartX(), this.CalculateStartY(), this.CalculateWidth(), this.CalculateHeight (), this.backgroundColor, fill: true);
        this.instance.Append(mainR);
        return mainR;
    }

    //Erases everything drawn by said instance
    public Window DestructMainWindow() {
        this.instance.Erase();
        this.instance = new Draw(display);
        return this;
    }

    public Window DestructMainWindowNoReInit() {
        this.instance.Erase();
        return this;
    }
    
    /*Window Size Calculators*/
    // Height / Y Calc
    public int CalculateHeight(int percentage) => Monitors[this.display].Resolution.Height / 100 * percentage;

    public int CalculateHeight() => this.CalculateHeight(70);

    // Width / X Calc
    public int CalculateWidth(int percentage) => Monitors[this.display].Resolution.Width / 100 * percentage;

    public int CalculateWidth() => this.CalculateWidth(70);
    
    /*Start Location Calculators*/
    // Y Calculator
    public int CalculateStartY(int percentage) => Monitors[this.display].Resolution.Height / 100 * percentage;

    public int CalculateStartY() => this.CalculateStartY(15);

    // X Calculator
    public int CalculateStartX(int percentage) => Monitors[this.display].Resolution.Width /100 * percentage;

    public int CalculateStartX() => this.CalculateStartX(15);

    public Window SetSmallHeight(int height) {
        this.smallHeight = height;
        _ = this.DestructMainWindow();
        _ = this.CreateMainWindow();
        return this;
    }

    public Window SetSmallWidth(int width) {
        this.smallWidth = width;
        _ = this.DestructMainWindow();
        _ = this.CreateMainWindow();
        return this;
    }

    public Window SetMaxizedWidth(int width) {
        this.maximisedWidth = width;
        _ = this.DestructMainWindow();
        _ = this.CreateMainWindow();
        return this;
    }

    public Window SetMaxizedHeight(int height) {
        this.maximisedHeight = height;
        _ = this.DestructMainWindow();
        _ = this.CreateMainWindow();
        return this;
    }

    public bool IsMaximized() => this.isMaxized;

    public Window SetMaximized(bool maximized) {
        this.isMaxized = maximized;
        _ = this.DestructMainWindow();
        _ = this.CreateMainWindow();
        return this;
    }

    public Window ToggledMaximized() {
        this.isMaxized = !this.isMaxized;
        _ = this.DestructMainWindow();
        _ = this.CreateMainWindow();
        return this;
    }

    public class ExitListener : KeyListener {

        private Window window;

        public ExitListener (Window window) : base (ConsoleKey.Escape) => this.window = window;

        public void Terminate() => this.TerminateRunner();

        public override void OnKeyPress () => this.window.Terminate ();
    }
}
