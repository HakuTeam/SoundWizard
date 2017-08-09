using System.Windows.Controls;

namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using ViewModel;

    internal class MediaPlaybackCommand : Command
    {
        public MediaPlaybackCommand(MediaElement mediaElement, ObservableCollection<SongViewModel> playList, ListBox listBoxView)
            : base(mediaElement, playList, listBoxView)
        {
        }

        public override void Execute()
        {
        }
    }
}