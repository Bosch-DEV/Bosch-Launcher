using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
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
using System.Collections.ObjectModel;

namespace Bosch_Launcher.Pages;

public partial class Games : Page {
    public ObservableCollection<Game> Items { get; set; } = [];
    
    public Games () {
        this.InitializeComponent ();

        var titles = new List<string> ();

        this.Loaded += async (sender, e) => {
            var data = await Download ("https://raw.githubusercontent.com/Bosch-DEV/Games/main/README.md");

            if (data == null)
                return;

            titles = Encoding.UTF8.GetString (data).Split (new[] { "\r\n", "\n" }, StringSplitOptions.None)
                         .Where (line => line.StartsWith ("## "))
                         .Select (title => title[3..])
                         .ToList ();

            foreach (var title in titles) {
                var url = $"https://raw.githubusercontent.com/Bosch-DEV/Games/main/{Uri.EscapeDataString (title)}/";
                this.Items.Add (new () { Title = title, Image = Convert (await Download ($"{url}Logo.png")), Author = Encoding.UTF8.GetString (await Download ($"{url}Info")) });
            }

            this.DataContext = this;
        };
    }

    private async void Border_MouseDown (object sender, MouseButtonEventArgs? e) {
        var border = sender as FrameworkElement;

        if (border?.DataContext is Game item) {
            var index = this.Items.IndexOf (item);
            var path = Path.Combine (Settings.Location, this.Items[index].Title);
            var executable = Path.Combine (path, $"{this.Items[index].Title}.exe");

            if (Directory.Exists (path) && File.Exists (executable)) {
                _ = Process.Start (executable);
            } else {
                _ = Directory.CreateDirectory (path);
                await this.ExtractZipFiles (index);
                _ = Process.Start (executable);
            }
        }
    }

    private async Task ExtractZipFiles (int index) {
        try {
            using var stream = new MemoryStream (await Download ($"https://github.com/Bosch-DEV/Games/raw/main/{this.Items[index].Title}/Data.zip"));
            using var archive = new ZipArchive (stream, ZipArchiveMode.Read);

            ZipFile.ExtractToDirectory (stream, Path.Combine (Settings.Location, this.Items[index].Title));
        } catch (Exception ex) {
            _ = MessageBox.Show ($"Fehler beim Extrahieren der ZIP-Datei: {ex.Message}");
        }
    }

    private void Border_KeyDown (object sender, KeyEventArgs e) {
        if (e.Key is Key.Enter or Key.Space)
            this.Border_MouseDown (sender, null);
    }

    private void RadioButton_A_Z_Checked (object sender, RoutedEventArgs e)
        => this.Sort (true);

    private void RadioButton_Z_A_Checked (object sender, RoutedEventArgs e)
        => this.Sort (false);

    private void Sort (bool ascending) {
        var sorted = ascending
            ? this.Items.OrderBy (game => game.Title).ToList ()
            : this.Items.OrderByDescending (game => game.Title).ToList ();

        this.Items.Clear ();
        foreach (var game in sorted) {
            this.Items.Add (game);
        }
    }

    private static BitmapImage Convert (byte[] bytes) {
        if (bytes == null)
            return null!;

        var image = new BitmapImage ();
        using (var stream = new MemoryStream (bytes)) {
            stream.Position = 0;
            image.BeginInit ();
            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit ();
        }

        image.Freeze ();
        return image;
    }

    public class Game {
        public required string Title { get; set; }
        public required BitmapImage Image { get; set; }
        public required string Author { get; set; }
    }
}
