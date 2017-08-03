namespace Playground.IO.Command
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using Playground.Interfaces;

    public class ForwardCommand : Command, IExecutable
    {
        public ForwardCommand(MediaElement mediaElement, ListBox playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            if (this.PlayList.SelectedIndex <= this.PlayList.Items.Count - 1)
            {
                this.PlayList.SelectedIndex++;
            }
        }
    }
}