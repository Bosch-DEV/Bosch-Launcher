using static Ignite.Screen;
using static Ignite.Console;

public class Window {

    private const int defaultDisplay = 0;

    private int display = 1;

    private Draw instance;

    private int height;
    private int width;

    private int startLocationX;
    private int startLocationY;

    private uint backgroundColor;

    private Rectangle mainContainer;

	public Window(int display = defaultDisplay, uint color = Color.Gray) {
        this.display = display;
        this.instance = new Draw(display);
        this.height = this.CalculateHeight();
        this.width = this.CalculateWidth();
        this.startLocationX = this.CalculateStartX();
        this.startLocationY = this.CalculateStartY();
        this.backgroundColor = color;
        this.mainContainer = this.CreateMainWindow();
    }

    //Removes the old container, and creates a new one
    public Rectangle CreateMainWindow() {
        _ = this.DestructMainWindow();
        var mainR = new Rectangle(this.CalculateStartX(), this.CalculateStartY(), this.CalculateWidth(), this.CalculateHeight(), this.backgroundColor, fill: true);
        this.instance.Append(mainR);
        return mainR;
    }

    //Erases everything drawn by said instance
    public Window DestructMainWindow() {
        this.instance.Erase();
        this.instance = new Draw(display);
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
}
