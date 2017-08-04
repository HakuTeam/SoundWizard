namespace Playground.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CannotParseCommandException : Exception
    {
        private const string CannotParseCOmmand = "InterpretCommand - Cannot parse command";

        public CannotParseCommandException()
            :base(CannotParseCOmmand)
        {
                
        }

        public CannotParseCommandException(string message):
            base(message)
        {
                
        }
    }
}
