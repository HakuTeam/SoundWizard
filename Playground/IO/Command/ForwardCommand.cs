namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Model;

    public class ForwardCommand : Command
    {
        public ForwardCommand(MediaElement mediaElement, ObservableCollection<Song> playList, ListBox listBoxView)
            : base(mediaElement, playList, listBoxView)
        {
        }

        public override void Execute()
        {
            if (this.ListBoxView.SelectedIndex <= this.PlayList.Count - 1)
            {
                this.ListBoxView.SelectedIndex++;
            }
        }
    }
}