using Playground.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Services
{
    public interface ISongDataService
    {
        void DeleteSong(Song song);
        List<Song> GetAllSongs();
        Song GetSongDetail(int songId);
    }
}
