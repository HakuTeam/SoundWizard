namespace Playground.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Model;
    using NAudio.Wave;
    using Playground.Enums;
    using Playground.IO.Command;
    using Playground.Utility;

    public class MainViewModel
    {
        private MediaElement mediaElement;
        private Media currentMedia;

        public MainViewModel(MediaElement mediaElement, ListBox listBox)
        {
            this.Playlist = new ObservableCollection<Media>();
            this.MediaElement = mediaElement;
            this.ListBox = listBox;
            this.LoadCommands();
            mediaElement.MediaEnded += new RoutedEventHandler(LoopMediaEnded);
        }

        public bool Repeat { get; set; }

        public ICommand ForwardCommand { get; set; }

        public ICommand StopCommand { get; set; }

        public ICommand PlayCommand { get; set; }

        public ICommand OpenCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public ICommand RewindCommand { get; set; }

        public ICommand FullScreenCommand { get; set; }

        public ListBox ListBox { get; set; }

        public ObservableCollection<Media> Playlist { get; set; }

        public Media CurrentMedia
        {
            get
            {
                return this.currentMedia;
            }
            set
            {
                this.currentMedia = value;
            }
        }

        public MediaElement MediaElement
        {
            get { return this.mediaElement; }
            set { this.mediaElement = value; }
        }

        public void PlayMedia(object obj)
        {
            this.MediaElement.Source = new Uri(this.currentMedia.Path);
            this.MediaElement.Play();
        }

        private void LoadCommands()
        {
            this.PlayCommand = new CustomCommand(this.PlayMedia, this.CanPlayMedia);
            this.OpenCommand = new CustomCommand(this.LoadNewMedia, this.CanLoadNewMedia);
            this.ExitCommand = new CustomCommand(this.CloseApp, this.CanCloseApp);
            this.StopCommand = new CustomCommand(this.StopMedia, this.CanStopMedia);
            this.RewindCommand = new CustomCommand(this.RewindLoop, this.CanRewindLoop);
            this.ForwardCommand = new CustomCommand(this.ForwardLoop, this.CanForwardLoop);
            this.FullScreenCommand = new CustomCommand(this.FullScreen, this.CanFullScreen);
        }

        private bool CanFullScreen(object obj)
        {
            return true;
        }

        private void FullScreen(object obj)
        {
            var currentWin = obj as Window;
            currentWin.WindowStyle = WindowStyle.None;
            this.MediaElement.MaxWidth = SystemParameters.PrimaryScreenWidth;
            this.MediaElement.MaxHeight = SystemParameters.PrimaryScreenHeight;
            this.MediaElement.Width = SystemParameters.PrimaryScreenWidth;
            this.MediaElement.Height = SystemParameters.PrimaryScreenHeight;
            currentWin.Width = SystemParameters.PrimaryScreenWidth;
            currentWin.Height = SystemParameters.PrimaryScreenHeight;
            currentWin.WindowState = WindowState.Maximized;
            this.MediaElement.Margin = new Thickness(0, 0, 0, 0);
        }

        private bool CanForwardLoop(object obj)
        {
            return (this.ListBox.SelectedIndex < this.Playlist.Count - 1 || this.Repeat) && this.Playlist.Count != 0;
        }

        private void ForwardLoop(object obj)
        {
            if (this.ListBox.SelectedIndex == this.Playlist.Count - 1 && this.Repeat)
            {
                this.ListBox.SelectedIndex = 0;
            }
            else
            {
                this.ListBox.SelectedIndex++;
            }
        }

        private bool CanRewindLoop(object obj)
        {
            return (this.ListBox.SelectedIndex != 0 || this.Repeat) && this.Playlist.Count > 0;
        }

        private void RewindLoop(object obj)
        {
            if (this.ListBox.SelectedIndex == 0 && this.Repeat)
            {
                this.ListBox.SelectedIndex = this.Playlist.Count - 1;
            }
            else
            {
                this.ListBox.SelectedIndex--;
            }
        }

        private bool CanStopMedia(object obj)
        {
            return true;
        }

        private void StopMedia(object obj)
        {
            this.MediaElement.Stop();
        }

        private bool CanCloseApp(object obj)
        {
            if (Application.Current != null)
            {
                return true;
            }

            return false;
        }

        private void CloseApp(object obj)
        {
            Application.Current.Shutdown();
        }

        private bool CanLoadNewMedia(object obj)
        {
            return true;
        }

        private void LoadNewMedia(object obj)
        {
            bool firstLoad = false;
            if (this.Playlist.Count == 0)
            {
                firstLoad = true;
            }

            OpenCommand open = new OpenCommand(this.Playlist, this.currentMedia);
            open.Execute();
            if (firstLoad && this.Playlist.Count > 0)
            {
                this.CurrentMedia = this.Playlist[0];
                this.ListBox.SelectedIndex = 0;
                this.mediaElement.Pause();
            }
        }

        private bool CanPlayMedia(object obj)
        {
            return this.Playlist.Count > 0;
        }

        private string AudioFormater()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("All Supported Audio | ");
            foreach (MediaFormats type in Enum.GetValues(typeof(MediaFormats)))
            {
                sb.Append($"*.{type}; ");
            }

            foreach (MediaFormats type in Enum.GetValues(typeof(MediaFormats)))
            {
                sb.Append($"|{type}s |*.{type}");
            }

            return sb.ToString().Trim();
        }

        private TimeSpan GetMediaDurationInSeconds(string filePath)
        {
            MediaFoundationReader audioReader = new MediaFoundationReader(filePath);

            return audioReader.TotalTime;
        }

        private void LoopMediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();

            if (ListBox.SelectedIndex == this.ListBox.Items.Count - 1)
            {
                if (CanForwardLoop(sender))
                {
                    ListBox.SelectedIndex = 0;
                }
                else
                {
                    return;
                }
            }
            else
            {
                ListBox.SelectedIndex++;
            }

            mediaElement.Play();
        }
    }
}