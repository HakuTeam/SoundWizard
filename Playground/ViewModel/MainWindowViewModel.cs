using Playground.Model;
using Playground.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Playground.ViewModel
{
    public class MainWindowViewModel
    {
        SongDataService songDataService = new SongDataService();
        public ObservableCollection<Song> PlayList { get; set; }
        private MediaElement mediaElement;

        public MainWindowViewModel()
        {
            this.PlayList = new ObservableCollection<Song>();
        }

        public MediaElement MediaElement
        {
            get { return this.mediaElement; }
            set { this.mediaElement = value; }
        }
    }
}
