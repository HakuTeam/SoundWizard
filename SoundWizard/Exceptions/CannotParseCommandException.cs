namespace SoundWizard.Exceptions
{
    using System;

    public class CannotParseCommandException : Exception
    {
        private const string CannotParseCommand = "InterpretCommand - Cannot parse command";

        public CannotParseCommandException()
            : base(CannotParseCommand)
        {
        }

        public CannotParseCommandException(string message) :
            base(message)
        {
        }
    }
}