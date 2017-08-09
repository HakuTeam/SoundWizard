namespace Playground.IO
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Command;
    using Exceptions;
    using Interfaces;
    using Model;

    internal class CommandInterpreter : IInterpreter
    {
        private MediaElement mediaElement;
        private ObservableCollection<Song> playList;
        private ListBox ListBoxView;

        public CommandInterpreter(MediaElement mediaElement, ObservableCollection<Song> playList, ListBox listBoxView)
        {
            this.mediaElement = mediaElement;
            this.playList = playList;
            this.ListBoxView = listBoxView;
        }

        public void InterpretCommand(string commandName)
        {
            try
            {
                IExecutable command = this.ParseCommand(commandName);
                command.Execute();
            }
            catch (Exception e)
            {
                // You can either write custom message or use the one written in the exception class.
                throw new CannotParseCommandException($"{e.Message}");
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
                    return new ForwardCommand(this.mediaElement, this.playList, this.ListBoxView);

                case "RewindButton":
                    return new RewindCommand(this.mediaElement, this.playList, this.ListBoxView);

                case "StopButton":
                    return new StopCommand(this.mediaElement, this.playList);

                case "Playlist":
                    return new SelectionChangerCommand(this.mediaElement, this.playList, this.ListBoxView);

                case "MediaPlayerPlayBack":
                    return new MediaPlaybackCommand(this.mediaElement, this.playList, this.ListBoxView);

                default:
                    // You can either write custom message or use the one written in the exception class.

                    throw new InvalidCommandException();
            }
        }
    }
}