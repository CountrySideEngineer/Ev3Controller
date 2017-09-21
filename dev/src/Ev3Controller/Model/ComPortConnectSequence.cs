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
            this.StateMessageDictionary = new Dictionary<StateIndex, MessageInformation>
            {
                { StateIndex.STATE_INDEX_STARTING, new MessageInformation(true, "Connecting") },
                { StateIndex.STATE_INDEX_STARTED,  new MessageInformation(true, "Connecting") },
                { StateIndex.STATE_INDEX_FINISHED, new MessageInformation(true, "Connected") },
            };
        }

        /// <summary>
        /// A sequence to connect port.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override object Sequence(ComPortAccess ComPortAcc)
        {
            return ComPortAcc.Connect();
        }
        #endregion
    }
}
