using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class ComPortConnectSequence : ComPortAccessSequence
    {
        #region Constructors and the Finalizer
        public ComPortConnectSequence() { this.Init(); }
        #endregion

        #region Other methods and private properties in calling order
        protected override void Init()
        {
            this.ConnectionStateInformationDictionary = new Dictionary<StateIndex, ConnectionStateInformation>
            {
                { StateIndex.STATE_INDEX_STARTING,
                    new ConnectionStateInformation(
                        true, "Connecting", ConnectionState.Connecting) },
                { StateIndex.STATE_INDEX_STARTED,
                    new ConnectionStateInformation(
                        true, "Connecting", ConnectionState.Connecting) },
                { StateIndex.STATE_INDEX_FINISHED,
                    new ConnectionStateInformation(
                        true, "Connected", ConnectionState.Connected) },
            };
        }

        /// <summary>
        /// A sequence to connect port.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override object Sequence(ComPortAccess ComPortAcc)
        {
            bool Result = false;
            this.IsRunning = true;

            Result = ComPortAcc.Connect();

            this.IsRunning = false;

            return Result;
        }
        #endregion
    }
}
