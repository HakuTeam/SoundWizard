namespace Playground.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Playground.Model;

    public class SongRepository : ISongRepository
    {
        private List<Song> songs;

        public SongRepository()
        {
            this.songs = new List<Song>();
            this.songs.Add(new Song("Dummy Song", TimeSpan.FromSeconds(55), "Dummy path", "Dummy Album", "Dummy Artist", "Dummy genre"));
        }

        public Song GetSong(int songId)
        {
            return this.songs.ElementAtOrDefault(songId);
        }

        public List<Song> GetAllSongs()
        {
            return this.songs;
        }

        public void DeleteSong(Song song)
        {
            this.songs.Remove(song);
        }
    }
}