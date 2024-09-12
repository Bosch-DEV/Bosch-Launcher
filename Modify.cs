using System.Windows;
using System.Windows.Media;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace Bosch_Launcher;
public class Modify {
    [DllImport ("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute (nint Handle, int attribute, ref uint pvAttribute, int cbAttribute);

    private nint Handle;
    private uint _titlebar;
    private uint _border;

    public Modify (Window window)
        => window.SourceInitialized += (sender, args) => {
            Handle = new WindowInteropHelper (window).Handle;
            HwndSource.FromHwnd (Handle)?.AddHook (this.Process);

            if (_titlebar != 0)
                this.Apply (35, _titlebar);
            if (_border != 0)
                this.Apply (34, _border);
        };

    public Color Titlebar {
        get => Out (_titlebar);
        set {
            _titlebar = In (value);
            if (Handle != nint.Zero)
                this.Apply (35, _titlebar);
        }
    }

    public Color Border {
        get => Out (_border);
        set {
            _border = In (value);
            if (Handle != nint.Zero)
                this.Apply (34, _border);
        }
    }

    private void Apply (int attribute, uint color)
        => _ = DwmSetWindowAttribute (Handle, attribute, ref color, Marshal.SizeOf<uint> ());

    private nint Process (nint Handle, int msg, nint wParam, nint lParam, ref bool handled)
        => nint.Zero;

    private static uint In (in Color color)
        => (uint)(color.R | (color.G << 8) | (color.B << 16));

    private static Color Out (uint colorValue)
        => Color.FromRgb ((byte)(colorValue & 0xFF), (byte)((colorValue >> 8) & 0xFF), (byte)((colorValue >> 16) & 0xFF));
}