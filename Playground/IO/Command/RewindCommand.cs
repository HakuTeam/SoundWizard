namespace Playground.IO.Command
{
    using System;
    using System.Windows.Controls;
    using Playground.Interfaces;

    internal class RewindCommand : Command, IExecutable
    {
        public RewindCommand(MediaElement mediaElement, ListBox playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            if (this.PlayList.SelectedIndex > 0)
            {
                this.PlayList.SelectedIndex--;
            }
        }
    }
}