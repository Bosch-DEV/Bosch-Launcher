namespace Ignite {
    public static class Screen {
        private static class Import {
            [System.Runtime.InteropServices.DllImport ("user32.dll", SetLastError = true)]
            internal static extern bool EnumDisplayMonitors (nint hdc, nint lprcClip, MonitorEnumProc lpfnEnum, nint dwData);

            [System.Runtime.InteropServices.DllImport ("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
            internal static extern bool GetMonitorInfo (nint hMonitor, ref MONITORINFO lpmi);

            [System.Runtime.InteropServices.DllImport ("user32.dll")]
            internal static extern bool GetCursorPos (out POINT lpPoint);

            [System.Runtime.InteropServices.DllImport ("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            internal static extern nint CreateWindowEx (int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, nint hWndParent, nint hMenu, nint hInstance, nint lpParam);

            [System.Runtime.InteropServices.DllImport ("user32.dll")]
            internal static extern bool SetLayeredWindowAttributes (nint hwnd, uint crKey, byte bAlpha, uint dwFlags);

            [System.Runtime.InteropServices.DllImport ("user32.dll")]
            internal static extern bool ShowWindow (nint hWnd, int nCmdShow);

            [System.Runtime.InteropServices.DllImport ("user32.dll", SetLastError = true)]
            internal static extern bool SetWindowPos (nint hWnd, nint hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

            [System.Runtime.InteropServices.DllImport ("user32.dll", SetLastError = true)]
            internal static extern bool DestroyWindow (nint hWnd);

            [System.Runtime.InteropServices.DllImport ("user32.dll", SetLastError = true)]
            internal static extern nint GetDC (nint hWnd);

            [System.Runtime.InteropServices.DllImport ("user32.dll", SetLastError = true)]
            internal static extern int ReleaseDC (nint hWnd, nint hDC);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern bool DeleteDC (nint hdc);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern nint CreatePen (int fnPenStyle, int nWidth, uint crColor);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern nint CreateSolidBrush (uint crColor);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern int GetObject (nint hObject, int nCount, out BITMAP lpObject);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern nint SelectObject (nint hdc, nint hgdiobj);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern bool DeleteObject (nint hObject);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern int SetGraphicsMode (nint hdc, int iMode);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern bool SetWorldTransform (nint hdc, [System.Runtime.InteropServices.In] ref XFORM lpXform);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern nint GetStockObject (int fnObject);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern bool MoveToEx (nint hdc, int X, int Y, nint lpPoint);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern int SetArcDirection (nint hdc, int dir);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern bool LineTo (nint hdc, int nXEnd, int nYEnd);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern bool Polyline (nint hdc, [System.Runtime.InteropServices.In] POINT[] lppt, int cPoints);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern bool Polygon (nint hdc, [System.Runtime.InteropServices.In] POINT[] lppt, int cPoints);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern bool Arc (nint hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nXStartArc, int nYStartArc, int nXEndArc, int nYEndArc);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern bool Pie (nint hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nXStartArc, int nYStartArc, int nXEndArc, int nYEndArc);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true)]
            internal static extern bool Ellipse (nint hdc, int left, int top, int right, int bottom);

            [System.Runtime.InteropServices.DllImport ("user32.dll", SetLastError = true)]
            internal static extern bool FillRect (nint hdc, RECT lprc, nint hbr);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            internal static extern bool TextOut (nint hdc, int nXStart, int nYStart, string lpString, int nCount);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern bool SetBkMode (nint hdc, int nBkMode);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern uint SetTextColor (nint hdc, uint crColor);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern uint SetBkColor (nint hdc, uint crColor);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            internal static extern nint CreateFont (int nHeight, int nWidth, int nEscapement, int nOrientation, int dwWeight, uint dwItalic, uint dwUnderline, uint dwStrikeOut, uint dwCharSet, uint dwOutPrecision, uint dwClipPrecision, uint dwQuality, uint dwFaceName, string lpszFace);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll")]
            internal static extern nint CreateCompatibleDC (nint hdc);

            [System.Runtime.InteropServices.DllImport ("gdi32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            internal static extern bool GetTextExtentPoint32 (nint hdc, string lpString, int c, out SIZE lpSize);

            [System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
            internal struct POINT {
                public int X;
                public int Y;
            }

            [System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
            internal struct SIZE {
                public int cx;
                public int cy;
            }

            [System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
            internal struct XFORM {
                public float eM11;
                public float eM12;
                public float eM21;
                public float eM22;
                public float eDx;
                public float eDy;
            }

            [System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
            internal struct BITMAP {
                public int bmType;
                public int bmWidth;
                public int bmHeight;
                public int bmWidthBytes;
                public ushort bmPlanes;
                public ushort bmBitsPixel;
                public nint bmBits;
            }

            [System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
            internal struct RECT {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            internal struct MONITORINFO {
                public int cbSize;
                public RECT rcMonitor;
                public RECT rcWork;
                public int dwFlags;
            }

            internal delegate bool MonitorEnumProc (nint hMonitor, nint hdcMonitor, ref Import.RECT lprcMonitor, nint dwData);
        }

        static Screen () {
            Monitors.Clear ();
            if (!Import.EnumDisplayMonitors (nint.Zero, nint.Zero, Enum, nint.Zero))
                throw new System.ComponentModel.Win32Exception (System.Runtime.InteropServices.Marshal.GetLastWin32Error ());

            var primary = System.Linq.Enumerable.FirstOrDefault (Monitors, monitor => monitor.Primary);
            Primary = ((primary.Resolution.Width, primary.Resolution.Height), (primary.Working.Width, primary.Working.Height));

        }

        public static readonly System.Collections.Generic.List<((int Width, int Height) Resolution, (int Width, int Height) Working, bool Primary)> Monitors = [];
        public static readonly ((int Width, int Height) Resolution, (int Width, int Height) Working) Primary;

        private static bool Enum (nint hMonitor, nint hdcMonitor, ref Import.RECT lprcMonitor, nint dwData) {
            var info = new Import.MONITORINFO ();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf (info);
            if (Import.GetMonitorInfo (hMonitor, ref info)) {
                Monitors.Add ((
                    (info.rcMonitor.right - info.rcMonitor.left, info.rcMonitor.bottom - info.rcMonitor.top),
                    (info.rcWork.right - info.rcWork.left, info.rcWork.bottom - info.rcWork.top),
                    (info.dwFlags & 1) != 0
                ));
            }

            return true;
        }

        public static void Identify () {
            for (var i = 0; i < Monitors.Count; i++)
                Draw.Temporarily (new Text (Monitors[i].Resolution.Width - Text.Width (i + 1, size: 128), -30, i + 1, size: 128), 1000, i);
        }

        public struct Line {
            private int Shadow_Length;
            private int Shadow_Thickness;

            public int X;
            public int Y;
            public int Length {
                readonly get => this.Shadow_Length;
                set {
                    if (value <= 0)
                        throw new System.ArgumentException ("A line cannot have a length that is less than or equal to zero.");

                    this.Shadow_Length = value;
                }
            }
            public uint Color;
            public int Thickness {
                readonly get => this.Shadow_Thickness;
                set {
                    if (value <= 0)
                        throw new System.ArgumentException ("A line cannot have a thickness that is less than or equal to zero");

                    this.Shadow_Thickness = value;
                }
            }
            public int Rotation;

            public Line (in int x, in int y, in int length, in uint color, in int thickness = 1, in int rotation = 0) {
                this.X = x;
                this.Y = y;
                this.Length = length;
                this.Color = color;
                this.Thickness = thickness;
                this.Rotation = rotation;
            }
        }
        public struct Arc {
            private int? Shadow_Radius;
            private int Shadow_Width;
            private int Shadow_Height;
            private int Shadow_Length;
            private int Shadow_Thickness;

            public int X;
            public int Y;
            public int? Radius {
                readonly get => this.Shadow_Radius;
                set {
                    if (value is <= 0 or null)
                        throw new System.ArgumentException ("An arc cannot have a radius that is less than or equal to zero.");

                    this.Shadow_Radius = value;
                    this.Shadow_Width = Shadow_Radius.Value;
                    this.Shadow_Height = Shadow_Radius.Value;
                }
            }
            public int Width {
                readonly get => this.Shadow_Width;
                set {
                    if (value is <= 0)
                        throw new System.ArgumentException ("An arc cannot have a width that is less than or equal to zero.");

                    this.Shadow_Width = value;
                    this.Shadow_Radius = this.Shadow_Width == this.Shadow_Height
                        ? this.Shadow_Width
                        : null;
                }
            }
            public int Height {
                readonly get => Shadow_Height;
                set {
                    if (value is <= 0)
                        throw new System.ArgumentException ("An arc cannot have a height that is less than or equal to zero.");

                    this.Shadow_Height = value;
                    this.Shadow_Radius = this.Shadow_Height == this.Shadow_Width
                        ? this.Shadow_Height
                        : null;
                }
            }
            public int Length {
                readonly get => this.Shadow_Length;
                set {
                    if (value <= 0)
                        throw new System.ArgumentException ("An arc cannot have a length that is less than or equal to zero.");

                    this.Shadow_Length = value;
                }
            }
            public uint Color;
            public int Thickness {
                readonly get => this.Shadow_Thickness;
                set {
                    if (value <= 0)
                        throw new System.ArgumentException ("An arc cannot have a thickness that is less than or equal to zero");

                    this.Shadow_Thickness = value;
                }
            }
            public int Rotation;
            public bool Fill;

            public Arc (in int x, in int y, in int radius, in int length, in uint color, in int thickness = 1, in int rotation = 0, in bool fill = false) {
                this.X = x;
                this.Y = y;
                this.Radius = radius;
                this.Width = radius;
                this.Height = radius;
                this.Length = length;
                this.Color = color;
                this.Thickness = thickness;
                this.Rotation = rotation;
                this.Fill = fill;
            }
            public Arc (in int x, in int y, in int width, in int height, in int length, in uint color, in int thickness = 1, in int rotation = 0, in bool fill = false) {
                this.X = x;
                this.Y = y;
                this.Width = width;
                this.Height = height;
                this.Length = length;
                this.Color = color;
                this.Thickness = thickness;
                this.Rotation = rotation;
                this.Fill = fill;
            }
        }
        public struct Circle {
            private int? Shadow_Radius;
            private int Shadow_Width;
            private int Shadow_Height;
            private int Shadow_Thickness;

            public int X;
            public int Y;
            public int? Radius {
                readonly get => this.Shadow_Radius;
                set {
                    if (value is <= 0 or null)
                        throw new System.ArgumentException ("A circle cannot have a radius that is less than or equal to zero.");

                    this.Shadow_Radius = value;
                    this.Shadow_Width = Shadow_Radius.Value;
                    this.Shadow_Height = Shadow_Radius.Value;
                }
            }
            public int Width {
                readonly get => this.Shadow_Width;
                set {
                    if (value is <= 0)
                        throw new System.ArgumentException ("A circle cannot have a width that is less than or equal to zero.");

                    this.Shadow_Width = value;
                    this.Shadow_Radius = this.Shadow_Width == this.Shadow_Height
                        ? Shadow_Width
                        : null;
                }
            }
            public int Height {
                readonly get => this.Shadow_Height;
                set {
                    if (value is <= 0)
                        throw new System.ArgumentException ("A circle cannot have a height that is less than or equal to zero.");

                    this.Shadow_Height = value;
                    this.Shadow_Radius = this.Shadow_Height == this.Shadow_Width
                        ? this.Shadow_Height
                        : null;
                }
            }
            public uint Color;
            public int Thickness {
                readonly get => this.Shadow_Thickness;
                set {
                    if (value <= 0)
                        throw new System.ArgumentException ("A circle cannot have a thickness that is less than or equal to zero");

                    this.Shadow_Thickness = value;
                }
            }
            public bool Fill;

            public Circle (in int x, in int y, in int radius, in uint color, in int thickness = 1, in bool fill = false) {
                this.X = x;
                this.Y = y;
                this.Radius = radius;
                this.Width = radius;
                this.Height = radius;
                this.Color = color;
                this.Thickness = thickness;
                this.Fill = fill;
            }
            public Circle (in int x, in int y, in int width, in int height, in uint color, in int thickness = 1, in bool fill = false) {
                this.X = x;
                this.Y = y;
                this.Width = width;
                this.Height = height;
                this.Color = color;
                this.Thickness = thickness;
                this.Fill = fill;
            }
        }
        public struct Polygon {
            private int Shadow_Thickness;
            private (int[] Lengths, int[] Angles) Shadow_Metrics;

            public int X;
            public int Y;
            public (int[] Lengths, int[] Angles) Metrics {
                readonly get => this.Shadow_Metrics;
                set {
                    if (value.Lengths.Length < 3)
                        throw new System.ArgumentException ("A polygon must have at least 3 sides.");

                    if (value.Lengths.Length != value.Angles.Length)
                        throw new System.ArgumentException ("The number of angles must match the number of sides.");

                    var sum = 0;
                    var target = (value.Lengths.Length - 2) * 180;

                    foreach (var angle in value.Angles) {
                        if (angle is <= 0 or >= 180)
                            throw new System.ArgumentException ("Each angle must be between 0 and 180 degrees.");

                        sum += angle;
                    }

                    if (sum != target)
                        throw new System.ArgumentException ($"The sum of the angles for a polygon with {value.Lengths.Length} sides must be {target} degrees.");

                    Validate (value.Lengths, value.Angles);

                    this.Shadow_Metrics = value;

                    static void Validate (int[] lengths, int[] angles) {
                        var x = 0d;
                        var y = 0d;
                        var angle = 0d;

                        for (var i = 0; i < lengths.Length; i++) {
                            var radians = angle * System.Math.PI / 180;

                            x += lengths[i] * System.Math.Cos (radians);
                            y += lengths[i] * System.Math.Sin (radians);

                            angle += 180 - angles[i];
                        }

                        if (System.Math.Round (x) + System.Math.Round (y) != 0)
                            throw new System.ArgumentException ("The angles and lengths do not result in a valid polygon.");
                    }
                }
            }
            public uint Color;
            public int Thickness {
                readonly get => this.Shadow_Thickness;
                set {
                    if (value <= 0)
                        throw new System.ArgumentException ("A polygon cannot have a thickness that is less than or equal to zero");

                    this.Shadow_Thickness = value;
                }
            }
            public int Rotation;
            public bool Fill;

            public Polygon (in int x, in int y, in int[] lengths, in uint color, in int thickness = 1, in int rotation = 0, in bool fill = false) {
                if (lengths.Length < 3)
                    throw new System.ArgumentException ("A polygon must have at least 3 sides.");

                for (var i = 1; i < lengths.Length; i++)
                    if (lengths[i] != lengths[i - 1])
                        throw new System.ArgumentException ("The side lengths of a regular polygon must equal.");

                var buffer = new int[lengths.Length];

                for (var i = 0; i < buffer.Length; i++)
                    buffer[i] = (buffer.Length - 2) * 180 / buffer.Length;

                this.X = x;
                this.Y = y;
                this.Metrics = (lengths, buffer);
                this.Color = color;
                this.Thickness = thickness;
                this.Rotation = rotation;
                this.Fill = fill;
            }
            public Polygon (in int x, in int y, in int[] lengths, in int[] angles, in uint color, in int thickness = 1, in int rotation = 0, in bool fill = false) {
                this.X = x;
                this.Y = y;
                this.Metrics = (lengths, angles);
                this.Color = color;
                this.Thickness = thickness;
                this.Rotation = rotation;
                this.Fill = fill;
            }
        }
        public struct Rectangle {
            private int Shadow_Width;
            private int Shadow_Height;
            private int Shadow_Thickness;

            public int X;
            public int Y;
            public int Width {
                readonly get => this.Shadow_Width;
                set {
                    if (value is <= 0)
                        throw new System.ArgumentException ("A rectangle cannot have a width that is less than or equal to zero.");

                    this.Shadow_Width = value;
                }
            }
            public int Height {
                readonly get => this.Shadow_Height;
                set {
                    if (value is <= 0)
                        throw new System.ArgumentException ("A rectangle cannot have a height that is less than or equal to zero.");

                    this.Shadow_Height = value;
                }
            }
            public uint Color;
            public int Thickness {
                readonly get => this.Shadow_Thickness;
                set {
                    if (value <= 0)
                        throw new System.ArgumentException ("A rectangle cannot have a thickness that is less than or equal to zero");

                    this.Shadow_Thickness = value;
                }
            }
            public int Rotation;
            public bool Fill;

            public Rectangle (in int x, in int y, in int width, in int height, in uint color, in int thickness = 1, in int rotation = 0, in bool fill = false) {
                this.X = x;
                this.Y = y;
                this.Width = width;
                this.Height = height;
                this.Color = color;
                this.Thickness = thickness;
                this.Rotation = rotation;
                this.Fill = fill;
            }
        }
        public struct Text {
            private int Shadow_Size;

            public int X;
            public int Y;
            public object Content;
            public uint Foreground;
            public uint Background;
            public int Size {
                readonly get => this.Shadow_Size;
                set {
                    if (value is <= 0)
                        throw new System.ArgumentException ("A text cannot have a size that is less than or equal to zero.");

                    this.Shadow_Size = value;
                }
            }
            public string Font;
            public bool Bold;
            public bool Italic;
            public bool Underline;
            public bool Strikethrough;
            public int Rotation;

            public Text (in int x, in int y, in object content, in uint foreground = Color.White, in uint background = Color.Transparent, in int size = 16, in string font = "Consolas", in bool bold = false, in bool italic = false, in bool underline = false, in bool strikethrough = false, in int rotation = 0) {
                this.X = x;
                this.Y = y;
                this.Content = content;
                this.Foreground = foreground;
                this.Background = background;
                this.Size = size;
                this.Font = font;
                this.Bold = bold;
                this.Italic = italic;
                this.Underline = underline;
                this.Strikethrough = strikethrough;
                this.Rotation = rotation;
            }

            public int Width ()
                => Sizes (in this.Shadow_Size, in this.Rotation, in this.Bold, in this.Italic, in this.Underline, in this.Strikethrough, in this.Font, in this.Content).cx + 1;
            public int Height ()
                => Sizes (in this.Shadow_Size, in this.Rotation, in this.Bold, in this.Italic, in this.Underline, in this.Strikethrough, in this.Font, in this.Content).cy + 1;

            public static int Width (in object content, in int size = 16, in string font = "Consolas", in bool bold = false, in bool italic = false, in bool underline = false, in bool strikethrough = false, in int rotation = 0)
                => Sizes (in size, in rotation, in bold, in italic, in underline, in strikethrough, in font, in content).cx + 1;
            public static int Height (in object content, in int size = 16, in string font = "Consolas", in bool bold = false, in bool italic = false, in bool underline = false, in bool strikethrough = false, in int rotation = 0)
                => Sizes (in size, in rotation, in bold, in italic, in underline, in strikethrough, in font, in content).cy + 1;

            private static Import.SIZE Sizes (in int size, in int rotation, in bool bold, in bool italic, in bool underline, in bool strikethrough, in string font, in object content) {
                var handle = Import.CreateCompatibleDC (nint.Zero);

                var current = Import.CreateFont (
                    -size,
                    0,
                    (360 - rotation) * 10,
                    0,
                    bold ? 700 : 400,
                    italic ? 1u : 0,
                    underline ? 1u : 0,
                    strikethrough ? 1u : 0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    font
                );

                var previous = Import.SelectObject (handle, current);
                var text = content.ToString () ?? "";

                _ = Import.GetTextExtentPoint32 (handle, text, text.Length, out var SIZE);
                _ = Import.SelectObject (handle, previous);
                _ = Import.DeleteObject (current);
                _ = Import.DeleteDC (handle);

                return SIZE;
            }
        }

        public static class Mouse {
            [System.Runtime.InteropServices.DllImport ("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            private static extern bool GetMonitorInfo (nint hMonitor, MONITORINFO lpmi);

            [System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            private class MONITORINFO {
                public int cbSize = System.Runtime.InteropServices.Marshal.SizeOf (typeof (MONITORINFO));
                public Import.RECT rcMonitor = new ();
                public Import.RECT rcWork = new ();
                public int dwFlags = 0;
            }

            private static int Index;
            private static Import.POINT Point, Last;
            private static bool Found = false;

            private static class Shadow {
                internal static int Monitor;
                internal static ((int X, int Y) True, (int X, int Y) Relative) Position;
            }

            public static int Monitor {
                get {
                    Fetch ();
                    return Shadow.Monitor;
                }
            }

            public static ((int X, int Y) True, (int X, int Y) Relative) Position {
                get {
                    Fetch ();
                    return (Shadow.Position.True, Shadow.Position.Relative);
                }
            }

            private static void Fetch () {
                if (Import.GetCursorPos (out Point)) {
                    if (Point.X != Last.X || Point.Y != Last.Y) {
                        Last = Point;
                        Index = -1;
                        Shadow.Position.True = (Point.X, Point.Y);
                        Found = false;

                        _ = Import.EnumDisplayMonitors (nint.Zero, nint.Zero, Enum, nint.Zero);

                        if (!Found)
                            throw new System.Exception ("No monitor found where the mouse is located.");
                    }
                } else {
                    throw new System.Exception ("Error when retrieving the mouse position.");
                }
            }

            private static bool Enum (nint hMonitor, nint hdcMonitor, ref Import.RECT lprcMonitor, nint dwData) {
                Index++;

                if (Point.X >= lprcMonitor.left && Point.X <= lprcMonitor.right && Point.Y >= lprcMonitor.top && Point.Y <= lprcMonitor.bottom) {
                    var info = new MONITORINFO ();

                    _ = GetMonitorInfo (hMonitor, info);

                    Found = true;
                    Shadow.Monitor = Index;
                    Shadow.Position.Relative = (Point.X - info.rcMonitor.left, Point.Y - info.rcMonitor.top);
                    return false;
                }
                return true;
            }
        }

        public static class Color {
            public const uint Transparent = 0x000000;
            public const uint Black = 0x000001;
            public const uint White = 0xFFFFFF;

            public const uint Gray = 0x808080;
            public const uint Gainsboro = 0xDCDCDC;
            public const uint Silver = 0xC0C0C0;

            public const uint Red = 0xFF0000;
            public const uint Vermilion = 0xE34234;
            public const uint Crimson = 0xDC143C;
            public const uint Maroon = 0x800000;
            public const uint Rose = 0xFF007F;
            public const uint Pink = 0xFFC0CB;

            public const uint Orange = 0xFFA500;
            public const uint Coral = 0xFF7F50;
            public const uint Salmon = 0xFA8072;
            public const uint Peach = 0xFFE5B4;
            public const uint Apricot = 0xFBCEB1;

            public const uint Gold = 0xFFD700;
            public const uint Amber = 0xFFBF00;
            public const uint Yellow = 0xFFFF00;
            public const uint Khaki = 0xF0E68C;
            public const uint Wheat = 0xF5DEB3;
            public const uint Moccasin = 0xFFE4B5;
            public const uint Bisque = 0xFFE4C4;

            public const uint Chartreuse = 0xDFFF00;
            public const uint Lime = 0x00FF00;
            public const uint Green = 0x008000;
            public const uint Olive = 0x808000;
            public const uint Mint = 0x98FF98;
            public const uint Emerald = 0x50C878;
            public const uint Teal = 0x008080;

            public const uint Aqua = 0x00FFFF;
            public const uint Cyan = 0x00FFFF;
            public const uint Turquoise = 0x40E0D0;
            public const uint Blue = 0x0000FF;
            public const uint Navy = 0x000080;
            public const uint Indigo = 0x4B0082;
            public const uint Periwinkle = 0xCCCCFF;

            public const uint Violet = 0x5B00BA;
            public const uint Purple = 0xA020F0;
            public const uint Fuchsia = 0xFF00FF;
            public const uint Magenta = 0xFF00FF;
            public const uint Orchid = 0xDA70D6;
            public const uint Plum = 0xDDA0DD;
            public const uint Lavender = 0xE6E6FA;

            public const uint Brown = 0xA52A2A;
            public const uint Sienna = 0xA0522D;
            public const uint Peru = 0xCD853F;
            public const uint Chocolate = 0xD2691E;
            public const uint Tan = 0xD2B48C;

            public const uint Linen = 0xFAF0E6;
            public const uint Ivory = 0xFFFFF0;
            public const uint Honeydew = 0xF0FFF0;
            public const uint Snow = 0xFFFAFA;
            public const uint Seashell = 0xFFF5EE;
            public const uint Beige = 0xF5F5DC;
        }

        public sealed class Draw {
            private nint Handle;
            private uint Count = 0;

            public int Monitor { get; private set; }
            public (int Size, Mode Mode) Cleanup = (0xFF, Mode.Default);

            public Draw (in int monitor = 0) => this.Initialize (monitor);
            public Draw (in Line line, in int monitor = 0) : this (in monitor) => this.Append (line);
            public Draw (in Arc arc, in int monitor = 0) : this (in monitor) => this.Append (arc);
            public Draw (in Circle circle, in int monitor = 0) : this (in monitor) => this.Append (circle);
            public Draw (in Polygon polygon, in int monitor = 0) : this (in monitor) => this.Append (polygon);
            public Draw (in Rectangle rectangle, in int monitor = 0) : this (in monitor) => this.Append (rectangle);
            public Draw (in Text text, in int monitor = 0) : this (in monitor) => this.Append (text);

            public void Append (in Line line) {
                if (this.Handle == nint.Zero)
                    return;

                try {
                    var handle = Import.GetDC (this.Handle);
                    var current = Import.CreatePen (0, line.Thickness, Format (line.Color));
                    var previous = Import.SelectObject (handle, current);

                    _ = Import.SetGraphicsMode (handle, 2);

                    Form (in line.X, in line.Y, in line.Rotation, out var form);

                    _ = Import.SetWorldTransform (handle, ref form);
                    _ = Import.MoveToEx (handle, 0, 0, nint.Zero);
                    _ = Import.LineTo (handle, line.Length, 0);
                    _ = Import.SelectObject (handle, previous);
                    _ = Import.DeleteObject (current);
                    _ = Import.ReleaseDC (this.Handle, handle);
                } finally {
                    this.Render ();
                }
            }
            public void Append (in Arc arc) {
                if (this.Handle == nint.Zero)
                    return;

                try {
                    var color = Format (arc.Color);
                    var handle = Import.GetDC (this.Handle);
                    var pen = Import.CreatePen (0, arc.Thickness, color);
                    var brush = arc.Fill ? Import.CreateSolidBrush (color) : nint.Zero;

                    (nint Pen, nint Brush) Previous = (Import.SelectObject (handle, pen), arc.Fill ? Import.SelectObject (handle, brush) : nint.Zero);

                    _ = Import.SetGraphicsMode (handle, 2);
                    _ = Import.SetArcDirection (handle, 2);

                    var height = System.Math.Pow (arc.Width - arc.Height, 2) / System.Math.Pow (arc.Width + arc.Height, 2);
                    var rotation = arc.Rotation * System.Math.PI / 180.0;

                    var x = (int)(arc.X - (arc.Width * System.Math.Sin (rotation)));
                    var y = (int)(arc.Y + (arc.Height * System.Math.Cos (rotation)));

                    var start = -System.Math.PI / 2;
                    var end = start + (arc.Length / (System.Math.PI * (arc.Width + arc.Height) * (1 + (3 * height / (10 + System.Math.Sqrt (4 - (3 * height)))))) * 360.0 * System.Math.PI / 180.0);

                    (int X, int Y) Start = ((int)(x + (arc.Width * System.Math.Cos (start + rotation))), (int)(y + (arc.Height * System.Math.Sin (start + rotation))));
                    (int X, int Y) End = ((int)(x + (arc.Width * System.Math.Cos (end + rotation))), (int)(y + (arc.Height * System.Math.Sin (end + rotation))));

                    if (Start.X == End.X && Start.Y == End.Y && System.Math.Round (end) <= 0) {
                        End.X += arc.Length;
                        End.Y += arc.Length;
                    }

                    _ = arc.Fill
                        ? Import.Pie (handle, x - arc.Width, y - arc.Height, x + arc.Width, y + arc.Height, Start.X, Start.Y, End.X, End.Y)
                        : Import.Arc (handle, x - arc.Width, y - arc.Height, x + arc.Width, y + arc.Height, Start.X, Start.Y, End.X, End.Y);

                    _ = Import.SelectObject (handle, Previous.Pen);

                    if (arc.Fill)
                        _ = Import.SelectObject (handle, Previous.Brush);

                    _ = Import.DeleteObject (pen);

                    if (brush != nint.Zero)
                        _ = Import.DeleteObject (brush);

                    _ = Import.ReleaseDC (this.Handle, handle);
                } finally {
                    this.Render ();
                }

            }
            public void Append (in Circle circle) {
                if (this.Handle == nint.Zero)
                    return;

                try {
                    var color = Format (circle.Color);
                    var handle = Import.GetDC (this.Handle);
                    var pen = Import.CreatePen (0, circle.Thickness, color);
                    var brush = circle.Fill
                        ? Import.CreateSolidBrush (color)
                        : Import.GetStockObject (5);

                    (nint Pen, nint Brush) Previous = (Import.SelectObject (handle, pen), Import.SelectObject (handle, brush));

                    _ = Import.Ellipse (handle, circle.X - circle.Width, circle.Y - circle.Height, circle.X + circle.Width, circle.Y + circle.Height);
                    _ = Import.SelectObject (handle, Previous.Pen);
                    _ = Import.SelectObject (handle, Previous.Brush);
                    _ = Import.DeleteObject (pen);

                    if (brush != nint.Zero)
                        _ = Import.DeleteObject (brush);

                    _ = Import.ReleaseDC (this.Handle, handle);
                } finally {
                    this.Render ();
                }
            }
            public void Append (in Polygon polygon) {
                if (this.Handle == nint.Zero)
                    return;

                try {
                    var color = Format (polygon.Color);
                    var handle = Import.GetDC (this.Handle);
                    var current = Import.CreatePen (0, polygon.Thickness, color);
                    var previous = Import.SelectObject (handle, current);
                    var brush = polygon.Fill ? Import.CreateSolidBrush (color) : nint.Zero;

                    if (polygon.Fill)
                        _ = Import.SelectObject (handle, brush);

                    _ = Import.SetGraphicsMode (handle, 2);

                    Form (polygon.X, polygon.Y, polygon.Rotation, out var form);

                    _ = Import.SetWorldTransform (handle, ref form);

                    (int X, int Y, double Angle) Current = (0, 0, 0);

                    var points = new Import.POINT[polygon.Metrics.Lengths.Length + 1];

                    for (var i = 0; i < polygon.Metrics.Lengths.Length; i++) {
                        points[i].X = Current.X;
                        points[i].Y = Current.Y;

                        Current = (Current.X + (int)(polygon.Metrics.Lengths[i] * System.Math.Cos (Current.Angle)),
                                   Current.Y + (int)(polygon.Metrics.Lengths[i] * System.Math.Sin (Current.Angle)),
                                   Current.Angle + ((180 - polygon.Metrics.Angles[i]) * System.Math.PI / 180));
                    }

                    points[polygon.Metrics.Lengths.Length] = points[0];

                    _ = polygon.Fill
                        ? Import.Polygon (handle, points, points.Length)
                        : Import.Polyline (handle, points, points.Length);

                    _ = Import.SelectObject (handle, previous);
                    _ = Import.DeleteObject (current);

                    if (brush != nint.Zero)
                        _ = Import.DeleteObject (brush);

                    _ = Import.ReleaseDC (this.Handle, handle);
                } finally {
                    this.Render ();
                }
            }
            public void Append (in Rectangle rectangle) {
                if (this.Handle == nint.Zero)
                    return;

                try {
                    var color = Format (rectangle.Color);
                    var handle = Import.GetDC (this.Handle);
                    var current = Import.CreatePen (0, rectangle.Thickness, color);
                    var previous = Import.SelectObject (handle, current);
                    var brush = rectangle.Fill ? Import.CreateSolidBrush (color) : nint.Zero;

                    _ = Import.SetGraphicsMode (handle, 2);

                    Form (rectangle.X, rectangle.Y, rectangle.Rotation, out var form);

                    _ = Import.SetWorldTransform (handle, ref form);

                    if (rectangle.Fill) {
                        _ = Import.SelectObject (handle, brush);
                        _ = Import.FillRect (handle, new Import.RECT {
                            left = 0,
                            top = 0,
                            right = rectangle.Width,
                            bottom = rectangle.Height
                        }, brush);
                    } else {
                        _ = Import.MoveToEx (handle, 0, 0, nint.Zero);
                        _ = Import.LineTo (handle, rectangle.Width, 0);
                        _ = Import.LineTo (handle, rectangle.Width, rectangle.Height);
                        _ = Import.LineTo (handle, 0, rectangle.Height);
                        _ = Import.LineTo (handle, 0, 0);
                    }

                    _ = Import.SelectObject (handle, previous);
                    _ = Import.DeleteObject (current);

                    if (brush != nint.Zero)
                        _ = Import.DeleteObject (brush);

                    _ = Import.ReleaseDC (this.Handle, handle);
                } finally {
                    this.Render ();
                }
            }
            public void Append (in Text text) {
                if (this.Handle == nint.Zero)
                    return;

                try {
                    var handle = Import.GetDC (this.Handle);
                    var current = Import.CreateFont (
                        -text.Size,
                        0,
                        (360 - text.Rotation) * 10,
                        0,
                        text.Bold ? 700 : 400,
                        text.Italic ? 1u : 0,
                        text.Underline ? 1u : 0,
                        text.Strikethrough ? 1u : 0,
                        0,
                        0,
                        0,
                        4,
                        0,
                        text.Font
                    );

                    var previous = Import.SelectObject (handle, current);
                    var content = text.Content.ToString () ?? "";

                    _ = Import.SetBkMode (handle, text.Background == Color.Transparent ? 1 : 2);
                    _ = Import.SetTextColor (handle, Format (text.Foreground));
                    _ = Import.SetBkColor (handle, Format (text.Background));
                    _ = Import.TextOut (handle, text.X, text.Y, content, content.Length);
                    _ = Import.SelectObject (handle, previous);
                    _ = Import.DeleteObject (current);
                    _ = Import.ReleaseDC (this.Handle, handle);
                } finally {
                    this.Render ();
                }
            }

            public void Overwrite (in Line line)
                => this.Append (new Line (in line.X, in line.Y, line.Length, Color.Transparent, line.Thickness, in line.Rotation));
            public void Overwrite (in Arc arc)
                => this.Append (new Arc (arc.X, arc.Y, arc.Width, arc.Height, arc.Length, Color.Transparent, arc.Thickness, arc.Rotation, arc.Fill));
            public void Overwrite (in Circle circle)
                => this.Append (new Circle (in circle.X, in circle.Y, circle.Width, circle.Height, Color.Transparent, circle.Thickness, in circle.Fill));
            public void Overwrite (in Polygon polygon)
                => this.Append (new Polygon (in polygon.X, in polygon.Y, polygon.Metrics.Lengths, polygon.Metrics.Angles, Color.Transparent, polygon.Thickness, in polygon.Rotation, in polygon.Fill));
            public void Overwrite (in Rectangle rectangle)
                => this.Append (new Rectangle (in rectangle.X, in rectangle.Y, rectangle.Width, rectangle.Height, Color.Transparent, rectangle.Thickness, in rectangle.Rotation, in rectangle.Fill));
            public void Overwrite (in Text text)
                => this.Append (new Rectangle (text.X, text.Y, text.Width (), text.Height (), Color.Transparent, 1, text.Rotation, true));

            public static void Temporarily (Line line, int delay = 10, int monitor = 0)
                => System.Threading.Tasks.Task.Run (() => {
                    var draw = new Draw (line, monitor);
                    System.Threading.Tasks.Task.Delay (delay).Wait ();
                    draw.Erase ();
                });
            public static void Temporarily (Arc arc, int delay = 10, int monitor = 0)
                => System.Threading.Tasks.Task.Run (() => {
                    var draw = new Draw (arc, monitor);
                    System.Threading.Tasks.Task.Delay (delay).Wait ();
                    draw.Erase ();
                });
            public static void Temporarily (Circle circle, int delay = 10, int monitor = 0)
                => System.Threading.Tasks.Task.Run (() => {
                    var draw = new Draw (circle, monitor);
                    System.Threading.Tasks.Task.Delay (delay).Wait ();
                    draw.Erase ();
                });
            public static void Temporarily (Polygon polygon, int delay = 10, int monitor = 0)
                => System.Threading.Tasks.Task.Run (() => {
                    var draw = new Draw (polygon, monitor);
                    System.Threading.Tasks.Task.Delay (delay).Wait ();
                    draw.Erase ();
                });
            public static void Temporarily (Rectangle rectangle, int delay = 10, int monitor = 0)
                => System.Threading.Tasks.Task.Run (() => {
                    var draw = new Draw (rectangle, monitor);
                    System.Threading.Tasks.Task.Delay (delay).Wait ();
                    draw.Erase ();
                });
            public static void Temporarily (Text text, int delay = 10, int monitor = 0)
                => System.Threading.Tasks.Task.Run (() => {
                    var draw = new Draw (text, monitor);
                    System.Threading.Tasks.Task.Delay (delay).Wait ();
                    draw.Erase ();
                });

            public void Clear () {
                if (this.Handle == nint.Zero)
                    return;

                this.Append (new Rectangle (0, 0, Monitors[this.Monitor].Resolution.Width, Monitors[this.Monitor].Resolution.Height, Color.Transparent, fill: true));
                System.GC.Collect (2, System.GCCollectionMode.Aggressive);
            }

            public void Erase () {
                if (this.Handle == nint.Zero)
                    return;

                _ = Import.DestroyWindow (this.Handle);
                this.Handle = nint.Zero;
                System.GC.Collect (2, System.GCCollectionMode.Aggressive);
            }

            private void Render () {
                if (this.Count != this.Cleanup.Size) {
                    this.Count++;
                    return;
                }

                switch (this.Cleanup.Mode) {
                    case Mode.Default:
                        System.GC.Collect (2, System.GCCollectionMode.Default);
                        break;
                    case Mode.Optimized:
                        System.GC.Collect (2, System.GCCollectionMode.Optimized);
                        break;
                    case Mode.Forced:
                        System.GC.Collect (2, System.GCCollectionMode.Forced);
                        break;
                    case Mode.Blocking:
                        System.GC.Collect (2, System.GCCollectionMode.Forced, true);
                        break;
                    case Mode.Aggressive:
                        System.GC.Collect (2, System.GCCollectionMode.Aggressive);
                        break;
                }

                System.GC.WaitForPendingFinalizers ();

                this.Count = 0;
            }
            private void Initialize (in int monitor) {
                this.Monitor = monitor;

                System.Collections.Generic.List<Import.MONITORINFO> Monitors = [];

                _ = Import.EnumDisplayMonitors (
                    nint.Zero,
                    nint.Zero,
                    Monitor,
                    nint.Zero);

                if (monitor < 0 || monitor >= Monitors.Count)
                    throw new System.ArgumentOutOfRangeException (
                        nameof (monitor),
                        "Monitor monitor is out of range.");

                this.Handle = Import.CreateWindowEx (
                    134742184,
                    "STATIC",
                    "",
                    -2147483648,
                    Monitors[monitor].rcMonitor.left,
                    Monitors[monitor].rcMonitor.top,
                Monitors[monitor].rcMonitor.right - Monitors[monitor].rcMonitor.left,
                Monitors[monitor].rcMonitor.bottom - Monitors[monitor].rcMonitor.top,
                nint.Zero,
                nint.Zero,
                    nint.Zero,
                    nint.Zero);

                _ = Import.SetLayeredWindowAttributes (
                    this.Handle, 0, 0, 1);
                _ = Import.ShowWindow (this.Handle, 5);
                _ = Import.SetWindowPos (this.Handle, -1, Monitors[monitor].rcMonitor.left, Monitors[monitor].rcMonitor.top, 0, 0, 19);

                System.GC.Collect (2, System.GCCollectionMode.Aggressive);

                bool Monitor (nint hMonitor, nint hdcMonitor, ref Import.RECT lprcMonitor, nint dwData) {
                    var info = new Import.MONITORINFO {
                        cbSize = System.Runtime.InteropServices.Marshal.SizeOf (typeof (Import.MONITORINFO))
                    };

                    if (Import.GetMonitorInfo (hMonitor, ref info))
                        Monitors.Add (info);

                    return true;
                }
            }
            private static uint Format (uint color)
                => (uint)(((byte)(color & 0xFF) << 16) | ((byte)((color >> 8) & 0xFF) << 8) | (byte)((color >> 16) & 0xFF));
            private static void Form (in int x, in int y, in int rotation, out Import.XFORM form) {
                var a = (float)System.Math.Cos (rotation * System.Math.PI / 180);
                var b = (float)System.Math.Sin (rotation * System.Math.PI / 180);

                form = new Import.XFORM {
                    eM11 = a,
                    eM12 = b,
                    eM21 = -b,
                    eM22 = a,
                    eDx = x,
                    eDy = y
                };
            }

            public enum Mode {
                None,
                Default,
                Optimized,
                Forced,
                Blocking,
                Aggressive,
            }

            ~Draw () => this.Erase ();
        }
    }
}