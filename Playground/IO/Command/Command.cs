namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using Interfaces;
    using Playground.Model;

    public abstract class Command : IExecutable
    {
        protected Command(ObservableCollection<Song> playList, Song selectedSong)
        {
            this.PlayList = playList;
            this.CurrentSong = selectedSong;
        }

        public ObservableCollection<Song> PlayList { get; set; }

        public Song CurrentSong { get; set; }

        public abstract void Execute();
    }
}