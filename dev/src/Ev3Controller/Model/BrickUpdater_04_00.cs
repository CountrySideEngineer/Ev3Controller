using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_04_00 : BrickUpdater
    {
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_04_00)
            {
                short Voltage =(short)(ushort)
                    ((ushort)Command.ResData[4] + ((ushort)Command.ResData[5] << 8));
                short Current = (short)(ushort)
                    ((ushort)Command.ResData[6] + ((ushort)Command.ResData[7] << 8));

                Brick.Battery.Voltage = Voltage;
                Brick.Battery.Current = Current;
            }
        }
    }
}
