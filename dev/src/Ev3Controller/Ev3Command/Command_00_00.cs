﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class Command_00_00 : ACommand_ResLenFix
    {
        #region Other methods and private properties in calling order
        protected override void Init()
        {
            base.Init();

            this.Name = "EchoBack";
            this.Cmd = 0x00;
            this.SubCmd = 0x00;
            this.CmdLen = 0x06;

            this.Res = 0x01;
            this.SubRes = 0x00;
            this.ResLen = 0x06;
        }

        /// <summary>
        /// Setup command data for EchoBack command.
        /// </summary>
        protected override void SetUp(ICommandParam CommandParam)
        {
            this.CmdData[(int)COMMAND_BUFF_INDEX.COMMAND_BUFF_INDEX_CMD_DATA_LEN] = this.CmdLen;

            int DataIndex = (int)COMMAND_BUFF_INDEX.COMMAND_BUFF_INDEX_CMD_DATA_TOP;
            for (byte index = 0; index < this.CmdLen; index++)
            {
                this.CmdData[DataIndex + index]
                    = index;
            }
        }

        /// <summary>
        /// Check response data of EchoBack original reponse data.
        /// </summary>
        protected override void CheckParam()
        {
            int ResLen = this.ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_DATA_LEN];

            for (int index = 0; index < ResLen; index++)
            {
                if (ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_DATA_TOP + index] != index)
                {
                    throw new CommandParamException(
                        "SomeParameterInvalid",
                        this.Cmd, this.SubCmd, this.Name);
                }
            }
        }
        #endregion
    }
}
