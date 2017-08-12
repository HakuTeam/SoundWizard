namespace Playground
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using IO;
    using ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static bool isPlaying = false;
        private MediaElement mediaElement;
        private CommandInterpreter command;

        public MainWindow()
        {
            this.InitializeComponent();
            this.MediaElement = this.MediaPlayer;
            this.AudioSlider.Value = 1;
            this.MediaElement.Volume = 1;
            this.MediaPlayer.MediaEnded += new RoutedEventHandler(this.LoopMediaEnded);
            this.PlayListSongs = new ObservableCollection<SongViewModel>();
            this.DataContext = this.PlayListSongs;
            this.command = new CommandInterpreter(this.mediaElement, this.PlayListSongs, this.Playlist);
        }

        public ObservableCollection<SongViewModel> PlayListSongs { get; set; }

        public MediaElement MediaElement
        {
            get { return this.mediaElement; }
            set { this.mediaElement = value; }
        }

        public SongViewModel CurrentSong
        {
            get { return this.Playlist.SelectedItem as SongViewModel; }
            set { this.Playlist.SelectedItem = value; }
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
            this.command.InterpretCommand(incomingCommand);
        }

        public void CommandProcessing(object sender, RoutedEventArgs e)
        {
            var incomingCommand = ((FrameworkElement)e.Source).Name;
            this.command.InterpretCommand(incomingCommand);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var song = this.CurrentSong;
            var incomingCommand = ((FrameworkElement)e.Source).Name;
            this.command.InterpretCommand(incomingCommand);

            seekBar.Maximum = song.TotalSeconds;
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

        private void ChangeValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;

            seekBar.Value = value;
            this.MediaPlayer.Position = TimeSpan.FromSeconds(value);
        }
    }
}