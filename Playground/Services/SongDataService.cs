using Playground.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Model;

namespace Playground.Services
{
    public class SongDataService : ISongDataService
    {
        ISongRepository songRepository = new SongRepository();

        public SongDataService()
        {
            this.songRepository = songRepository;
        }

        public void DeleteSong(Song song)
        {
            this.songRepository.DeleteSong(song);
        }

        public List<Song> GetAllSongs()
        {
            return this.songRepository.GetAllSongs();
        }

        public Song GetSongDetail(int songId)
        {
            return this.songRepository.GetSong(songId);
        }
    }
}
