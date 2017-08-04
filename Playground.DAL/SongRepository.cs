using Playground.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.DAL
{
    public class SongRepository : ISongRepository
    {
        private List<Song> songs;

        public SongRepository()
        {
        }

        public Song GetSong(int songId)
        {
            return songs.ElementAtOrDefault(songId);
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
