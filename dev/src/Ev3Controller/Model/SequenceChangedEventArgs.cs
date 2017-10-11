using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class SequenceChangedEventArgs : EventArgs
    {
        #region Constructors and the Finalizer
        public SequenceChangedEventArgs(ConnectionState ConnectState)
        {
            this.ConnectState = ConnectState;
        }
        #endregion

        #region Public Properties
        public ConnectionState ConnectState { get; protected set; }
        #endregion
    }
}
