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

    public class SongViewModel : INotifyPropertyChanged
    {
        public SongViewModel(MediaElement mediaElement)
        {
            this.Playlist = new ObservableCollection<Song>();
            this.MediaElement = mediaElement;
            LoadCommands();
        }

        private void LoadCommands()
        {
            PlayCommand = new CustomCommand(PlaySong, CanPlaySong);
            OpenCommand = new CustomCommand(LoadNewSong, CanLoadNewSong);
            ExitCommand = new CustomCommand(CloseApp, CanCloseApp);
            StopCommand = new CustomCommand(StopSong, CanStopSong);
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
            OpenCommand open = new OpenCommand(Playlist, currentSong);
            open.Execute();
            if (this.Playlist.Count > 0)
            {
                currentSong = Playlist[0];
            }
        }

        private bool CanPlaySong(object obj)
        {
            return true;
        }

        public void PlaySong(object obj)
        {
            this.MediaElement.Source = new Uri(currentSong.Path);
            this.MediaElement.Play();
        }

        private MediaElement mediaElement;
        public MediaElement MediaElement
        {
            get { return mediaElement; }
            set { mediaElement = value; }
        }

        public ICommand StopCommand { get; set; }
        public ICommand PlayCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        private Song currentSong;
        public CommandInterpreter command;
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
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
