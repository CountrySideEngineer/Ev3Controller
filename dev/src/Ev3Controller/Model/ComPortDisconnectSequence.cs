using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class ComPortDisconnectSequence : ComPortAccessSequence
    {
        #region Other methods and private properties in calling order
        protected override void Init()
        {
            this.ConnectionStateInformationDictionary = new Dictionary<StateIndex, ConnectionStateInformation>
            {
                { StateIndex.STATE_INDEX_BASE,
                    new ConnectionStateInformation(
                        true, "Connected", ConnectionState.Connected) },
                { StateIndex.STATE_INDEX_STARTING,
                    new ConnectionStateInformation(
                        true, "Disconnecting", ConnectionState.Disconnecting) },
                { StateIndex.STATE_INDEX_STARTED,
                    new ConnectionStateInformation(
                        true, "Disconnecting", ConnectionState.Disconnecting) },
                { StateIndex.STATE_INDEX_FINISHED,
                    new ConnectionStateInformation(
                        true, "Disconnected", ConnectionState.Disconnected) },
            };
        }

        /// <summary>
        /// A sequence to disconnect port.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override object Sequence(ComPortAccess ComPortAcc)
        {
            try
            {
                ComPortAcc.Disconnect();

                return null;
            }
            catch (Exception ex)
            {
                this.OnNotifyRecvExceptionEvent(new NotifyConnectExceptionEventArgs(ex));

                return null;
            }
        }
        #endregion
    }
}
