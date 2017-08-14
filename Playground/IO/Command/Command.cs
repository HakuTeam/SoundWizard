namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using Interfaces;
    using Playground.Model;

    public abstract class Command : IExecutable
    {
        protected Command(ObservableCollection<Media> playList, Media selectedSong)
        {
            this.PlayList = playList;
            this.CurrentSong = selectedSong;
        }

        public ObservableCollection<Media> PlayList { get; set; }

        public Media CurrentSong { get; set; }

        public abstract void Execute();
    }
}