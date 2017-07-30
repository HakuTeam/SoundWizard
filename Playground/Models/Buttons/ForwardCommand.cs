using Playground.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Playground.Models.Buttons
{
    public class ForwardCommand : ICommand
    {
        private MediaElement mediaElement;

        public ForwardCommand(MediaElement mediaElement)
        {
            this.mediaElement = mediaElement;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Execute(ListBox Playlist)
        {
            if (Playlist.SelectedIndex <= Playlist.Items.Count - 1)
            {
                Playlist.SelectedIndex++;
            }
        }
    }
}
