using System.Windows.Controls;

namespace Playground.IO.Command
{
    internal class MediaPlaybackCommand : Command
    {
        public MediaPlaybackCommand(MediaElement mediaElement, ListBox playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            this.MediaElement.Stop();

            if (this.PlayList.SelectedIndex == this.PlayList.Items.Count - 1)
            {
                this.PlayList.SelectedIndex = 0;
            }
            else
            {
                this.PlayList.SelectedIndex++;
            }

            this.MediaElement.Play();
        }
    }
}