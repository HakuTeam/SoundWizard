namespace Playground.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using Model;
    using System.Collections.ObjectModel;
    using Playground.IO;
    using System.Windows.Controls;

    public class SongViewModel : INotifyPropertyChanged
    {
        public SongViewModel()
        {
            this.playlist = new ObservableCollection<Song>();
            this.command = new CommandInterpreter(playlist);
        }
        
        private Song currentSong;
        public CommandInterpreter command;
        public ObservableCollection<Song> playlist { get; set; } 
        public Song CurrentSong { get; set; }       
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
