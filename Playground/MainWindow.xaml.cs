using Playground.Models;
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
//using System.Windows.Shapes;

namespace Playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //// Create an ImageBrush.
            //ImageBrush textImageBrush = new ImageBrush();
            //textImageBrush.ImageSource = new BitmapImage(new Uri(@"PlayerSkin\import.png", UriKind.Relative));
            //textImageBrush.AlignmentX = AlignmentX.Left;
            //textImageBrush.Stretch = Stretch.None;
            //// Use the brush to paint the button's background.
            //ASD.Background = textImageBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();


            dlg.Multiselect = true;
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".mp3";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dlg.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 

                //Image img = new Image();
                //img.Source = new BitmapImage(new Uri(dlg.FileName));
                string[] filename = dlg.FileNames;
                foreach (var item in filename)
                {
                    var imgItem = new ListBoxItem();
                    var pathItem = new ListBoxItem();
                    pathItem.Content = item;

                    var pathAndSong = item.LastIndexOf('\\');
                    var songName = item.Substring(pathAndSong + 1);
                    imgItem.Content = songName;

                    Playlist.Items.Add(pathItem);                   
                }                
            }
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int lastIndex = Playlist.SelectedItem.ToString().IndexOf(':');
            string currentSongPath = Playlist.SelectedItem.ToString().Substring(lastIndex + 2);
            mediaElement1.Source = new Uri($"{currentSongPath}");
            mediaElement1.Play();
            //// Create an ImageBrush.
            //ImageBrush textImageBrush = new ImageBrush();
            //textImageBrush.ImageSource = new BitmapImage(new Uri(@"D:\SoftUni\HakuTeamProject\Playground\Playground\PlayerSkin\blue-sound-wave.jpg", UriKind.Relative));
            //textImageBrush.AlignmentX = AlignmentX.Left;
            //textImageBrush.Stretch = Stretch.None;
            //// Use the brush to paint the button's background.
            //Playlist.Background = textImageBrush;
        }
    }
}
