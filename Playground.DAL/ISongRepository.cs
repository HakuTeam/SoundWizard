using System.Collections.Generic;
using Playground.Model;

namespace Playground.DAL
{
    public interface ISongRepository
    {
        Song GetSong(int songId);

        List<Song> GetAllSongs();

        void DeleteSong(Song song);
    }
}