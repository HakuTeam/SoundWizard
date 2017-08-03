namespace Playground.IO.Command
{
    using Playground.Interfaces;
    using System.Windows.Controls;

    public class StopCommand : Command, IExecutable
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