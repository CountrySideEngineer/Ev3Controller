using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class CommandParamException : CommandException
    {
        #region Constructors and the Finalizer
        public CommandParamException() { }
        public CommandParamException(string message)
            : base(message) { }
        public CommandParamException(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }
}