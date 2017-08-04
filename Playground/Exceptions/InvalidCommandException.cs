namespace Playground.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
