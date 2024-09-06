using static Ignite.Screen;
using static Ignite.Console;
using static Ignite.Key;
using static Util.Color;
using Ignite;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Numerics;

public class Window {

    private const int defaultDisplay = 0;

    private int display = 1;

    private Draw instance;

    private int smallHeight, smallWidth;

    private int maximisedHeight, maximisedWidth;

    private int startLocationX, startLocationY;

    private uint backgroundColor;

    private Rectangle mainContainer;

    private bool isMaxized;

    private Circle exit, exitBorder, minimize, minimizeBorder, maximize, maximizeBorder;

    private int dotLocExitX, dotLocMiniX, dotLocMaxX, dotLocY, dotRad, dotRadB;

	public Window(int display = defaultDisplay, uint color = 0x333333) {
        this.isMaxized = false;
        this.display = display;
        this.instance = new Draw(display);
        this.smallWidth = this.CalculateWidth();
        this.smallHeight = this.CalculateHeight();
        this.maximisedHeight = Monitors[display].Resolution.Height;
        this.maximisedWidth = Monitors[display].Resolution.Width;
        this.startLocationX = this.CalculateMinimizedXStart();
        this.startLocationY = this.CalculateYStart();
        this.backgroundColor = color;
        this.mainContainer = this.CreateMainWindow();
        this.SubScribeMouse ();
        this.SubscribeFullScreen ();
        this.SubscribeExit ();
    }

    public void RenderOptionbar() {
        this.dotLocY = this.CalculateYDot (2.5);
        //var buttonRad = this.TranslatePercentMultiply (0.001);
        this.dotRad = this.TranslatePercentMultiply (this.isMaxized ? this.maximisedWidth : this.smallWidth, 1.5);
        if (this.dotRad <= 0) this.dotRad = 1;
        this.dotRadB = this.TranslatePercentMultiply (this.isMaxized ? this.maximisedWidth : this.smallWidth, 1.75);
        if (this.dotRadB <= 0) this.dotRadB = 1;

        this.dotLocExitX = this.CalculateXDot (1.5);
        this.exitBorder = new Circle (dotLocExitX, this.dotLocY, 1, EXIT_BORDER_RED, thickness: this.dotRadB, fill: true);
        this.exit = new Circle (dotLocExitX, this.dotLocY, 1, EXIT_RED, thickness: this.dotRad, fill: true);
        this.instance.Append (this.exitBorder);
        this.instance.Append (this.exit);

        this.dotLocMiniX = this.CalculateXDot(3.5);
        this.minimizeBorder = new Circle (dotLocMiniX, this.dotLocY, 1, MINIMIZE_BORDER_YELLOW, thickness: this.dotRadB, fill: true);
        this.minimize = new Circle (dotLocMiniX, this.dotLocY, 1, MINIMIZE_YELLOW, thickness: this.dotRad, fill: true);
        this.instance.Append (this.minimizeBorder);
        this.instance.Append (this.minimize);

        this.dotLocMaxX = this.CalculateXDot (5.5);
        this.maximizeBorder = new Circle (dotLocMaxX, this.dotLocY, 1, MAXIMIZE_BORDER_GREEN, thickness: this.dotRadB, fill: true);
        this.maximize = new Circle (dotLocMaxX, this.dotLocY, 1, MAXIMIZE_GREEN, thickness: this.dotRad, fill: true);
        this.instance.Append (this.maximizeBorder);
        this.instance.Append (this.maximize);
    }


    public void ReDraw() {
        _= this.DestructMainWindow ();
        _= this.CreateMainWindow ();
    }

    //Terminates All Listeners and everything for said window
    public void Terminate () => _= this.DestructMainWindowNoReInit ();

    //Removes the old container, and creates a new one
    public Rectangle CreateMainWindow() {
        this.mainContainer = new Rectangle (this.CalculateXStart (), this.CalculateYStart (), this.CalculateWidth (), this.CalculateHeight (), this.backgroundColor, fill: true);
        /*
        this.mainContainer = this.isMaxized
            ? new Rectangle (0, 0, this.maximisedWidth, this.maximisedHeight, this.backgroundColor, fill: true, thickness: 50)
            : new Rectangle (this.CalculateMinimizedXStart(), this.CalculateYStart(), this.CalculateWidth(), this.CalculateHeight (), this.backgroundColor, fill: true, thickness: 100);
        */
        this.instance.Append(this.mainContainer);
        this.RenderOptionbar();
        return this.mainContainer;
    }

    //Erases everything drawn by said instance
    public Window DestructMainWindow() {
        this.instance.Overwrite(mainContainer);
        this.instance.Overwrite (exitBorder);
        this.instance.Overwrite (exit);
        this.instance.Overwrite (maximizeBorder);
        this.instance.Overwrite (maximize);
        this.instance.Overwrite (minimizeBorder);
        this.instance.Overwrite (minimize);
        return this;
    }

    public Window DestructMainWindowNoReInit() {
        this.instance.Erase();
        return this;
    }
    
    /*Window Size Calculators*/
    // Height / Y Calc
    public int CalculateMinimizeHeight(int percentage) => Monitors[this.display].Resolution.Height / 100 * percentage;

    public int CalculateMinimizedHeight() => this.CalculateMinimizeHeight(70);

    public int CalculateHeight (int percentage) => isMaxized ? Monitors[this.display].Resolution.Height : Monitors[this.display].Resolution.Height / 100 * percentage;
    public int CalculateHeight () => this.CalculateHeight(70);


    // Width / X Calc
    public int CalculateMinimizedWidth(int percentage) => Monitors[this.display].Resolution.Width / 100 * percentage;

    public int CalculateMinimizedWidth() => this.CalculateMinimizedWidth(70);

    public int CalculateWidth (int percentage) => isMaxized ? maximisedWidth : Monitors[this.display].Resolution.Width / 100 * percentage;
    public int CalculateWidth () => this.CalculateWidth (70);

    /*Start Location Calculators*/
    // Y Calculator
    public int CalculateMinimizedYStart(int percentage) => Monitors[this.display].Resolution.Height / 100 * percentage;
    public int CalculateMinimizedYStart () => this.CalculateMinimizedYStart(15);

    public int CalculateYStart () => isMaxized ? 0 : this.CalculateMinimizedYStart ();
    public int CalculateYStart (int percentage) => isMaxized ? 0 : this.CalculateMinimizedYStart (percentage);


    public int CalculateMinimizedYEnd(int percentage) => this.CalculateMinimizedYStart (percentage) + this.CalculateMinimizedHeight();
    public int CalculateMinimizedYEnd () => this.CalculateMinimizedYEnd (15);

    public int CalculateYEnd () => isMaxized ? 0 : this.CalculateMinimizedYEnd ();
    public int CalculateYEnd (int percentage) => isMaxized ? 0 : this.CalculateMinimizedYEnd (percentage);

    public int CalculateMinimizedYDot (double percentage) => (int)(this.CalculateMinimizedYStart () + (this.CalculateMinimizedHeight () / 100 * percentage));

    public int CalculateYDot (double percentage) => isMaxized ? (int)(this.CalculateYStart() + (this.CalculateHeight () / 100 * percentage)) : (int)(this.CalculateMinimizedYStart () + (this.CalculateMinimizedHeight () / 100 * percentage));


    // X Calculator
    public int CalculateMinimizedXStart(int percentage) => Monitors[this.display].Resolution.Width /100 * percentage;
    public int CalculateMinimizedXStart() => this.CalculateMinimizedXStart(15);

    public int CalculateXStart(int percentage) => isMaxized ? 0 : this.CalculateMinimizedXStart (percentage);
    public int CalculateXStart() => this.CalculateXStart (15);

    public int CalculateMinimizedXEnd(int percentage) => this.CalculateMinimizedXStart(percentage) + this.CalculateMinimizedWidth ();
    public int CalculateMinimizedXEnd() => this.CalculateMinimizedXEnd(15);

    public int CalculateXEnd(int percentage) => isMaxized ? Monitors[display].Resolution.Width : this.CalculateMinimizedXEnd (percentage);
    public int CalculateXEnd() => this.CalculateXEnd (15);

    public int CalculateMinimizedXDot(double percentage) => (int) (this.CalculateMinimizedXEnd () - (this.CalculateMinimizedWidth () / 100 * percentage));
    public int CalculateXDot (double percentage) => isMaxized ? (int)(this.CalculateXEnd () - (this.CalculateWidth () / 100 * percentage)) : (int)(this.CalculateMinimizedXEnd () - (this.CalculateMinimizedWidth () / 100 * percentage));

    //Other Calculators
    public int TranslatePercentMultiply (double percentage) => (int)(this.CalculateMinimizedWidth () / 100 * percentage);

    public int TranslatePercentMultiply (double original, double percentage) => (int)(original / 100 * percentage);


    public Window SetMinimizedHeight(int height) {
        this.smallHeight = height;
        _ = this.DestructMainWindow();
        _ = this.CreateMainWindow();
        return this;
    }

    public Window SetMinimizedWidth(int width) {
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
        _ = this.SetMaximized (!this.IsMaximized ());
        return this;
    }

    public bool isInRad (int rad, int cX, int cY, int mX, int mY) => Math.Sqrt (Math.Pow (mX - cX, 2) + Math.Pow (mY - cY, 2)) <= rad;

    //Handler
    public Window HandleFullScreenToggle() {
        _= this.ToggledMaximized ();
        this.ReDraw ();
        return this;
    }

    public void HandleExit () {
        Runner.StopRunner ();
        this.instance.Erase ();
    }

    public void HandleMinimize() {
        this.instance.Clear ();
    }

    public void SubScribeMouse () => _ = new Hotkey (() => {
        var mX = Screen.Mouse.Position.Relative.X;
        var mY = Screen.Mouse.Position.Relative.Y;
        var mM = Screen.Mouse.Monitor;
        if (mM != this.display) return;

        if (!(mX >= this.CalculateXStart () && mX <= this.CalculateXStart () + this.CalculateWidth () && mY >= this.CalculateYStart () && mY <= this.CalculateYStart () + this.CalculateHeight ())) return;

        Printl (dotLocExitX + " | " + dotLocY);
        Printl (dotLocMiniX + " | " + dotLocY);
        Printl (dotLocMaxX + " | " + dotLocY);
        if (isInRad(dotRad, dotLocExitX, dotLocY, mX, mY)) {
            this.HandleExit ();
            Printl ("Handle Exit");
        }

        if (isInRad (dotRad, dotLocMaxX, dotLocY, mX, mY)) {
            this.HandleFullScreenToggle ();
        }
        
        if (isInRad (dotRad, dotLocMiniX, dotLocY, mX, mY)) {
            this.HandleMinimize ();
        }
    }, Key.Mouse.LEFT);

    public void SubscribeFullScreen () => _ = new Hotkey (() => {
        var mX = Screen.Mouse.Position.Relative.X;
        var mY = Screen.Mouse.Position.Relative.Y;
        var mM = Screen.Mouse.Monitor;
        if (mM != this.display) return;
        Printl ("F11 Pressed");
        _ = this.HandleFullScreenToggle ();
    }, Key.F11);

    public void SubscribeExit () => _ = new Hotkey (() => {
        Printl ("Exiting");
        this.HandleExit();
    }, ESC);
}
