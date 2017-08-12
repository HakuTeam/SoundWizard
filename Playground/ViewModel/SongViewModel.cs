namespace Playground.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using Model;

    public class SongViewModel : INotifyPropertyChanged
    {
        Song song;

        public SongViewModel(string title, TimeSpan duration, string path, string album, string artist, string genre)
        {
            song = new Song(title, duration, path, album, artist, genre);
        }

        public string Duration
        {
            get
            {
                return $"{this.song.Duration.Hours:00}:{this.song.Duration.Minutes:00}:{this.song.Duration.Seconds:00}";
            }
        }

        public double TotalSeconds
        {
            get { return this.song.Duration.TotalSeconds; }
        }

        public string Title
        {
            get { return this.song.Title; }
        }

        public string Path
        {
            get { return this.song.Path; }
        }

        public string Album
        {
            get { return this.song.Album; }
        }

        public string Artist
        {
            get { return this.song.Artist; }
        }

        public string Genre
        {
            get { return this.song.Genre; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
