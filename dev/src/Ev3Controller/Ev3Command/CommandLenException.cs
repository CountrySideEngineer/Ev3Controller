using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class CommandLenException : CommandException
    {
        #region Constructors and the Finalizer
        public CommandLenException() { }
        public CommandLenException(string message)
            : base(message) { }
        public CommandLenException(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }
}
