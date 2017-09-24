using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    /// <summary>
    /// Base class for exception that will be raised when the command response data contains
    /// invalid data.
    /// </summary>
    public class CommandException : Exception
    {
        #region Constructors and the Finalizer
        public CommandException() { }
        public CommandException(string message) : base(message) { }
        public CommandException(string message, Exception inner) : base(message, inner) { }
        #endregion
    }
}
