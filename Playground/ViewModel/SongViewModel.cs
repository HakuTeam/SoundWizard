namespace Playground.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using Model;

    public class SongViewModel: INotifyPropertyChanged
    {
        Song song;

        public SongViewModel(string title, TimeSpan duration, string path)
        {
            song = new Song(title,duration,path);
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

        public string Path {
            get { return this.song.Path; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
