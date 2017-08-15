namespace Playground.Utility
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using NAudio.Wave;
    using Playground.Enums;
    using Playground.Model;
    using Interfaces;

    public class FileLoader : IFileLoader
    {
        private string[] filePaths;
        private ObservableCollection<Media> playlist;

        public FileLoader(string[] filePaths, ObservableCollection<Media> playlist)
        {
            this.filePaths = filePaths;
            this.playlist = playlist;
        }

        public void LoadMediaFile()
        {
            foreach (var mediaPath in this.filePaths)
            {
                int extensionDotIndex = mediaPath.LastIndexOf('.');
                string extName = mediaPath.Substring(extensionDotIndex + 1).ToUpper();
                if (!Enum.IsDefined(typeof(MediaFormats), extName))
                {
                    ErrorWindow errowWindow = new ErrorWindow();
                    errowWindow.ShowDialog();
                }
                else
                {
                    TimeSpan mediaDuration = this.GetMediaDurationInSeconds(mediaPath);
                    TagLib.File fileInfo = TagLib.File.Create(mediaPath);

                    string mediaName = Path.GetFileNameWithoutExtension(mediaPath);
                    string genre = fileInfo.Tag.Genres.FirstOrDefault();
                    string album = fileInfo.Tag.Album;
                    string artist = fileInfo.Tag.AlbumArtists.FirstOrDefault();

                    Media media = new Media(mediaName, mediaDuration, mediaPath, album, artist, genre);

                    this.playlist.Add(media);
                }
            }
        }

        private TimeSpan GetMediaDurationInSeconds(string filePath)
        {
            MediaFoundationReader audioReader = new MediaFoundationReader(filePath);

            return audioReader.TotalTime;
        }
    }
}