using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    /// <summary>
    /// Implement each sequence to access COM port, open and close , and read and write.
    /// </summary>
    public class ComPortAccessSequence
    {
        #region Event
        public delegate void ConnectStateChangedEventHandler(object sender, ConnectStateChangedEventArgs e);
        public event ConnectStateChangedEventHandler ConnectStateChanged;
        public delegate void NotifyConnectSequenceFinishedEventHandler(object sender, EventArgs Args);
        public event NotifyConnectSequenceFinishedEventHandler NotifyConnectSequenceFinished;
        public delegate void NotifyDisconnectSequenceFinishedEventHandler(object sender, EventArgs Args);
        public event NotifyDisconnectSequenceFinishedEventHandler NotifyDisconnectSequenceFinished;
        #endregion


        #region Other methods and private properties in calling order
        /// <summary>
        /// Run sequence to open serial port.
        /// </summary>
        /// <param name="Port">Port information to open.</param>
        /// <returns></returns>
        public virtual ComPortAccess RunConnectSequence(ComPort Port)
        {
            var PortAccess = this.StartConnectSequence(Port);
            return PortAccess.Result;
        }

        /// <summary>
        /// Start task to open serial port.
        /// This task returns ComPortAccess object.
        /// </summary>
        /// <param name="Port">Port information to open.</param>
        /// <returns>ComPortAccess instance contains opened port information.</returns>
        public async Task<ComPortAccess> StartConnectSequence(ComPort Port)
        {
            ComPortAccess PortAccess = await Task.Run(() =>
            {
                //Notify the connection state changes into "Connecting".
                this.OnConnectStateChanged(
                    new ConnectStateChangedEventArgs(
                        new ConnectState(ConnectionState.Connecting)));

                ComPortAccess ComPortAcc = this.ConnectSequenceTask(Port);
                if (ComPortAcc == null)
                {
                    //Port connection failed.
                    this.OnConnectStateChanged(
                        new ConnectStateChangedEventArgs(
                            new ConnectState(ConnectionState.Disconnected)));
                }
                else
                {
                    //Port connection succeeded.
                    this.OnConnectStateChanged(
                        new ConnectStateChangedEventArgs(
                            new ConnectState(ConnectionState.Connected)));
                }
                return ComPortAcc;
            });
            return PortAccess;
        }

        /// <summary>
        /// Run a sequence to open serial port.
        /// </summary>
        /// <param name="Port">Port information to open.</param>
        /// <returns>ComPortAccess instance contains opened port information.</returns>
        public virtual ComPortAccess ConnectSequenceTask(ComPort Port)
        {
            ComPortAccess PortAccess = new ComPortAccess(Port);
            if (!PortAccess.Connect())
            {
                /*
                 * Failure of opening port means that the port can not access.
                 * So, no way to access port should be provided.
                 */
                PortAccess.Disconnect();
                PortAccess = null;
            }
            return PortAccess;
        }

        /// <summary>
        /// Run a sequence to disconnect, close serial port specified
        /// by argument PortAccess, ComPortAccess object.
        /// </summary>
        /// <param name="PortAccess"></param>
        public void RunDisconnectSequence(ComPortAccess PortAccess)
        {
            this.StartDisconnectSequence(PortAccess);
        }

        /// <summary>
        /// Start task to disconnect, close serial port with creating other thread to do.
        /// And after finishing the sequence, invoke event to notify the result.
        /// </summary>
        /// <param name="PortAccess"></param>
        public async void StartDisconnectSequence(ComPortAccess PortAccess)
        {
            await Task.Run(() =>
            {
                //Notify the connection state changes into "Disconnecting".
                this.OnConnectStateChanged(
                    new ConnectStateChangedEventArgs(
                        new ConnectState(ConnectionState.Disconnecting)));

                this.DisconnectSequenceTask(PortAccess);

                this.OnConnectStateChanged(
                    new ConnectStateChangedEventArgs(
                        new ConnectState(ConnectionState.Disconnected)));
            });
        }

        /// <summary>
        /// Run a sequence to disconnect, close serial port.
        /// </summary>
        /// <param name="PortAccess"></param>
        public virtual void DisconnectSequenceTask(ComPortAccess PortAccess)
        {
            PortAccess.Disconnect();
        }

        /// <summary>
        /// Raise ConnectStateChanged event, using specified information as
        /// eventual connection state.
        /// </summary>
        /// <param name="e">Detail information and new connection state.</param>
        public virtual void OnConnectStateChanged(ConnectStateChangedEventArgs e)
        {
            this.ConnectStateChanged?.Invoke(this, e);
        }

        public virtual void OnNotifyConnectSequenceFinished(EventArgs e)
        {
            this.NotifyConnectSequenceFinished(this, e);
        }

        public virtual void OnNotifyDisconnectSequenceFinished(EventArgs e)
        {
            this.NotifyDisconnectSequenceFinished(this, e);
        }
        #endregion
    }
}
