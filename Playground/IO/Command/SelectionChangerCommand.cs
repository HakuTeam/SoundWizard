using Playground.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;

namespace Playground.IO.Command
{
    public class SelectionChangerCommand : Command
    {
        public SelectionChangerCommand(MediaElement mediaElement, ListBox playList) 
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            var song = PlayList.SelectedItems[0] as Song;
            MediaElement.Source = new Uri($"{song.Path}");
            MediaElement.Play();
        }
    }
}
