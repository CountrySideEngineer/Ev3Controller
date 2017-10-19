﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class Command_50_01 : Command_50
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="CommandParam"></param>
        public Command_50_01(ICommandParam CommandParam = null) : base(CommandParam) { }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Initialize command and response code, and its command name.
        /// </summary>
        protected override void Init()
        {
            this.SubCmd = 0x01;
            this.CmdLen = 0x00;

            this.SubRes = 0x01;
            this.ResLen = 0xFF;

            this.OneDataLen = 0x03;

            base.Init();
        }

        /// <summary>
        /// Setup command data for GetGyroSensor
        /// </summary>
        /// <param name="CommandParam"></param>
        protected override void SetUp(ICommandParam CommandParam)
        {
            this.CmdData[(int)COMMAND_BUFF_INDEX.COMMAND_BUFF_INDEX_CMD_DATA_LEN] = this.CmdLen;
        }
        #endregion
    }
}
