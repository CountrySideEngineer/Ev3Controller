using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class CommandUnExpectedResponse : Exception
    {
        #region Constructors and the Finalizer
        public CommandUnExpectedResponse() { }
        public CommandUnExpectedResponse(string message)
            : base(message) { }
        public CommandUnExpectedResponse(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }
}
