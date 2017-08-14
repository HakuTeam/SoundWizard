namespace Playground.Interfaces
{
    using Playground.Model;

    public interface IInterpreter
    {
        void InterpretCommand(string command, Media currentSong);
    }
}