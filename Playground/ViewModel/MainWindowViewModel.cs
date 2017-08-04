using Playground.Extensions;
using Playground.IO;
using Playground.Model;
using Playground.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
