namespace SoundWizard.DAL
{
    using System.Collections.Generic;
    using Model;

    public interface IMediaRepository
    {
        Media GetMedia(int mediaId);

        List<Media> GetAllMediaElements();

        void DeleteMedia(Media media);
    }
}