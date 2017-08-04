namespace Playground
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Threading;
    using IO;
    using Playground.Core;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isPlaying = false;
        private bool isDragging = false;
        private MediaElement mediaElement;
        private CommandInterpreter command;

        public MainWindow()
        {
            this.InitializeComponent();
            this.MediaElement = this.MediaPlayer;
            this.AudioSlider.Value = 1;
            this.MediaPlayer.MediaEnded += new RoutedEventHandler(this.LoopMediaEnded);
        }

        public MediaElement MediaElement
        {
            get { return this.mediaElement; }
            set { this.mediaElement = value; }
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;
            this.MediaPlayer.Volume = value;
        }

        private void LoopMediaEnded(object sender, RoutedEventArgs e)
        {
            command = new CommandInterpreter(mediaElement, Playlist);
            var incomingCommand = $"{((System.Windows.FrameworkElement)e.Source).Name}PlayBack";
            command.InterpretCommand(incomingCommand);
        }

        public void CommandProcessing(object sender, RoutedEventArgs e)
        {

            CommandInterpreter command = new CommandInterpreter(this.mediaElement, Playlist);
            var incomingCommand = ((FrameworkElement)e.Source).Name;

            command = new CommandInterpreter(mediaElement, Playlist);

            command.InterpretCommand(incomingCommand);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var song = Playlist.SelectedItems[0] as Song;
            CommandInterpreter command = new CommandInterpreter(this.mediaElement, Playlist);
            var incomingCommand = ((FrameworkElement)e.Source).Name;

            command = new CommandInterpreter(mediaElement, Playlist);

            command.InterpretCommand(incomingCommand);
            seekBar.Maximum = song.Duration.TotalSeconds;
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

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {

            MediaPlayer.Position += TimeSpan.FromSeconds(5);

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