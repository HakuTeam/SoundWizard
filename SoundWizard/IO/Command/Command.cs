namespace SoundWizard.IO.Command
{
    using System.Collections.ObjectModel;
    using Interfaces;
    using Model;

    public abstract class Command : ICommand, IExecutable
    {
        protected Command(ObservableCollection<Media> playList, Media selectedMedia)
        {
            this.PlayList = playList;
            this.CurrentMedia = selectedMedia;
        }

        public ObservableCollection<Media> PlayList { get; set; }

        public Media CurrentMedia { get; set; }

        public abstract void Execute();
    }
}