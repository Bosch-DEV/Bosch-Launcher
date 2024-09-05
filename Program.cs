using static Ignite.Screen;
using static Ignite.Console;


var index = 0;
var rounds = 1;

#if !DEBUG
while (true) {
    try {
        index = Scan<int> ("An welchem Monitor soll das Spiel geöffnet werden (<foreground-#E26A44>bei keiner Eingabe wird der Primäre monitor verwendet</foreground>): ") - 1;

        if (index < 0 || index >= Monitors.Count)
            throw new Exception ();

        break;
    } catch {
        Printl ($"    <foreground-red>Die Eingabe war ungültig, bitte versichern Sie sich, dass die Eingabe zwischen 1 und {Monitors.Count + 1}!</foreground>");
    }
}
#endif

var instance = new Draw (index);
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

Console.ReadLine ();