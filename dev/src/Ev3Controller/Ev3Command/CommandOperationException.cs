using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class CommandOperationException : CommandException
    {
        #region Constructors and the Finalizer
        public CommandOperationException() { }
        public CommandOperationException(string message)
            : base(message) { }
        public CommandOperationException(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }
}
