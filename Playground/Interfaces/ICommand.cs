using System.Windows.Controls;

namespace Playground.Interfaces
{
    public interface ICommand
    {
        void Execute();

        void Execute(ListBox listBox);
    }
}