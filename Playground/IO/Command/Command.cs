using Playground.Interfaces;
using System.Collections.Generic;
using System;
using System.Windows.Controls;

namespace Playground.IO.Command
{
    public abstract class Command 
    {

        public Command(MediaElement mediaElement, ListBox PlayList)
        {
            this.MediaElement = mediaElement;
            this.PlayList = PlayList;
        }

        public ListBox PlayList { get; set; }
        public MediaElement MediaElement { get; set; }
    }
}