using Playground.Model;

namespace Playground.Interfaces
{
    public interface IInterpreter
    {
        void InterpretCommand(string command, Song currentSong);
    }
}