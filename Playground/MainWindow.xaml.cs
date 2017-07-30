using System;
using System.Windows;
using System.Windows.Controls;

//using System.Windows.Shapes;

namespace Playground
{
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

                case "ForwardButton":
                    ICommand forward = new ForwardCommand(mediaElement);
                    forward.Execute(Playlist);
                    break;

                case "RewindButton":
                    ICommand rewind = new RewindCommand(mediaElement);
                    rewind.Execute(Playlist);
                    break;

                case "StopButton":
                    ICommand stop = new StopCommand(mediaElement);
                    stop.Execute();
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
    }
}