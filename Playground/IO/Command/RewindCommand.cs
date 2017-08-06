namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Model;

    internal class RewindCommand : Command
    {
        public RewindCommand(MediaElement mediaElement, ObservableCollection<Song> playList, ListBox listBoxView)
            : base(mediaElement, playList, listBoxView)
        {
        }

        public override void Execute()
        {
            if (this.ListBoxView.SelectedIndex > 0)
            {
                this.ListBoxView.SelectedIndex--;
            }
        }
    }
}