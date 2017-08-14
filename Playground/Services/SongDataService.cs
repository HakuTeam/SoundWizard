namespace Playground.Services
{
    using System.Collections.Generic;
    using Playground.DAL;
    using Playground.Model;

    public class SongDataService : ISongDataService
    {
        private ISongRepository songRepository = new SongRepository();

        public SongDataService()
        {
            //this.songRepository = songRepository;
        }

        public void DeleteSong(Media song)
        {
            this.songRepository.DeleteSong(song);
        }

        public List<Media> GetAllSongs()
        {
            return this.songRepository.GetAllSongs();
        }

        public Media GetSongDetail(int songId)
        {
            return this.songRepository.GetSong(songId);
        }
    }
}