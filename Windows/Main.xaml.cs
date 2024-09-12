using Bosch_Launcher.Pages;
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
using System.Windows.Shapes;

namespace Bosch_Launcher.Windows;
public partial class Main : Window {
    public Main () {
        _ = new Modify (this) {
            Titlebar = Colors.White,
            Border = Colors.Red
        };

        this.InitializeComponent ();
        this.Title = "Home";
        this.Frame.Content = new Starting ();
    }

    private void Button_Load_Page_Starting (object sender, RoutedEventArgs e) {
        this.Title = "Home";
        this.Frame.Content = new Starting ();
    }

    private void Button_Click_Load_Page_Games (object sender, RoutedEventArgs e) {
        this.Title = "Games";
        this.Frame.Content = new Games ();
    }

    private void Button_Load_Page_Socials (object sender, RoutedEventArgs e) {
        this.Title = "Socials";
        this.Frame.Content = new Socials ();
    }

    private void Button_Load_Page_Settings (object sender, RoutedEventArgs e) {
        this.Title = "Settings";
        this.Frame.Content = new Settings ();
    }
}
