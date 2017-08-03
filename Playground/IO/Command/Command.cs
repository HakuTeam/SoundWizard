namespace Playground.IO.Command
{
    using Interfaces;
    using System.Windows.Controls;
    using System;

    public abstract class Command : IExecutable
    {
        public Command(MediaElement mediaElement, ListBox playList)
        {
            this.MediaElement = mediaElement;
            this.PlayList = playList;
        }

        public ListBox PlayList { get; set; }

        public MediaElement MediaElement { get; set; }

        public abstract void Execute();
    }
}