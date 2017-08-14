namespace Playground.IO
{
    using System;
    using System.Collections.ObjectModel;
    using Command;
    using Exceptions;
    using Interfaces;
    using Playground.Model;

    public class CommandInterpreter : IInterpreter
    {
        private ObservableCollection<Media> playList;

        public CommandInterpreter(ObservableCollection<Media> playList)
        {
            this.playList = playList;
        }

        public void InterpretCommand(string commandName, Media currentSong)
        {
            try
            {
                IExecutable command = this.ParseCommand(commandName, currentSong);
                command.Execute();
            }
            catch (Exception e)
            {
                // You can either write custom message or use the one written in the exception class.
                throw new CannotParseCommandException($"{e.Message}");
            }
        }

        private IExecutable ParseCommand(string command, Media currentSong)
        {
            switch (command)
            {
                case "OpenButton":
                    return new OpenCommand(this.playList, currentSong);
  
                default:
                    // You can either write custom message or use the one written in the exception class.

                    throw new InvalidCommandException();
            }
        }
    }
}