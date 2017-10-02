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
            this.StateMessageDictionary = new Dictionary<StateIndex, MessageInformation>
            {
                { StateIndex.STATE_INDEX_STARTING, new MessageInformation(true, "Disconnecting") },
                { StateIndex.STATE_INDEX_STARTED,  new MessageInformation(true, "Disconnecting") },
                { StateIndex.STATE_INDEX_FINISHED, new MessageInformation(true, "Disconnected") },
            };
        }

        /// <summary>
        /// A sequence to disconnect port.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override object Sequence(ComPortAccess ComPortAcc)
        {
            ComPortAcc.Disconnect();

            return null;
        }
        #endregion
    }
}
