using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bosch_Launcher.Windows;

namespace Bosch_Launcher.Pages;
public partial class Starting : Page {
    public Starting () {
        this.InitializeComponent ();
        this.Loaded += async (sender, e) => Encoding.UTF8.GetString (await Download ("https://raw.githubusercontent.com/Bosch-DEV/Bosch-Launcher/master/Patch%20Notes.md") ?? [0x23, 0x20, 0x45, 0x72, 0x72, 0x6F, 0x72, 0x20, 0x6C, 0x6F, 0x61, 0x64, 0x69, 0x6E, 0x67, 0x20, 0x50, 0x61, 0x74, 0x63, 0x68, 0x20, 0x4E, 0x6F, 0x74, 0x65, 0x73, 0x2E]).Pipe (Markdown).Pipe (this.Browser.NavigateToString);
    }
}