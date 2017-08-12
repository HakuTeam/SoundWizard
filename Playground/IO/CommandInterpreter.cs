namespace Playground.IO
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Command;
    using Exceptions;
    using Interfaces;
    using Playground.Model;

    public class CommandInterpreter : IInterpreter
    {
        private ObservableCollection<Song> playList;      

        public CommandInterpreter(ObservableCollection<Song> playList)
        {          
            this.playList = playList;
        }

        public void InterpretCommand(string commandName, Song currentSong)
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

        private IExecutable ParseCommand(string command, Song currentSong)
        {
            switch (command)
            {
                case "PlayButton":
                    return new PlayCommand(this.playList, currentSong);

                case "OpenButton":
                    return new OpenCommand(this.playList, currentSong);

                case "ForwardButton":
                    return new ForwardCommand(this.playList, currentSong);

                case "RewindButton":
                    return new RewindCommand(this.playList, currentSong);

                case "StopButton":
                    return new StopCommand(this.playList, currentSong);

                case "Playlist":
                    return new SelectionChangerCommand(this.playList, currentSong);

                case "MediaPlayerPlayBack":
                    return new MediaPlaybackCommand(this.playList, currentSong);

                default:
                    // You can either write custom message or use the one written in the exception class.

                    throw new InvalidCommandException();
            }
        }
    }
}