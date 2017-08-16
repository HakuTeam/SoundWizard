namespace SoundWizard.Interfaces
{
    using Model;
    using System.Windows.Controls;

    public interface IMainViewModel
    {
        bool Repeat { get; }

        Media CurrentMedia { get; }

        MediaElement MediaElement { get; }
    }
}
