namespace Playground.Interfaces
{
    using Model;

    public interface IInterpreter
    {
        void InterpretCommand(string command, Media currentMedia);
    }
}