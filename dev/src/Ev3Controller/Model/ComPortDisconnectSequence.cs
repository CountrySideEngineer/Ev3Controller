using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class ComPortDisconnectSequence : ComPortAccessSequence
    {
        public override object Sequence(ComPortAccess ComPortAcc)
        {
            ComPortAcc.Disconnect();

            return null;
        }
    }
}
