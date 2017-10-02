using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    using Ev3Command;
    public class EchoBackComPortSendRecvSequence : ComPortSendRecvSequence
    {
        /// <summary>
        /// Setup command queueu contains object inherits ACommand class.
        /// </summary>
        public override void SetupCommandQueue()
        {
            this.CommandQueue.Enqueue(new Command_00_00());
        }
    }
}
