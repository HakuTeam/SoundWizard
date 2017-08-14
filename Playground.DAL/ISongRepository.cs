namespace Playground.DAL
{
    using System.Collections.Generic;
    using Playground.Model;

    public interface ISongRepository
    {
        Media GetSong(int songId);

        List<Media> GetAllSongs();

        void DeleteSong(Media song);
    }
}