namespace Playground.Model
{
    using System;
    using System.Text;
    using Interfaces;

    public class Media : IMedia, IMediaMetaData
    {
        public Media(string title, TimeSpan duration, string path, string album, string artist, string genre)
        {
            this.Title = title;
            this.Duration = duration;
            this.Path = path;
            this.Album = album;
            this.Artist = artist;
            this.Genre = genre;
        }

        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }

        public string DurationFormated
        {
            get { return $"{Duration.Hours:00}:{Duration.Minutes:00}:{Duration.Seconds:00}"; }
        }

        public string Path { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.Title);
            result.Append($" {Duration:g}");

            return result.ToString();
        }
    }
}