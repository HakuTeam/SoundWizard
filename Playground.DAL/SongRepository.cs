using Playground.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.DAL
{
    public class SongRepository
    {
        private List<Song> songs;

        public SongRepository()
        {
        }

        public Song GetSong()
        {
            return songs.FirstOrDefault();
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
