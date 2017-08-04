namespace Playground.IO.Command
{
    using System.Windows.Controls;
    using Interfaces;
    using System.Collections.ObjectModel;
    using Playground.Model;

    public abstract class Command : IExecutable
    {
        public Command(MediaElement mediaElement, ObservableCollection<Song> playList)
        {
            this.MediaElement = mediaElement;
            this.PlayList = playList;
        }

        public ObservableCollection<Song> PlayList { get; set; }

        public MediaElement MediaElement { get; set; }

        public abstract void Execute();
    }
}