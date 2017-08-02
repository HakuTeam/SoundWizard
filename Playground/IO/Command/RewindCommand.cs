using Playground.Interfaces;
using System;
using System.Windows.Controls;

namespace Playground.IO.Command
{
    internal class RewindCommand : Command, IExecutable
    {

        public RewindCommand(MediaElement mediaElement, ListBox PlayList) 
            : base(mediaElement, PlayList)
        {
        }

        public void Execute()
        {
            if (this.PlayList.SelectedIndex > 0)
            {
                this.PlayList.SelectedIndex--;
            }
        }
    }
}