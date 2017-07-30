using Playground.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Playground.Models
{
    public class StopCommand : ICommand
    {
        private System.Windows.Controls.Button button;

        public void Execute()
        {
            
        }

        public void Execute(ListBox listBox)
        {
            throw new NotImplementedException();
        }
    }
}
