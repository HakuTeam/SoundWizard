namespace Playground
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using ViewModel;
    using Playground.Model;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
        }
    }
}