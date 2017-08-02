using Playground.Interfaces;
using System;
using System.Windows.Controls;

namespace Playground.IO.Command
{
    public class PlayCommand : Command, IExecutable
    {

        public PlayCommand(MediaElement mediaElement, ListBox PlayList) 
            : base(mediaElement, PlayList)
        {
        }

        //public static bool isPlaying = false;


        public void Execute()
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