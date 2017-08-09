using System.Windows.Controls;

namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using Model;

    internal class MediaPlaybackCommand : Command
    {
        public MediaPlaybackCommand(MediaElement mediaElement, ObservableCollection<Song> playList, ListBox listBoxView)
            : base(mediaElement, playList, listBoxView)
        {
        }

        public override void Execute()
        {
        }
    }
}