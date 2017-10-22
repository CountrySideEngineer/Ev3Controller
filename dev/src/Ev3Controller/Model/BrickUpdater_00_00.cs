using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;

namespace Ev3Controller.Model
{
    public class BrickUpdater_00_00 : BrickUpdater
    {
        /// <summary>
        /// Update Brick data by command data, Command.
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="Brick"></param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Console.WriteLine(
                string.Format("Nothing to do when {0} command received.", Command.Name));
        }
    }
}
