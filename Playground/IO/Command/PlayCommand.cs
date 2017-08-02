namespace Playground.IO.Command
{
    using System.Windows.Controls;
    using Playground.Interfaces;

    public class PlayCommand : Command, IExecutable
    {
        public PlayCommand(MediaElement mediaElement, ListBox playList)
            : base(mediaElement, playList)
        {
        }

        //public static bool isPlaying = false;

        public void Execute()
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