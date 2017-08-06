namespace Playground.IO.Command
{
    using System;
    using System.Text;
    using System.Windows.Controls;
    using Microsoft.Win32;
    using Playground.Enums;
    using Playground.Model;
    using Microsoft.WindowsAPICodePack.Shell;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Playground.Services;

    public class OpenCommand : Command
    {
        public OpenCommand(MediaElement mediaElement, ObservableCollection<Song> playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.DefaultExt = ".mp3";
            fileDialog.Filter = this.AudioFormater();
            Nullable<bool> result = fileDialog.ShowDialog();

            if (result == true)
            {
                string[] filename = fileDialog.FileNames;
                foreach (var songPath in filename)
                {
                    ShellFile songFile = ShellFile.FromFilePath(songPath);
                    int extensionDotIndex = songFile.Name.LastIndexOf('.');
                    string songName = songFile.Name.Substring(0, extensionDotIndex);

                    // System.Media.Duration is in 100nS (hundreds of nanoseconds) => 1sec = 10 000 000 100nS
                    int songDuraitonSeconds = (int)(songFile.Properties.System.Media.Duration.Value / 10000000);

                    TimeSpan songDuration = TimeSpan.FromSeconds(songDuraitonSeconds);

                    Song song = new Song(songName, songDuration, songPath);

                    this.PlayList.Add(song);
                }
            }
        }

        private string AudioFormater()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("All Supported Audio | ");
            foreach (AudioFormats type in Enum.GetValues(typeof(AudioFormats)))
            {
                sb.Append($"*.{type}; ");
            }

            foreach (AudioFormats type in Enum.GetValues(typeof(AudioFormats)))
            {
                sb.Append($"|{type}s |*.{type}");
            }

            return sb.ToString().Trim();
        }
    }
}