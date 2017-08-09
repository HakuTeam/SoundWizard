namespace Playground.IO.Command
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;
    using System.Windows.Controls;
    using Enums;
    using Microsoft.Win32;
    using NAudio.Wave;
    using ViewModel;

    public class OpenCommand : Command
    {
        public OpenCommand(MediaElement mediaElement, ObservableCollection<SongViewModel> playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                DefaultExt = ".mp3",
                Filter = this.AudioFormater()
            };

            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                string[] filename = fileDialog.FileNames;
                foreach (var songPath in filename)
                {
                    string songName = Path.GetFileNameWithoutExtension(songPath);
                    int extensionDotIndex = songPath.LastIndexOf('.');
                    string extName = songPath.Substring(extensionDotIndex + 1).ToUpper();
                    if (!Enum.IsDefined(typeof(AudioFormats), extName))
                    {
                        ErrorWindow errowWindow = new ErrorWindow();
                        errowWindow.ShowDialog();
                    }
                    else
                    {
                        TimeSpan songDuration = this.GetSongDurationInSeconds(songPath);

                        SongViewModel song = new SongViewModel(songName, songDuration, songPath);

                        this.PlayList.Add(song);
                    }
                }
            }
        }

        private TimeSpan GetSongDurationInSeconds(string filePath)
        {
            MediaFoundationReader audioReader = new MediaFoundationReader(filePath);

            return audioReader.TotalTime;
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