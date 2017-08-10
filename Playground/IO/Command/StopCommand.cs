namespace Playground.IO.Command
{
    using Playground.Model;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    public class StopCommand : Command
    {
        public StopCommand( ObservableCollection<Song> playList, Song currentSong)
            : base(playList, currentSong)
        {
        }

        public override void Execute()
        {
            MainWindow.isPlaying = true;
           // this.MediaElement.Stop();
        }
    }
}