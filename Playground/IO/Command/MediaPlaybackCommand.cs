using System.Windows.Controls;

namespace Playground.IO.Command
{
    using Playground.Model;
    using System.Collections.ObjectModel;

    internal class MediaPlaybackCommand : Command
    {
        public MediaPlaybackCommand(ObservableCollection<Song> playList, Song currentSong)
            : base(playList, currentSong)
        {
        }

        public override void Execute()
        {
            // this.MediaElement.Stop();
           
            //if (this.ListBoxView.SelectedIndex == this.ListBoxView.Items.Count - 1)
            //{
            //    this.ListBoxView.SelectedIndex = 0;
            //}
            //else
            //{
            //    this.ListBoxView.SelectedIndex++;
            //}

           // this.MediaElement.Play();
        }
    }
}