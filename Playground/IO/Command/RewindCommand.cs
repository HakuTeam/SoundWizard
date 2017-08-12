namespace Playground.IO.Command
{
    using Playground.Model;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    internal class RewindCommand : Command
    {
        public RewindCommand(ObservableCollection<Song> playList, Song currentSong)
            : base(playList, currentSong)
        {
        }

        public override void Execute()
        {
           
        }
    }
}