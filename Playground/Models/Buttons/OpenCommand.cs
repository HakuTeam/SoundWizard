using Microsoft.Win32;
using Playground.Core;
using Playground.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Playground.Models.Buttons
{
    internal class OpenCommand : ICommand
    {
        private MediaElement mediaelement;

        public OpenCommand(MediaElement mediaelement)
        {
            this.mediaelement = mediaelement;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Execute(ListBox Playlist)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.DefaultExt = ".mp3";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dlg.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string[] filename = dlg.FileNames;
                List<Song> playList = new List<Song>();

                Playlist.DisplayMemberPath = ToString();

                foreach (var item in filename)
                {
                    var pathAndSong = item.LastIndexOf('\\');
                    var songName = item.Substring(pathAndSong + 1);

                    Song song = new Song(songName, TimeSpan.FromMinutes(3.0), item);
                    var songItem = new ListBoxItem();

                    songItem.Content = song.Path;
                    //dsfdsfsdfd
                    Playlist.Items.Add(songItem);
                }
            }
        }
    }
}