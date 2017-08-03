namespace Playground.IO.Command
{
    using System;
    using System.IO;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Microsoft.Win32;
    using Microsoft.WindowsAPICodePack.Shell;
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
                foreach (var songPath in filename)
                {
                    ShellFile songFile = ShellFile.FromFilePath(songPath);
                    int nameStartIndex = songPath.LastIndexOf('\\') + 1;
                    int extensionDotIndex = songPath.LastIndexOf('.');
                    int nameLength = extensionDotIndex - nameStartIndex;
                    string songName = songFile.Name;
                    //Mp3FileReader getSongDuration = new Mp3FileReader(item);
                    //TimeSpan time = getSongDuration.TotalTime;
                    //string duration = string.Format("{0:00}:{1:00}:{2:00}", (int)time.TotalHours, time.Minutes, time.Seconds);
                    TimeSpan songDuration = new TimeSpan(0, 0, 0, (int)(songFile.Properties.System.Media.Duration.Value / 10000000));

                    Song song = new Song(songName, songDuration, songPath);

                    PlayList.Items.Add(song);
                }
            }
        }
    }
}