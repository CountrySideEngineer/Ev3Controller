using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_A0_00 : BrickUpdater
    {
        /// <summary>
        /// Update safe state of Ev3 Brick sent by GetSafeState command.
        /// </summary>
        /// <param name="Command">GetSafeState command data.</param>
        /// <param name="Brick">Ev3Brick object to received data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_A0_00)
            {
                int DataTopIndex = 4;
                byte SafeState = Command.ResData[DataTopIndex];

                switch (SafeState)
                {
                    case 0x00:
                        Brick.State.State = Model.SafeState.SAFE_STATE.SAFE_STATE_SAFE;
                        break;

                    case 0x01:
                        Brick.State.State = Model.SafeState.SAFE_STATE.SAFE_STATE_ATTN;
                        break;

                    case 0x02:
                        Brick.State.State = Model.SafeState.SAFE_STATE.SAFE_STATE_WARN;
                        break;

                    case 0x03:
                        Brick.State.State = Model.SafeState.SAFE_STATE.SAFE_STATE_STOP;
                        break;

                    default:
                        Brick.State.State = Model.SafeState.SAFE_STATE.SAFE_STATE_UNKNOWN;
                        break;
                }
            }
        }
    }
}
