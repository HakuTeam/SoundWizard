namespace Playground.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using Model;
    using System.Collections.ObjectModel;
    using Playground.IO;
    using System.Windows.Input;
    using Playground.Utility;
    using System.Windows.Controls;
    using System.Text;
    using Playground.Enums;
    using NAudio.Wave;
    using Playground.IO.Command;
    using System.Windows;

    public class SongViewModel 
    {
        private MediaElement mediaElement;
        private Song currentSong;

        public SongViewModel(MediaElement mediaElement, ListBox listBox)
        {
            this.Playlist = new ObservableCollection<Song>();
            this.MediaElement = mediaElement;
            this.ListBox = listBox;
            LoadCommands();
        }

        public bool Repeat { get; set; }

        public ICommand ForwardCommand { get; set; }

        public ICommand StopCommand { get; set; }

        public ICommand PlayCommand { get; set; }

        public ICommand OpenCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public ICommand RewindCommand { get; set; }

        public ListBox ListBox { get; set; }

        public ObservableCollection<Song> Playlist { get; set; }

        public Song CurrentSong
        {
            get
            {
                return this.currentSong;
            }
            set
            {
                this.currentSong = value;
            }
        }

        public MediaElement MediaElement
        {
            get { return mediaElement; }
            set { mediaElement = value; }
        }

        private void LoadCommands()
        {
            PlayCommand = new CustomCommand(PlaySong, CanPlaySong);
            OpenCommand = new CustomCommand(LoadNewSong, CanLoadNewSong);
            ExitCommand = new CustomCommand(CloseApp, CanCloseApp);
            StopCommand = new CustomCommand(StopSong, CanStopSong);
            RewindCommand = new CustomCommand(RewindLoop, CanRewindLoop);
            ForwardCommand = new CustomCommand(ForwardLoop, CanForwardLoop);
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

        private bool CanStopSong(object obj)
        {
            return true;
        }

        private void StopSong(object obj)
        {
            MainWindow.isPlaying = true;
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

        private bool CanLoadNewSong(object obj)
        {
            return true;
        }

        private void LoadNewSong(object obj)
        {
            bool firstLoad = false;
            if (this.Playlist.Count == 0)
            {
                firstLoad = true;
            }
            OpenCommand open = new OpenCommand(Playlist, currentSong);
            open.Execute();
            if (firstLoad && this.Playlist.Count > 0)
            {
                this.CurrentSong = this.Playlist[0];
                this.ListBox.SelectedIndex = 0;
                mediaElement.Pause();
            }
        }

        private bool CanPlaySong(object obj)
        {

            return this.Playlist.Count > 0;
        }

        public void PlaySong(object obj)
        {
            this.MediaElement.Source = new Uri(currentSong.Path);
            this.MediaElement.Play();
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
