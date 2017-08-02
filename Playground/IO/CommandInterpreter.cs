using Playground.Interfaces;
using Playground.IO.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Playground.IO
{
    class CommandInterpreter : IInterpreter
    {
        private MediaElement mediaElement;
        private ListBox playList;

        public CommandInterpreter(MediaElement mediaElement, ListBox PlayList)
        {
            this.mediaElement = mediaElement;
            this.playList = PlayList;
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
                throw new ArgumentException("Cannot parse command");
            }
        }

        private IExecutable ParseCommand(string command)
        {
            switch (command)
            {
                case "PlayButton":
                    return new PlayCommand(mediaElement, playList);
                case "OpenButton":
                    return new OpenCommand(mediaElement, playList);
                case "ForwardButton":
                    return new ForwardCommand(mediaElement, playList);
                case "RewindButton":
                    return new RewindCommand(mediaElement, playList);
                case "StopButton":
                    return new StopCommand(mediaElement, playList);
                default:
                    throw new ArgumentException("Invalid Command");
            }
        }
    }
}