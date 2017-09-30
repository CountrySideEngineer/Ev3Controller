﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class Command_0E_10 : Command_0E
    {
        #region Other methods and private properties in calling order
        protected override void Init()
        {
            this.SubCmd = 0x10;
            this.CmdLen = 0x00;

            this.SubRes = 0x10;
            this.ResLen = 0xFF;//Length of response can not be determined.

            base.Init();
        }

        /// <summary>
        /// Setup command data for GetMotors original data.
        /// </summary>
        protected override void SetUp()
        {
            this.CmdData[(int)COMMAND_BUFF_INDEX.COMMAND_BUFF_INDEX_CMD_DATA_LEN] = this.CmdLen;
        }

        /// <summary>
        /// Check reponse data of GetSensors and get ultrasonic sensor listening data.
        /// </summary>
        protected override void CheckParam()
        {
            int Len = this.ResData.Length;
            int ResLen = this.ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_DATA_LEN];
            int DevNum = this.ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_DATA_TOP];

            if ((Len != ResLen + 4) || (ResLen != ((DevNum * 2) + 1)))
            {
                throw new CommandLenException(
                    string.Format(
                        "Command or response data Len error:[Code = 0x{0:X2}-0x{1:X2} Name = {2}]",
                        this.Cmd, this.SubCmd, this.Name));
            }
            if (DevNum != 0)
            {
                int PortDataTop = (int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_DATA_TOP + 1;
                for (int index = 0; index < DevNum; index++)
                {
                    int PortIndex = PortDataTop + (index * 2);
                    int DevInfoIndex = PortDataTop + (index * 2) + 1;
                    byte Port = this.ResData[PortIndex];
                    byte IsListen = this.ResData[DevInfoIndex];
                    if (4 <= Port)
                    {
                        /*
                         * PortNumber is byte and starts 0 to 3.
                         * So, lower than 0 does not need to check.
                         */
                        throw new CommandOperationException(
                            string.Format(
                                "Invalid Port Number:[Code = {0}-{1} Name = {2}]",
                                this.Cmd, this.SubCmd, this.Name));
                    }
                    if ((IsListen != 0) && (IsListen != 1))
                    {
                        throw new CommandOperationException(
                            string.Format(
                                "Invalid listen state:[Code = {0}-{1} Name = {2}]",
                                this.Cmd, this.SubCmd, this.Name));
                    }
                }
            }
            base.CheckParam();
        }
        #endregion
    }
}
