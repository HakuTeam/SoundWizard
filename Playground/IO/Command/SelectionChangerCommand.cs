namespace Playground.IO.Command
{
    using System;
    using System.Windows.Controls;
    using Playground.Model;

    public class SelectionChangerCommand : Command
    {
        public SelectionChangerCommand(MediaElement mediaElement, ListBox playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            var song = PlayList.SelectedItems[0] as Song;
            MediaElement.Source = new Uri($"{song.Path}");
            MediaElement.Play();
        }
    }
}