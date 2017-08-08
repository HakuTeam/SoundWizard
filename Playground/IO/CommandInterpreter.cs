namespace Playground.IO
{
    using System;
    using System.Windows.Controls;
    using Playground.Exceptions;
    using Playground.Interfaces;
    using Playground.IO.Command;

    internal class CommandInterpreter : IInterpreter
    {
        private MediaElement mediaElement;
        private ListBox playList;

        public CommandInterpreter(MediaElement mediaElement, ListBox playList)
        {
            this.mediaElement = mediaElement;
            this.playList = playList;
        }

        public void InterpretCommand(string commandName)
        {
            try
            {
                IExecutable command = this.ParseCommand(commandName);
                command.Execute();
            }
            catch (Exception)
            {
                throw new CannotParseCommandException();
            }
        }

        private IExecutable ParseCommand(string command)
        {
            switch (command)
            {
                case "PlayButton":
                    return new PlayCommand(this.mediaElement, this.playList);

                case "OpenButton":
                    return new OpenCommand(this.mediaElement, this.playList);

                case "ForwardButton":
                    return new ForwardCommand(this.mediaElement, this.playList);

                case "RewindButton":
                    return new RewindCommand(this.mediaElement, this.playList);

                case "StopButton":
                    return new StopCommand(this.mediaElement, this.playList);

                case "Playlist":
                    return new SelectionChangerCommand(this.mediaElement, this.playList);

                case "MediaPlayerPlayBack":
                    return new MediaPlaybackCommand(this.mediaElement, this.playList);

                default:
                    // You can either write custom message or use the one written in the exception class.

                    throw new InvalidCommandException();
            }
        }
    }
}