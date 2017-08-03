﻿namespace Playground
{
    using IO;
    using Playground.Core;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

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
            MediaPlayer.MediaEnded += new RoutedEventHandler(LoopMediaEnded);
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
            if (Playlist.SelectedIndex == this.Playlist.Items.Count - 1)
            {
                MediaPlayer.Stop();
                Playlist.SelectedIndex = 0;
                MediaPlayer.Play();
            }
            else
            {
                MediaPlayer.Stop();
                Playlist.SelectedIndex++;
                MediaPlayer.Play();
            }
        }

        public void Click(object sender, RoutedEventArgs e)
        {
            CommandInterpreter command = new CommandInterpreter(mediaElement, Playlist);
            Button currentButton = (Button)sender;
            command.InterpretCommand(currentButton.Name);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var song = Playlist.SelectedItems[0] as Song;
            MediaPlayer.Source = new Uri($"{song.Path}");
            MediaPlayer.Play(); DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position += TimeSpan.FromMinutes(1);
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (MediaElement.NaturalDuration.HasTimeSpan)
            {
                songStatus.Content = string.Format("{0} - {1}", MediaElement.Position.ToString(@"mm\:ss"), MediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
        }
    }
}