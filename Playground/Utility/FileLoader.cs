namespace Playground.Utility
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using NAudio.Wave;
    using Playground.Enums;
    using Playground.Model;

    public class FileLoader
    {
        private string[] filePaths;
        private ObservableCollection<Song> playlist;

        public FileLoader(string[] filePaths, ObservableCollection<Song> playlist)
        {
            this.filePaths = filePaths;
            this.playlist = playlist;
        }

        public void LoadMediaFile()
        {
            foreach (var songPath in this.filePaths)
            {
                int extensionDotIndex = songPath.LastIndexOf('.');
                string extName = songPath.Substring(extensionDotIndex + 1).ToUpper();
                if (!Enum.IsDefined(typeof(MediaFormats), extName))
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

                    this.playlist.Add(song);
                }
            }
        }

        private TimeSpan GetSongDurationInSeconds(string filePath)
        {
            MediaFoundationReader audioReader = new MediaFoundationReader(filePath);

            return audioReader.TotalTime;
        }
    }
}