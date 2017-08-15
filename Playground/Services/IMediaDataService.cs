namespace Playground.Services
{
    using System.Collections.Generic;
    using Model;

    public interface IMediaDataService
    {
        void DeleteMedia(Media media);

        List<Media> GetAllMediaElements();

        Media GetMediaDetail(int mediaId);
    }
}