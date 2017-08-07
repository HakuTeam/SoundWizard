namespace Playground.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        private const string InvalidCommand = "ParseCommand - Invalid Command";

        public InvalidCommandException()
            :base(InvalidCommand)
        {
                
        }

        public InvalidCommandException(string message):
            base(message)
        {
            
        }
    }
}
