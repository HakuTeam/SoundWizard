namespace Playground.Models
{
    public class Song
    {
        public Song(string title, string duration, string path)
        {
            this.Title = title;
            this.Duration = duration;
            this.Path = path;
        }

        public string Title { get; set; }

        public string Duration { get; set; }

        public string Path { get; set; }
    }
}