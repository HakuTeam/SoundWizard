namespace Playground.IO.Command
{
    using System.Windows.Controls;
    using Playground.Interfaces;

    public class ForwardCommand : Command, IExecutable
    {
        public ForwardCommand(MediaElement mediaElement, ListBox playList)
            : base(mediaElement, playList)
        {
        }

        public void Execute()
        {
            if (this.PlayList.SelectedIndex <= this.PlayList.Items.Count - 1)
            {
                this.PlayList.SelectedIndex++;
            }
        }
    }
}