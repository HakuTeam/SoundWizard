namespace Playground.DAL
{
    using System.Collections.Generic;
    using Playground.Model;

    public interface IMediaRepository
    {
        Media GetMedia(int mediaId);

        List<Media> GetAllMediaElements();

        void DeleteMedia(Media media);
    }
}