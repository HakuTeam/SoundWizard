
namespace SoundWizard.Interfaces
{
    using Model;
    using System.Collections.ObjectModel;

    public interface ICommandPattern
    {
        ObservableCollection<Media> PlayList { get; set; }

        Media CurrentMedia { get; set; }
    }
}
