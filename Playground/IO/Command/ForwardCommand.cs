using Playground.Interfaces;
using System;
using System.Windows.Controls;

namespace Playground.IO.Command
{
    public class ForwardCommand : Command, IExecutable
    {

        public ForwardCommand(MediaElement mediaElement, ListBox PlayList) 
            : base(mediaElement, PlayList)
        {
        }

        public void Execute()
        {
            if (this.PlayList.SelectedIndex <= this.PlayList.Items.Count - 1)
            {
                this.PlayList.SelectedIndex++;
            }
        }
    }
}