using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class ConnectStateChangedEventArgs : EventArgs
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="OldValue">Old value of connection state with device.</param>
        /// <param name="NewValue">New value of connection state with device.</param>
        public ConnectStateChangedEventArgs(ConnectState OldValue, ConnectState NewValue)
        {
            this.OldValue = OldValue;
            this.NewValue = NewValue;
        }

        /// <summary>
        /// Constructor with one argument, represents new connection state, NewValue
        /// </summary>
        /// <param name="NewValue">Connection state after event fired.</param>
        public ConnectStateChangedEventArgs(ConnectState NewValue)
        {
            this.OldValue = new ConnectState(ConnectionState.Unknown);
            this.NewValue = NewValue;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Represent state of connection with device BEFORE the connection state changed.
        /// </summary>
        public ConnectState OldValue { get; protected set; }

        /// <summary>
        /// Represent state of connection with device AFTER the connection state changed.
        /// </summary>
        public ConnectState NewValue { get; protected set; }
        #endregion
    }
}
