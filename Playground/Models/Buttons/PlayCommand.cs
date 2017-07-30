using Playground.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Playground.Models
{
    public class PlayCommand : ICommand
    {
        private MediaElement mediaElement;
        //public static bool isPlaying = false;

        public PlayCommand(MediaElement mediaelement)
        {
            this.mediaElement = mediaelement;
        }

        public void Execute()
        {
            if (!MainWindow.isPlaying)
            {
                this.mediaElement.Pause();
                MainWindow.isPlaying = true;
            }
            else
            {
                this.mediaElement.Play();
                MainWindow.isPlaying = false;
            }
        }

        public void Execute(ListBox listBox)
        {
            throw new NotImplementedException();
        }
    }
}
