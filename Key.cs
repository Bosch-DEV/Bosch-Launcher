namespace Ignite {
    public static class Key {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int key);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, nuint dwExtraInfo);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, nuint dwExtraInfo);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct INPUT {
            public uint type;
            public InputUnion U;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
        private struct InputUnion {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public MOUSEINPUT mi;
            [System.Runtime.InteropServices.FieldOffset(0)]
            public KEYBDINPUT ki;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct KEYBDINPUT {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public nint dwExtraInfo;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct MOUSEINPUT {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public nint dwExtraInfo;
        }

        public const byte BACKSPACE = 0x08;
        public const byte TAB = 0x09;
        public const byte CLEAR = 0x0C;
        public const byte ENTER = 0x0D;
        public const byte SHIFT = 0x10;
        public const byte CTRL = 0x11;
        public const byte ALT = 0x12;
        public const byte PAUSE = 0x13;
        public const byte CAPITAL = 0x14;
        public const byte ESC = 0x1B;
        public const byte SPACE = 0x20;
        public const byte END = 0x23;
        public const byte HOME = 0x24;
        public const byte SELECT = 0x29;
        public const byte PRINT = 0x2A;
        public const byte EXECUTE = 0x2B;
        public const byte SNAPSHOT = 0x2C;
        public const byte INSERT = 0x2D;
        public const byte DELETE = 0x2E;
        public const byte HELP = 0x2F;

        public const byte ZERO = 0x30;
        public const byte ONE = 0x31;
        public const byte TWO = 0x32;
        public const byte THREE = 0x33;
        public const byte FOUR = 0x34;
        public const byte FIVE = 0x35;
        public const byte SIX = 0x36;
        public const byte SEVEN = 0x37;
        public const byte EIGHT = 0x38;
        public const byte NINE = 0x39;

        public const byte A = 0x41;
        public const byte B = 0x42;
        public const byte C = 0x43;
        public const byte D = 0x44;
        public const byte E = 0x45;
        public const byte F = 0x46;
        public const byte G = 0x47;
        public const byte H = 0x48;
        public const byte I = 0x49;
        public const byte J = 0x4A;
        public const byte K = 0x4B;
        public const byte L = 0x4C;
        public const byte M = 0x4D;
        public const byte N = 0x4E;
        public const byte O = 0x4F;
        public const byte P = 0x50;
        public const byte Q = 0x51;
        public const byte R = 0x52;
        public const byte S = 0x53;
        public const byte T = 0x54;
        public const byte U = 0x55;
        public const byte V = 0x56;
        public const byte W = 0x57;
        public const byte X = 0x58;
        public const byte Y = 0x59;
        public const byte Z = 0x5A;

        public const byte APPS = 0x5D;
        public const byte SLEEP = 0x5F;
        public const byte MULTIPLY = 0x6A;
        public const byte ADD = 0x6B;
        public const byte SEPARATOR = 0x6C;
        public const byte SUBTRACT = 0x6D;
        public const byte DECIMAL = 0x6E;
        public const byte DIVIDE = 0x6F;

        public const byte F1 = 0x70;
        public const byte F2 = 0x71;
        public const byte F3 = 0x72;
        public const byte F4 = 0x73;
        public const byte F5 = 0x74;
        public const byte F6 = 0x75;
        public const byte F7 = 0x76;
        public const byte F8 = 0x77;
        public const byte F9 = 0x78;
        public const byte F10 = 0x79;
        public const byte F11 = 0x7A;
        public const byte F12 = 0x7B;
        public const byte F13 = 0x7C;
        public const byte F14 = 0x7D;
        public const byte F15 = 0x7E;
        public const byte F16 = 0x7F;
        public const byte F17 = 0x80;
        public const byte F18 = 0x81;
        public const byte F19 = 0x82;
        public const byte F20 = 0x83;
        public const byte F21 = 0x84;
        public const byte F22 = 0x85;
        public const byte F23 = 0x86;
        public const byte F24 = 0x87;

        public const byte NUMLOCK = 0x90;
        public const byte SCROLL = 0x91;
        public const byte PROCESS = 0xE5;
        public const byte PACKET = 0xE7;
        public const byte ATTENTION = 0xF6;
        public const byte CRSEL = 0xF7;
        public const byte EXSEL = 0xF8;
        public const byte EREOF = 0xF9;
        public const byte PLAY = 0xFA;
        public const byte ZOOM = 0xFB;
        public const byte PA1 = 0xFD;

        public class Mouse {
            public const byte LEFT = 0x01;
            public const byte RIGHT = 0x02;
            public const byte CANCEL = 0x03;
            public const byte MIDDLE = 0x04;
            public const byte BACKWARD = 0x05;
            public const byte FORWARD = 0x06;
        }

        public class Page {
            public const byte UP = 0x21;
            public const byte DOWN = 0x22;
        }

        public class Arrow {
            public const byte LEFT = 0x25;
            public const byte UP = 0x26;
            public const byte RIGHT = 0x27;
            public const byte DOWN = 0x28;
        }

        public class Windows {
            public const byte LEFT = 0x5B;
            public const byte RIGHT = 0x5C;
        }

        public class Numpad {
            public const byte ZERO = 0x60;
            public const byte ONE = 0x61;
            public const byte TWO = 0x62;
            public const byte THREE = 0x63;
            public const byte FOUR = 0x64;
            public const byte FIVE = 0x65;
            public const byte SIX = 0x66;
            public const byte SEVEN = 0x67;
            public const byte EIGHT = 0x68;
            public const byte NINE = 0x69;
        }

        public class Shift {
            public const byte LEFT = 0xA0;
            public const byte RIGHT = 0xA1;
        }

        public class Ctrl {
            public const byte LEFT = 0xA2;
            public const byte RIGHT = 0xA3;
        }

        public class Alt {
            public const byte LEFT = 0xA4;
            public const byte RIGHT = 0xA5;
        }

        public class Browser {
            public const byte BACK = 0xA6;
            public const byte FORWARD = 0xA7;
            public const byte REFRESH = 0xA8;
            public const byte STOP = 0xA9;
            public const byte SEARCH = 0xAA;
            public const byte FAVORITES = 0xAB;
            public const byte HOME = 0xAC;
        }

        public class Volume {
            public const byte MUTE = 0xAD;
            public const byte DOWN = 0xAE;
            public const byte UP = 0xAF;
        }

        public class Media {
            public const byte NEXT = 0xB0;
            public const byte PREVIOUS = 0xB1;
            public const byte STOP = 0xB2;
            public const byte PLAY = 0xB3;
            public const byte PAUSE = 0xB3;
        }

        public class Launch {
            public const byte MAIL = 0xB4;
            public const byte MEDIA = 0xB5;
            public const byte APP1 = 0xB6;
            public const byte APP2 = 0xB7;
        }

        public class OEM {
            public const byte ONE = 0xBA;
            public const byte PLUS = 0xBB;
            public const byte COMMA = 0xBC;
            public const byte MINUS = 0xBD;
            public const byte PERIOD = 0xBE;
            public const byte TWO = 0xBF;
            public const byte THREE = 0xC0;
            public const byte FOUR = 0xDB;
            public const byte FIVE = 0xDC;
            public const byte SIX = 0xDD;
            public const byte SEVEN = 0xDE;
            public const byte EIGHT = 0xDF;
            public const byte NINE = 0xE2;
            public const byte CLEAR = 0xFE;
        }

        public class Hotkey {
            public int Delay { get; set; } = 8;

            private readonly Mode mode;
            private readonly int[] keys;
            private readonly System.Action action;
            private readonly System.Threading.CancellationTokenSource cancellationTokenSource = new();

            public Hotkey(System.Action action, params int[] keys) : this(action, Mode.Down, keys) { }

            public Hotkey(System.Action action, Mode mode, params int[] keys) {
                this.keys = keys;
                this.mode = mode;
                this.action = action;
                System.Threading.Tasks.Task.Run(() => this.Monitor(this.cancellationTokenSource.Token));
            }

            public void Unsubscribe() => this.cancellationTokenSource.Cancel();

            private async System.Threading.Tasks.Task Monitor(System.Threading.CancellationToken cancellationToken) {
                var previous = new bool[this.keys.Length];
                while (!cancellationToken.IsCancellationRequested) {
                    var current = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(this.keys, key => Pressed(key)));
                    if ((this.mode == Mode.Pressed && System.Linq.Enumerable.All(current, pressed => pressed)) ||
                        (this.mode == Mode.Down && System.Linq.Enumerable.All(current, pressed => pressed) && !System.Linq.Enumerable.SequenceEqual(previous, current)) ||
                        (this.mode == Mode.Up && !System.Linq.Enumerable.All(current, pressed => pressed) && System.Linq.Enumerable.Any(previous, pressed => pressed)))
                        this.action();
                    previous = current;
                    await System.Threading.Tasks.Task.Delay(this.Delay, cancellationToken);
                }
            }

            public enum Mode {
                Up,
                Down,
                Pressed
            }
        }

        public static bool Pressed(params int[] keys)
            => System.Linq.Enumerable.All(keys, key => (GetAsyncKeyState(key) & 0x8000) != 0);

        public static void Send(params byte[] keys) {
            foreach (var key in keys)
                switch (key) {
                    case Mouse.LEFT:
                        mouse_event(2, 0, 0, 0, 0);
                        System.Threading.Thread.Sleep(8);
                        mouse_event(4, 0, 0, 0, 0);
                        continue;
                    case Mouse.RIGHT:
                        mouse_event(8, 0, 0, 0, 0);
                        System.Threading.Thread.Sleep(8);
                        mouse_event(10, 0, 0, 0, 0);
                        continue;
                    default:
                        keybd_event(key, 0, 1, 0);
                        System.Threading.Thread.Sleep(8);
                        keybd_event(key, 0, 1 | 2, 0);
                        break;
                }
        }

        public static void Send(string value) {
            foreach (var key in value) {
                _ = SendInput(2, [
                    new () {
                        type = 1,
                        U = new InputUnion {
                            ki = new KEYBDINPUT {
                                wVk = 0,
                                wScan = key,
                                dwFlags = 4,
                                time = 0,
                                dwExtraInfo = 0
                            }
                        }
                    },
                    new () {
                        type = 1,
                        U = new InputUnion {
                            ki = new KEYBDINPUT {
                                wVk = 0,
                                wScan = key,
                                dwFlags = 4 | 2,
                                time = 0,
                                dwExtraInfo = 0
                            }
                        }
                    }
                ], System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));

                System.Threading.Thread.Sleep(2);
            }
        }
    }
}