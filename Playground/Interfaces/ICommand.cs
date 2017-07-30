using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Playground.Interfaces
{
    public interface ICommand
    {
        void Execute();

        void Execute(ListBox listBox);
    }
}
