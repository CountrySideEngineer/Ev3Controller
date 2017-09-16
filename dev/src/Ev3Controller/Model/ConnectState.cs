using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public enum ConnectionState
    {
        /// <summary>
        /// Device is disconnected.
        /// </summary>
        Disconnected,
        /// <summary>
        /// Canceling the connection.
        /// </summary>
        Disconnecting,
        /// <summary>
        /// Establishing device connection.
        /// </summary>
        Connecting,
        /// <summary>
        /// Established device connection.
        /// </summary>
        Connected,
        /// <summary>
        /// Sending data to device.
        /// </summary>
        Sending,
        /// <summary>
        /// Receiving data from device.
        /// </summary>
        Receiving,
        /// <summary>
        /// Connection state with device is unknown.
        /// </summary>
        Unknown,
    };

    /// <summary>
    /// Represents the connection state with device.
    /// </summary>
    public class ConnectState
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="State">Connection state to set to State property.</param>
        public ConnectState(ConnectionState State)
        {
            this.State = State;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Represent state of connection with device.
        /// </summary>
        public ConnectionState State { get; protected set; }
        #endregion
    }
}
