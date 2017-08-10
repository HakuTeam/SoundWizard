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
    using System.Linq;
    using Playground.Model;

    public class OpenCommand : Command
    {
        public OpenCommand(ObservableCollection<Song> playList, Song currentSong)
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
                foreach (var songPath in filename)
                {
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
                        TagLib.File fileInfo = TagLib.File.Create(songPath);

                        string songName = Path.GetFileNameWithoutExtension(songPath);
                        string genre = fileInfo.Tag.Genres.FirstOrDefault();
                        string album = fileInfo.Tag.Album;
                        string artist = fileInfo.Tag.AlbumArtists.FirstOrDefault();

                        Song song = new Song(songName, songDuration, songPath, album, artist, genre); 

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