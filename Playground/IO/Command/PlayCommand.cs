namespace Playground.IO.Command
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Model;

    public class PlayCommand : Command
    {
        public PlayCommand(MediaElement mediaElement, ObservableCollection<Song> playList)
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