namespace Playground.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Playground.Model;

    public class SongRepository : ISongRepository
    {
        private List<Media> songs;

        public SongRepository()
        {
            this.songs = new List<Media>();
            this.songs.Add(new Media("Dummy Song", TimeSpan.FromSeconds(55), "Dummy path", "Dummy Album", "Dummy Artist", "Dummy genre"));
        }

        public Media GetSong(int songId)
        {
            return this.songs.ElementAtOrDefault(songId);
        }

        public List<Media> GetAllSongs()
        {
            return this.songs;
        }

        public void DeleteSong(Media song)
        {
            this.songs.Remove(song);
        }
    }
}