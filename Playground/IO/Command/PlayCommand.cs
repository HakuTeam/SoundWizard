namespace Playground.IO.Command
{
    using Playground.Model;
    using System.Collections.ObjectModel;

    public class PlayCommand : Command
    {
        public PlayCommand(ObservableCollection<Song> playList, Song currentSong)
            : base(playList, currentSong)
        {
        }

        public override void Execute()
        {
            if (true)
            {
                //this.MediaElement.Pause();
                //MainWindow.IsPlaying = true;
            }
            else
            {
              //  this.MediaElement.Play();
                //MainWindow.IsPlaying = false;
            }
        }
    }
}