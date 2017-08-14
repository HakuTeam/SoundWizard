namespace Playground.Services
{
    using System.Collections.Generic;
    using Playground.DAL;
    using Playground.Model;

    public class MediaDataService : IMediaDataService
    {
        private IMediaRepository mediaRepository = new MediaRepository();

        public MediaDataService()
        {
            //this.mediaRepository = mediaRepository;
        }

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