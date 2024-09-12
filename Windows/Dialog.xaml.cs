using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

public partial class Dialog : Window {
    public string Address { get; private set; }
    public SecureString Password { get; private set; }

    public Dialog (string address) {
        this.InitializeComponent ();
        this.Address = address;
        this.Proxy.Text = address;
        this.DataContext = this;
    }

    private void Submit () {
        this.Password = Input.SecurePassword;
        this.DialogResult = true;
        this.Close ();
    }

    private void Submit_Click (object sender, RoutedEventArgs e)
        => this.Submit ();
    private void Input_KeyDown (object sender, KeyEventArgs e) {
        if (e.Key == Key.Enter)
            this.Submit ();
    }
}
