using Ev3Controller.Ev3Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class NotifySendReceiveDataEventArgs : EventArgs
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="SendData">Byte array contains sent data.</param>
        /// <param name="RecvData">Byte array contains received data.</param>
        public NotifySendReceiveDataEventArgs(byte[] SendData, byte[] RecvData)
        {
            this.Command = null;
            this.SendData = SendData;
            this.RecvData = RecvData;
        }
        public NotifySendReceiveDataEventArgs(ACommand Command)
        {
            this.Command = Command;
            this.SendData = this.Command.CmdData;
            this.RecvData = this.Command.ResData;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Sending data bffer.
        /// </summary>
        public byte[] SendData { get; protected set; }

        /// <summary>
        /// Receiving data buffer.
        /// </summary>
        public byte[] RecvData { get; protected set; }

        /// <summary>
        /// Send and received command data.
        /// </summary>
        public ACommand Command { get; protected set; }
        #endregion
    }
}
