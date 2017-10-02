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
            this.SendData = SendData;
            this.RecvData = RecvData;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Sending data bffer.
        /// </summary>
        public byte[] SendData;

        /// <summary>
        /// Receiving data buffer.
        /// </summary>
        public byte[] RecvData;
        #endregion
    }
}
