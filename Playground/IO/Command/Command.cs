namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Interfaces;
    using Playground.Model;
    using System.Windows.Input;

    public abstract class Command : IExecutable
    {
        protected Command(ObservableCollection<Song> playList, Song selectedSong)
        {
            this.PlayList = playList;
            this.currentSong = selectedSong;
        }        

        public ObservableCollection<Song> PlayList { get; set; }
        public Song currentSong { get; set; }

        public abstract void Execute();
    }
}