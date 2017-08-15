namespace Playground.Services
{
    using System.Collections.Generic;
    using DAL;
    using Model;

    public class MediaDataService : IMediaDataService
    {
        private readonly IMediaRepository mediaRepository = new MediaRepository();

        public void DeleteMedia(Media media)
        {
            this.mediaRepository.DeleteMedia(media);
        }

        public List<Media> GetAllMediaElements()
        {
            return this.mediaRepository.GetAllMediaElements();
        }

        public Media GetMediaDetail(int mediaId)
        {
            return this.mediaRepository.GetMedia(mediaId);
        }
    }
}