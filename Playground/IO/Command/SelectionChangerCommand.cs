namespace Playground.IO.Command
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Model;

    public class SelectionChangerCommand : Command
    {
        public SelectionChangerCommand(MediaElement mediaElement, ObservableCollection<Song> playList, ListBox listBoxView)
            : base(mediaElement, playList, listBoxView)
        {
        }

        public override void Execute()
        {
            var song = this.ListBoxView.SelectedItems[0] as Song;
            MediaElement.Source = new Uri($"{song.Path}");
            MediaElement.Play();
        }
    }
}