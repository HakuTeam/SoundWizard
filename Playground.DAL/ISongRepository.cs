namespace Playground.DAL
{
    using System.Collections.Generic;
    using Playground.Model;

    public interface ISongRepository
    {
        Song GetSong(int songId);

        List<Song> GetAllSongs();

        void DeleteSong(Song song);
    }
}