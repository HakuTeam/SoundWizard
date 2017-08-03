namespace Playground.IO.Command
{
    using System;
    using System.Windows.Controls;
    using Microsoft.Win32;
    using Microsoft.WindowsAPICodePack.Shell;
    using Playground.Core;

    public class OpenCommand : Command
    {
        public OpenCommand(MediaElement mediaElement, ListBox PlayList)
            : base(mediaElement, PlayList)
        {
        }

        public override void Execute()
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
                    int extensionDotIndex = songFile.Name.LastIndexOf('.');
                    string songName = songFile.Name.Substring(0, extensionDotIndex);

                    // System.Media.Duration is in 100nS (hundreds of nanoseconds) => 1sec = 10 000 000 100nS
                    int songDuraitonSeconds = (int)(songFile.Properties.System.Media.Duration.Value / 10000000);

                    TimeSpan songDuration = TimeSpan.FromSeconds(songDuraitonSeconds);

                    Song song = new Song(songName, songDuration, songPath);

                    PlayList.Items.Add(song);
                }
            }
        }
    }
}