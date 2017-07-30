using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
//using System.Windows.Shapes;

namespace Playground
{
    using Core;
    using Interfaces;
    using Models;
    using Models.Buttons;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isPlaying = false;
        private MediaElement mediaElement;

        public MainWindow()
        {
            InitializeComponent();
            this.MediaElement = mediaElement1;
        }

        public MediaElement MediaElement
        {
            get { return this.mediaElement; }
            set { this.mediaElement = value; }
        }

        public void Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;

            switch (currentButton.Name)
            {
                case "PlayButton":
                    ICommand play = new PlayCommand(mediaElement);
                    play.Execute();
                    break;
                case "OpenButton":
                    ICommand open = new OpenCommand(mediaElement);
                    open.Execute(Playlist);
                    break;
                default:
                    break;
            }
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int lastIndex = Playlist.SelectedItem.ToString().IndexOf(':');
            string currentSongPath = Playlist.SelectedItem.ToString().Substring(lastIndex + 2);
            this.mediaElement.Source = new Uri($"{currentSongPath}");
            this.mediaElement.Play();
            var songLength = this.mediaElement.NaturalDuration;
            //this.mediaElement.Position
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
            this.mediaElement.Stop();  
        }
    }
}
