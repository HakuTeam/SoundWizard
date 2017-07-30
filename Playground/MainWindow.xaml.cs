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
using NAudio.Wave;
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
            dlg.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string[] filename = dlg.FileNames;
                foreach (var item in filename)
                {
                    var pathAndSong = item.LastIndexOf('\\');
                    var songName = item.Substring(pathAndSong + 1);
                    Mp3FileReader getSongDuration = new Mp3FileReader(item);
                    TimeSpan time = getSongDuration.TotalTime;
                    string duration = string.Format("{0:00}:{1:00}:{2:00}", (int)time.TotalHours, time.Minutes, time.Seconds);
                    Song song = new Song(songName, duration, item);
                    Playlist.Items.Add(song);
                }
            }
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lastIndex = Playlist.SelectedItems[0] as Song;
            mediaElement1.Source = new Uri($"{lastIndex.Path}");
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
