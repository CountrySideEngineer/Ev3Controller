using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
        #region Private fields and constants (in a region)
        protected static Dictionary<ConnectionState, BitmapImage> ResourceDictionary = 
            new Dictionary<ConnectionState, BitmapImage>
        {
            { ConnectionState.Disconnected,
                new BitmapImage(
                    new Uri(@"../Resource/pict/disconnected.png", UriKind.Relative)) },
            { ConnectionState.Disconnecting,
                new BitmapImage(
                    new Uri(@"../Resource/pict/disconnecting.png", UriKind.Relative)) },
            { ConnectionState.Connecting,
                new BitmapImage(
                    new Uri(@"../Resource/pict/connecting.png", UriKind.Relative)) },
            { ConnectionState.Connected,
                new BitmapImage(
                    new Uri(@"../Resource/pict/connected.png", UriKind.Relative)) },
            { ConnectionState.Sending,
                new BitmapImage(
                    new Uri(@"../Resource/pict/connected.png", UriKind.Relative)) },
            { ConnectionState.Receiving,
                new BitmapImage(
                    new Uri(@"../Resource/pict/connected.png", UriKind.Relative)) },
            { ConnectionState.Unknown,
                new BitmapImage(
                    new Uri(@"../Resource/pict/disconnected.png", UriKind.Relative)) },
        };
        #endregion

        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="State">Connection state to set to State property.</param>
        public ConnectState(ConnectionState State)
        {
            this.State = State;
            this.StateImage = ConnectState.ResourceDictionary[this.State];
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Represent state of connection with device.
        /// </summary>
        public ConnectionState State { get; protected set; }

        /// <summary>
        /// Bitmap image which shows state.
        /// </summary>
        public BitmapImage StateImage { get; protected set; }
        #endregion

        #region Other methods and private properties in calling order.
        #endregion
    }
}
