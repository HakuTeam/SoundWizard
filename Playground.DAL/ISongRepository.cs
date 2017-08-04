using Playground.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.DAL
{
    public interface ISongRepository
    {
        List<Song> songs { get; }
        Song GetSong();
        List<Song> GetAllSongs();
        void DeleteSong(Song song);
    }
}
