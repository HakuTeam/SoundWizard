namespace Playground.IO.Command
{
    using System;
    using System.Windows.Controls;
    using Playground.Interfaces;

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