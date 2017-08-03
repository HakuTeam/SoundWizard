namespace Playground.IO.Command
{
    using System.Windows.Controls;

    public class StopCommand : Command
    {
        public StopCommand(MediaElement mediaElement, ListBox playList)
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