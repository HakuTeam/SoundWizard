namespace Playground.IO.Command
{
    using Playground.Interfaces;
    using System.Windows.Controls;

    public class PlayCommand : Command, IExecutable
    {
        public PlayCommand(MediaElement mediaElement, ListBox playList)
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