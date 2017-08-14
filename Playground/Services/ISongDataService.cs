namespace Playground.Services
{
    using System.Collections.Generic;
    using Playground.Model;

    public interface ISongDataService
    {
        void DeleteSong(Song song);

        List<Song> GetAllSongs();

        Song GetSongDetail(int songId);
    }
}