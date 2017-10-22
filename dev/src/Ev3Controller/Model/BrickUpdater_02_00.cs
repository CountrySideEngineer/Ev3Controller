using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_02_00 : BrickUpdater
    {
        /// <summary>
        /// Update AppVersion property in Brick, Ev3Brick object.
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="Brick"></param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_02_00)
            {
                Brick.Version.Major = Command.ResData[4];
                Brick.Version.Minor = Command.ResData[5];
            }
        }
    }
}
