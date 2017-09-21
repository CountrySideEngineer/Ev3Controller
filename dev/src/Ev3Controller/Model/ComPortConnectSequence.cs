using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class ComPortConnectSequence : ComPortAccessSequence
    {
        /// <summary>
        /// A sequence to connect port.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override object Sequence(ComPortAccess ComPortAcc)
        {
            return ComPortAcc.Connect();
        }
    }
}
