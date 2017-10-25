using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    class NotifyConnectExceptionEventArgs : EventArgs
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor of NotifyConnectExceptionEventArgs.
        /// </summary>
        /// <param name="Exp">Exception data to notify.</param>
        public NotifyConnectExceptionEventArgs(Exception Exp)
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
