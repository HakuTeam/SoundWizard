namespace Playground.IO.Command
{
    using System.Windows.Controls;

    public abstract class Command
    {
        public Command(MediaElement mediaElement, ListBox playList)
        {
            this.MediaElement = mediaElement;
            this.PlayList = playList;
        }

        public ListBox PlayList { get; set; }

        public MediaElement MediaElement { get; set; }
    }
}