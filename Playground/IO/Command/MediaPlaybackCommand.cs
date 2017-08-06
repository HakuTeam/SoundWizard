using System;
using System.Windows.Controls;

namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using Model;

    class MediaPlaybackCommand : Command
    {
        public MediaPlaybackCommand(MediaElement mediaElement, ObservableCollection<Song> playList, ListBox listBoxView)
            : base(mediaElement, playList, listBoxView)
        {
        }

        public override void Execute()
        {
            this.MediaElement.Stop();

            if (this.ListBoxView.SelectedIndex == this.PlayList.Count - 1)
            {
                this.ListBoxView.SelectedIndex = 0;
            }
            else
            {
                this.ListBoxView.SelectedIndex++;
            }

            this.MediaElement.Play();
        }
    }
}
