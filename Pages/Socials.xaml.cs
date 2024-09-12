using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bosch_Launcher.Pages;
public partial class Socials : Page {
    public Socials () {
        this.InitializeComponent ();
        this.Loaded += async (sender, e) => Encoding.UTF8.GetString (await Download ("https://raw.githubusercontent.com/Bosch-DEV/Games/main/README.md") ?? [0x23, 0x20, 0x45, 0x72, 0x72, 0x6F, 0x72, 0x20, 0x6C, 0x6F, 0x61, 0x64, 0x69, 0x6E, 0x67, 0x20, 0x53, 0x6F, 0x63, 0x69, 0x61, 0x6C, 0x73, 0x2E]).Pipe (Markdown).Pipe (this.Browser.NavigateToString);
    }
}
