namespace Playground.IO.Command
{
    using Playground.Model;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    public class SelectionChangerCommand : Command
    {
        public SelectionChangerCommand( ObservableCollection<Song> playList, Song currentSong)
            : base(playList, currentSong)
        {
        }

        public override void Execute()
        {
          //  MediaElement.Source = new Uri($"{song.Path}");
           // MediaElement.Play();
        }
    }
}