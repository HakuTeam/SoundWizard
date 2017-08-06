namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Model;

    public class StopCommand : Command
    {
        public StopCommand(MediaElement mediaElement, ObservableCollection<Song> playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            MainWindow.isPlaying = true;
            this.MediaElement.Stop();
        }
    }
}