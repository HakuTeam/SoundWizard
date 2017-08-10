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
            this.MediaElement.Stop();

            if (this.ListBoxView.SelectedIndex == this.ListBoxView.Items.Count - 1)
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