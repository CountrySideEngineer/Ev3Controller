using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public abstract class Command_0E : ACommand
    {
        #region Other methods and private properties in calling order
        /// <summary>
        /// Initialize command and response code, and its command name.
        /// </summary>
        protected override void Init()
        {
            this.Name = "GetSensors";

            this.Cmd = 0x0E;
            this.Res = 0x0F;

            base.Init();
        }
        #endregion
    }
}
