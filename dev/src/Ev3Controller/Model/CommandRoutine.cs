using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public abstract class CommandRoutine
    {
        public abstract bool Routine(
            ComPortAccess ComPortAcc,
            ComPortSendRecvSequence Sequence,
            int TimerCount = 0);
    }
}
