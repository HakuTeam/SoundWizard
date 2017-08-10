namespace Playground
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Threading;
    using ViewModel;
    using Playground.Model;
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.songViewModel = new SongViewModel();
            this.DataContext = songViewModel;

            this.MediaElement = this.MediaPlayer;
            this.MediaElement.Volume = 1;
            this.AudioSlider.Value = 1;
            this.MediaPlayer.MediaEnded += new RoutedEventHandler(this.LoopMediaEnded);
        }

        public static bool isPlaying = false;
        private MediaElement mediaElement;
        private SongViewModel songViewModel;
        private bool isDragging = false;

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
            songViewModel.command.InterpretCommand(incomingCommand, songViewModel.CurrentSong);
        }

        public void CommandProcessing(object sender, RoutedEventArgs e)
        {
            var incomingCommand = ((FrameworkElement)e.Source).Name;
            songViewModel.CurrentSong = Playlist.SelectedItem as Song;
            songViewModel.command.InterpretCommand(incomingCommand, songViewModel.CurrentSong);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            songViewModel.CurrentSong = Playlist.SelectedItem as Song;
            var song = songViewModel.CurrentSong;
            var incomingCommand = "PlayButton";
            songViewModel.command.InterpretCommand(incomingCommand, song);

            this.MediaElement.Source = new Uri(songViewModel.CurrentSong.Path);
            this.MediaElement.Play();
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
            if (this.MediaElement.NaturalDuration.HasTimeSpan && !this.isDragging)
            {
                songStatus.Content = string.Format("{0} - {1}", this.MediaElement.Position.ToString(@"mm\:ss"), this.MediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                seekBar.Value = this.MediaElement.Position.TotalSeconds;
            }
        }

        private void SeekBar_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.isDragging = true;
        }

        private void SeekBar_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.isDragging = false;
            this.MediaPlayer.Position = TimeSpan.FromSeconds(seekBar.Value);
        }
    }
}