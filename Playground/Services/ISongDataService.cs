namespace Playground.Services
{
    using System.Collections.Generic;
    using Playground.Model;

    public interface ISongDataService
    {
        void DeleteSong(Media song);

        List<Media> GetAllSongs();

        Media GetSongDetail(int songId);
    }
}