namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Interfaces;
    using ViewModel;

    public abstract class Command : IExecutable
    {
        protected Command(MediaElement mediaElement, ObservableCollection<SongViewModel> playList)
        {
            this.MediaElement = mediaElement;
            this.PlayList = playList;
        }

        protected Command(MediaElement mediaElement, ObservableCollection<SongViewModel> playList, ListBox listBoxView)
        {
            this.MediaElement = mediaElement;
            this.PlayList = playList;
            this.ListBoxView = listBoxView;
        }

        public ObservableCollection<SongViewModel> PlayList { get; set; }

        public MediaElement MediaElement { get; set; }

        public ListBox ListBoxView { get; set; }

        public abstract void Execute();
    }
}