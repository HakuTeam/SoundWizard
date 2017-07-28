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
using Microsoft.Win32;
//using System.Windows.Shapes;

namespace Playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true; 
            dlg.DefaultExt = ".mp3";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dlg.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";
            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true)
            {
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
        }

        private void Rewind_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Forward_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Play();
        }

        public void Stop_Play_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isPlaying)
            {
                mediaElement1.Pause();
                isPlaying = true;
            }
            else
            {
                mediaElement1.Play();
                isPlaying = false;
            }
        }
    }
}
