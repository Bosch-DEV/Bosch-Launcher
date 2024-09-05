using static Ignite.Screen;
using static Ignite.Console;


var display = 1;
Window window = new Window(0);
/*
var instance = new Draw (display);
var heightCal = ((Monitors[display].Resolution.Height / 100) * 70);
var widthCal = ((Monitors[display].Resolution.Width / 100) * 70);
var startY = (Monitors[display].Resolution.Height / 100) * 15;
var startX = (Monitors[display].Resolution.Width /100) * 15;
var main = new Rectangle(startX, startY, widthCal, heightCal, color: Color.Yellow, fill: true);
instance.Append(main);
*/
/*
var length = 300;
var x = (Monitors[index].Resolution.Width >> 1) - (length + (length >> 1));
var y = (Monitors[index].Resolution.Height >> 1) - (length + (length >> 1));
var rectangles = new Rectangle[9];

for (var i = 0; i < length * 3; i += length) {
    for (var j = 0; j < length * 3; j += length) {
        rectangles[i / length] = new Rectangle (x + j, y + i, length, length, Color.Red, thickness: 3);
        instance.Append (rectangles[i / length]);
    }
}

instance.Append (new Text (x + Text.Width ($"Round 1/{rounds}") + length, y - 25, $"Round 1/{rounds}"));
*/

Console.ReadLine ();