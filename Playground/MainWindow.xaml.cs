using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
//using System.Windows.Shapes;

namespace Playground
{
    using Core;

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
                List<Song> playList = new List<Song>();

                Playlist.DisplayMemberPath = ToString();

                foreach (var item in filename)
                {
                    var pathAndSong = item.LastIndexOf('\\');
                    var songName = item.Substring(pathAndSong + 1);

                    Song song = new Song(songName, TimeSpan.FromMinutes(3.0), item);
                    var songItem = new ListBoxItem();

                    songItem.Content = song.Path;
                    //dsfdsfsdfd
                    Playlist.Items.Add(songItem);
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
            if (Playlist.SelectedIndex > 1)
            {
                Playlist.SelectedIndex--;
            }

        }

        private void Forward_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Playlist.SelectedIndex <= Playlist.Items.Count - 1)
            {
                Playlist.SelectedIndex++;
            }
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            isPlaying = true;
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
