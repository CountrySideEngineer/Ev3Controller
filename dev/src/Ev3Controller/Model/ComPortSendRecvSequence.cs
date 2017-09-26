using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    using Ev3Command;

    public abstract class ComPortSendRecvSequence : ComPortAccessSequence
    {
        #region Public Properties
        /// <summary>
        /// Command queue to send in Sequence method.
        /// </summary>
        public Queue<ACommand> CommandQueue;
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Initialize the class.
        /// </summary>
        protected override void Init()
        {
            this.StateMessageDictionary = new Dictionary<StateIndex, MessageInformation>
            {
                { StateIndex.STATE_INDEX_STARTING,
                    new MessageInformation(true, "Starting send and receive sequence.") },
                { StateIndex.STATE_INDEX_STARTED,
                    new MessageInformation(true, "Started send and receive sequence.") },
                { StateIndex.STATE_INDEX_FINISHED,
                    new MessageInformation(true, "Finished send and receive sequence.") },
            };

            this.CommandQueue = new Queue<ACommand>();
            this.SetupCommandQueue();
        }

        /// <summary>
        /// Setup command queueu contains object inherits ACommand class.
        /// </summary>
        public abstract void SetupCommandQueue();

        /// <summary>
        /// A sequence to send and receive command. This sequence continues
        /// semi-permanently, till the sequence is stopped by action.
        /// </summary>
        /// <param name="ComPortAcc">Port information to access serial port.</param>
        /// <returns>Always null.</returns>
        public override object Sequence(ComPortAccess ComPortAcc)
        {
            this.IsRunning = true;
            this.DoesContinue = true;

            while (this.DoesContinue)
            {
                foreach (ACommand Command in this.CommandQueue)
                {
                    ComPortAcc.SendAndRecv(Command.CmdData, Command.ResData);
                }
            }
            this.IsRunning = false;

            return null;
        }
        #endregion
    }
}
