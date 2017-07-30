using Playground.Interfaces;

using System;
using System.Windows.Controls;

namespace Playground.Models
{
    public class StopCommand : ICommand
    {
        private MediaElement mediaElement;

        public StopCommand(MediaElement mediaElement)
        {
            this.mediaElement = mediaElement;
        }

        public void Execute()
        {
            MainWindow.isPlaying = true;
            this.mediaElement.Stop();
        }

        public void Execute(ListBox listBox)
        {
            throw new NotImplementedException();
        }
    }
}