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

    public class SongViewModel : INotifyPropertyChanged
    {
        public SongViewModel()
        {
            this.playlist = new ObservableCollection<Song>();
            this.command = new CommandInterpreter(playlist);
            LoadCommands();
        }

        private void LoadCommands()
        {
            PlayCommand = new CustomCommand(PlaySong, CanPlaySong);
        }       

        private bool CanPlaySong(object obj)
        {
            return true;
        }

        public void PlaySong(object obj)
        {
            //MediaElement play
        }

        public ICommand PlayCommand { get; set; }
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
