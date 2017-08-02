using Playground.Interfaces;

using System;
using System.Windows.Controls;

namespace Playground.IO.Command
{
    public class StopCommand : Command, IExecutable
    {

        public StopCommand(MediaElement mediaElement, ListBox PlayList) 
            : base(mediaElement, PlayList)
        {
        }

        public void Execute()
        {
            MainWindow.isPlaying = true;
            this.MediaElement.Stop();
        }

    }
}