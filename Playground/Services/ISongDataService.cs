using System.Collections.Generic;
using Playground.Model;

namespace Playground.Services
{
    public interface ISongDataService
    {
        void DeleteSong(Song song);

        List<Song> GetAllSongs();

        Song GetSongDetail(int songId);
    }
}