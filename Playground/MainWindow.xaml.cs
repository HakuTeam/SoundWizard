namespace Playground
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using IO;
    using Playground.Core;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isPlaying = false;
        private MediaElement mediaElement;

        public MainWindow()
        {
            this.InitializeComponent();
            this.MediaElement = this.MediaPlayer;
            this.AudioSlider.Value = 1;
        }

        public MediaElement MediaElement
        {
            get { return this.mediaElement; }
            set { this.mediaElement = value; }
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;
            this.MediaPlayer.Volume = value;
        }

        public void Click(object sender, RoutedEventArgs e)
        {
            CommandInterpreter command = new CommandInterpreter(mediaElement, Playlist);
            Button currentButton = (Button)sender;
            command.InterpretCommand(currentButton.Name);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int lastIndex = Playlist.SelectedItem.ToString().IndexOf(':');
            //string currentSongPath = Playlist.SelectedItem.ToString().Substring(lastIndex + 2);
            //this.mediaElement.Source = new Uri($"{currentSongPath}");
            //this.mediaElement.Play();
            //var songLength = this.mediaElement.NaturalDuration;
            //this.mediaElement.Position

            var song = Playlist.SelectedItems[0] as Song;
            MediaPlayer.Source = new Uri($"{song.Path}");
            MediaPlayer.Play();
        }
    }
}