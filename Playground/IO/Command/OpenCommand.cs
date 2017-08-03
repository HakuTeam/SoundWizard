namespace Playground.IO.Command
{
    using System;
    using System.Windows.Controls;
    using Microsoft.Win32;
    using Playground.Core;
    using Playground.Interfaces;

    public class OpenCommand : Command, IExecutable
    {
        public OpenCommand(MediaElement mediaElement, ListBox PlayList)
            : base(mediaElement, PlayList)
        {
        }

        public void Execute()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.DefaultExt = ".mp3";
            dlg.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string[] filename = dlg.FileNames;
                foreach (var item in filename)
                {
                    var pathAndSong = item.LastIndexOf('\\');
                    var songName = item.Substring(pathAndSong + 1);
                    //Mp3FileReader getSongDuration = new Mp3FileReader(item);
                    //TimeSpan time = getSongDuration.TotalTime;
                    //string duration = string.Format("{0:00}:{1:00}:{2:00}", (int)time.TotalHours, time.Minutes, time.Seconds);
                    Song song = new Song(songName, TimeSpan.MaxValue, item);
                    PlayList.Items.Add(song);
                }
            }
        }
    }
}