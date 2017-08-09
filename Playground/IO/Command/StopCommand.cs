namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using ViewModel;

    public class StopCommand : Command
    {
        public StopCommand(MediaElement mediaElement, ObservableCollection<SongViewModel> playList)
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