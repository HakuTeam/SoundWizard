namespace Playground.Exceptions
{
    using System;

    public class CannotParseCommandException : Exception
    {
        private const string CannotParseCOmmand = "InterpretCommand - Cannot parse command";

        public CannotParseCommandException()
            : base(CannotParseCOmmand)
        {
        }

        public CannotParseCommandException(string message) :
            base(message)
        {
        }
    }
}