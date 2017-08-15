namespace Playground.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class MediaRepository : IMediaRepository
    {
        private readonly List<Media> medias;

        public MediaRepository()
        {
            this.medias = new List<Media>();
            this.medias.Add(new Media("Dummy Media", TimeSpan.FromSeconds(55), "Dummy path", "Dummy Album", "Dummy Artist", "Dummy genre"));
        }

        public Media GetMedia(int mediaId)
        {
            return this.medias.ElementAtOrDefault(mediaId);
        }

        public List<Media> GetAllMediaElements()
        {
            return this.medias;
        }

        public void DeleteMedia(Media media)
        {
            this.medias.Remove(media);
        }
    }
}