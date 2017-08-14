namespace Playground.IO.Command
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;
    using Enums;
    using Microsoft.Win32;
    using Playground.Model;
    using Utility;

    public class OpenCommand : Command
    {
        public OpenCommand(ObservableCollection<Media> playList, Media currentSong)
            : base(playList, currentSong)
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
                FileLoader fileLoader = new FileLoader(filename, this.PlayList);
                fileLoader.LoadMediaFile();
            }
        }

        private string AudioFormater()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("All Supported Audio | ");
            foreach (MediaFormats type in Enum.GetValues(typeof(MediaFormats)))
            {
                sb.Append($"*.{type}; ");
            }

            foreach (MediaFormats type in Enum.GetValues(typeof(MediaFormats)))
            {
                sb.Append($"|{type}s |*.{type}");
            }

            return sb.ToString().Trim();
        }
    }
}