using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class NotifyCommandException : EventArgs
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor of NotifyCommandException.
        /// </summary>
        /// <param name="Exp">Exception data to notify.</param>
        public NotifyCommandException(Exception Exp)
        {
            this.Except = Exp;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Exception containts information about command.
        /// </summary>
        public Exception Except { get; protected set; }
        #endregion
    }
}
