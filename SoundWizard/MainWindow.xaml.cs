namespace SoundWizard
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Model;
    using Utility;
    using ViewModel;

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
            MediaElement = MediaPlayer;
            this.mainViewModel = new MainViewModel(this.mediaElement, Playlist);
            DataContext = this.mainViewModel;
            AudioSlider.Value = 1;
            MediaElement.Volume = 1;
        }

        public Slider VolumeSlider
        {
            get { return this.AudioSlider; }
            set { this.AudioSlider = value; }
        }

        public MediaElement MediaElement
        {
            get { return this.mediaElement; }
            set { this.mediaElement = value; }
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            if (MediaElement.NaturalDuration.HasTimeSpan)
            {
                mediaStatus.Content = string.Format("{0} - {1}", MediaElement.Position.ToString(@"hh\:mm\:ss"), MediaElement.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"));
                seekBar.Value = MediaElement.Position.TotalSeconds;
            }
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;
            MediaPlayer.Volume = value;
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.mainViewModel.CurrentMedia = Playlist.SelectedItem as Media;
            if (!this.mainViewModel.CanPlayMedia(sender))
            {
                return;
            }
            this.mainViewModel.PlayMedia(sender);
            seekBar.Maximum = this.mainViewModel.CurrentMedia.Duration.TotalSeconds;
            seekBar.Value = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += this.Timer_Tick;
            timer.Start();
        }

        private void ChangeValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;

            seekBar.Value = value;
            MediaPlayer.Position = TimeSpan.FromSeconds(value);
        }

        private void Playlist_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FileLoader fileLoader = new FileLoader(files, this.mainViewModel.Playlist);
            fileLoader.LoadMediaFile();
        }
    }
}