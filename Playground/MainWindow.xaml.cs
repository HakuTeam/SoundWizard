using System;
using System.Windows;
using System.Windows.Controls;

//using System.Windows.Shapes;

namespace Playground
{
    using Interfaces;
    using IO;
    using IO.Command;
    using System.Reflection;

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
            CommandInterpreter command = new CommandInterpreter(mediaElement, Playlist);
            Button currentButton = (Button)sender;
            command.InterpretCommand(currentButton.Name);
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
    }
}