namespace Playground.Core
{
    using System;
    using System.Text;

    public class Song
    {
        public Song(string title, TimeSpan duration, string path)
        {
            Title = title;
            Duration = duration;
            Path = path;
        }

        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.Title);
            result.Append($" {this.Duration:g}");

            return result.ToString();
        }
    }
}