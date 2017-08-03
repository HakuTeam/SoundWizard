namespace Playground.IO.Command
{
    using System.Windows.Controls;

    public class ForwardCommand : Command
    {
        public ForwardCommand(MediaElement mediaElement, ListBox playList)
            : base(mediaElement, playList)
        {
        }

        public override void Execute()
        {
            if (this.PlayList.SelectedIndex <= this.PlayList.Items.Count - 1)
            {
                this.PlayList.SelectedIndex++;
            }
        }
    }
}