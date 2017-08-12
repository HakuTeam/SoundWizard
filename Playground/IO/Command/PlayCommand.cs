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
            if (!MainWindow.isPlaying)
            {
                //this.MediaElement.Pause();
                MainWindow.isPlaying = true;
            }
            else
            {
              //  this.MediaElement.Play();
                MainWindow.isPlaying = false;
            }
        }
    }
}