namespace SoundWizard.Interfaces
{
    using Model;

    public interface IInterpreter
    {
        void InterpretCommand(string command, Media currentMedia);
    }
}