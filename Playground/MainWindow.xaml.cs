namespace Playground
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Playground.Model;
    using ViewModel;
    using System.Collections.Generic;
    using Services;
    using IO.Command;
    using NAudio.Wave;
    using System.Text;
    using Enums;
    using System.Linq;
    using System.IO;
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: MetroWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.MediaElement = this.MediaPlayer;
            this.songViewModel = new SongViewModel(mediaElement, Playlist);
            this.DataContext = songViewModel;
            this.AudioSlider.Value = 1;
            this.MediaElement.Volume = 1;
            this.MediaPlayer.MediaEnded += new RoutedEventHandler(this.LoopMediaEnded);
        }

        public static bool isPlaying = false;
        private MediaElement mediaElement;
        private SongViewModel songViewModel;

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

        private void LoopMediaEnded(object sender, RoutedEventArgs e)
        {
            var incomingCommand = $"{((FrameworkElement)e.Source).Name}PlayBack";
            songViewModel.CurrentSong = Playlist.SelectedItem as Song;
            //songViewModel.command.InterpretCommand(incomingCommand, songViewModel.CurrentSong);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            songViewModel.CurrentSong = Playlist.SelectedItem as Song;
            var song = songViewModel.CurrentSong;
            songViewModel.PlaySong(sender);
            seekBar.Maximum = songViewModel.CurrentSong.Duration.TotalSeconds;
            seekBar.Value = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += this.Timer_Tick;
            timer.Start();
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position += TimeSpan.FromMinutes(1);
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            if (this.MediaElement.NaturalDuration.HasTimeSpan)
            {
                songStatus.Content = string.Format("{0} - {1}", this.MediaElement.Position.ToString(@"mm\:ss"), this.MediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                seekBar.Value = this.MediaElement.Position.TotalSeconds;
            }
        }

        private void ChangeValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;

            seekBar.Value = value;
            this.MediaPlayer.Position = TimeSpan.FromSeconds(value);
        }

        private void MainWindowKeys(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                this.MediaPlayer.Position -= TimeSpan.FromSeconds(1);
            }

            if (e.Key == Key.Right)
            {
                this.MediaPlayer.Position += TimeSpan.FromSeconds(1);
            }

            if (e.Key == Key.Add)
            {
                this.MediaElement.Volume += 0.05;
                this.AudioSlider.Value += 0.05;
            }

            if (e.Key == Key.Subtract)
            {
                this.MediaElement.Volume -= 0.05;
                this.AudioSlider.Value -= 0.05;
            }

            if (e.Key == Key.Escape)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.MediaElement.MaxWidth = 600;
                this.MediaElement.MaxHeight = 385;
                this.MediaElement.Width = 600;
                this.MediaElement.Height = 385;
                this.Width = 1200;
                this.Height = 700;
                this.WindowState = WindowState.Normal;
                this.MediaElement.Margin = new Thickness(584, 279, -584, -279);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.MediaElement.MaxWidth = SystemParameters.PrimaryScreenWidth;
            this.MediaElement.MaxHeight = SystemParameters.PrimaryScreenHeight;
            this.MediaElement.Width = SystemParameters.PrimaryScreenWidth;
            this.MediaElement.Height = SystemParameters.PrimaryScreenHeight;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            this.WindowState = WindowState.Maximized;
            this.MediaElement.Margin = new Thickness(0, 0, 0, 0);
            //new VideoWindow(Resources["Media"] as VisualBrush).Show();
        }

        private void Playlist_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var songPath in files)
            {
                int extensionDotIndex = songPath.LastIndexOf('.');
                string extName = songPath.Substring(extensionDotIndex + 1).ToUpper();
                if (!Enum.IsDefined(typeof(AudioFormats), extName))
                {
                    ErrorWindow errowWindow = new ErrorWindow();
                    errowWindow.ShowDialog();
                }
                else
                {
                    TimeSpan songDuration = this.GetSongDurationInSeconds(songPath);
                    TagLib.File fileInfo = TagLib.File.Create(songPath);

                    string songName = Path.GetFileNameWithoutExtension(songPath);
                    string genre = fileInfo.Tag.Genres.FirstOrDefault();
                    string album = fileInfo.Tag.Album;
                    string artist = fileInfo.Tag.AlbumArtists.FirstOrDefault();

                    Song song = new Song(songName, songDuration, songPath, album, artist, genre);

                    songViewModel.Playlist.Add(song);
                }
            }
        }

        private string AudioFormater()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("All Supported Audio | ");
            foreach (AudioFormats type in Enum.GetValues(typeof(AudioFormats)))
            {
                sb.Append($"*.{type}; ");
            }

            foreach (AudioFormats type in Enum.GetValues(typeof(AudioFormats)))
            {
                sb.Append($"|{type}s |*.{type}");
            }

            return sb.ToString().Trim();
        }

        private TimeSpan GetSongDurationInSeconds(string filePath)
        {
            MediaFoundationReader audioReader = new MediaFoundationReader(filePath);

            return audioReader.TotalTime;
        }
    }
}