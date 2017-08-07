namespace Playground.Model
{
    using System;
    using System.Text;

    public class Song
    {
        public Song(string title, TimeSpan duration, string path)
        {
            this.Title = title;
            this.Duration = duration;
            this.Path = path;
        }

        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public string DurationFormated
        {
            get { return $"{this.Duration.Hours:00}:{this.Duration.Minutes:00}:{this.Duration.Seconds:00}"; }
        }

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