namespace Playground.IO.Command
{
    using Playground.Model;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    public class ForwardCommand : Command
    {
        public ForwardCommand(ObservableCollection<Song> playList, Song currentSong)
            : base(playList, currentSong)
        {
        }

        public override void Execute()
        {
            
            //if (this.ListBoxView.SelectedIndex <= this.PlayList.Count - 1)
            //{
            //    this.ListBoxView.SelectedIndex++;
            //}
        }
    }
}