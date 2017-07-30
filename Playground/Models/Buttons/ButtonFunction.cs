using Playground.Interfaces;
using System.Collections.Generic;

namespace Playground.Models
{
    public class ButtonFunction
    {
        //private MainWindow a = new MainWindow();
        private List<ICommand> _commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command)
        {
            _commands.Add(command);
            command.Execute();
        }
    }
}