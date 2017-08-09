namespace Playground.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Playground.Model;
    using Playground.Services;

    public class MainWindowViewModel
    {
        private MediaElement mediaElement;
        private SongDataService songDataService = new SongDataService();
        public ObservableCollection<Song> PlayList { get; set; }

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