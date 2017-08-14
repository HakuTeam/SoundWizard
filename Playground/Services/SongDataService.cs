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