namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using ViewModel;

    public class PlayCommand : Command
    {
        public PlayCommand(MediaElement mediaElement, ObservableCollection<SongViewModel> playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            if (!MainWindow.isPlaying)
            {
                this.MediaElement.Pause();
                MainWindow.isPlaying = true;
            }
            else
            {
                this.MediaElement.Play();
                MainWindow.isPlaying = false;
            }
        }
    }
}