namespace Playground
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Model;
    using ViewModel;
    using NAudio.Wave;
    using Enums;
    using System.Linq;
    using System.IO;
    using Utility;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MediaElement mediaElement;
        private MainViewModel mainViewModel;

        public MainWindow()
        {
            this.InitializeComponent();
            this.MediaElement = this.MediaPlayer;
            this.mainViewModel = new MainViewModel(mediaElement, Playlist);
            this.DataContext = mainViewModel;
            this.AudioSlider.Value = 1;
            this.MediaElement.Volume = 1;
            this.MediaPlayer.MediaEnded += this.LoopMediaEnded;
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

        private void LoopMediaEnded(object sender, RoutedEventArgs e)
        {
            var incomingCommand = $"{((FrameworkElement)e.Source).Name}PlayBack";
            mainViewModel.CurrentSong = Playlist.SelectedItem as Song;
            //mainViewModel.command.InterpretCommand(incomingCommand, mainViewModel.CurrentSong);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainViewModel.CurrentSong = Playlist.SelectedItem as Song;
            mainViewModel.PlaySong(sender);
            seekBar.Maximum = mainViewModel.CurrentSong.Duration.TotalSeconds;
            seekBar.Value = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += this.Timer_Tick;
            timer.Start();
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

        private void Playlist_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FileLoader fileLoader = new FileLoader(files, mainViewModel.Playlist);
            fileLoader.LoadMediaFile();
        }
    }
}