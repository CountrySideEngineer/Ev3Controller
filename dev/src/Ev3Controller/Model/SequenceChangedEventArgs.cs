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
        public SequenceChangedEventArgs(ConnectionState ConnectState, bool Result = true)
        {
            this.ConnectState = ConnectState;
            this.SequenceChangedResult = Result;
        }
        #endregion

        #region Public Properties
        public ConnectionState ConnectState { get; protected set; }

        public bool SequenceChangedResult { get; protected set; }
        #endregion
    }
}
