using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public class Command_04_00 : ACommand
    {
        #region Other methods and private properties in calling order
        /// <summary>
        /// Initialize command and response code, and its 
        /// </summary>
        protected override void Init()
        {
            this.Name = "GetBattery";
            this.Cmd = 0x04;
            this.SubCmd = 0x00;
            this.CmdLen = 0x00;

            this.Res = 0x05;
            this.SubRes = 0x00;
            this.ResLen = 0x04;

            base.Init();
        }
        /// <summary>
        /// Setup command data for GetBattery original response data.
        /// </summary>
        protected override void SetUp(ICommandParam CommandParam)
        {
            this.CmdData[(int)COMMAND_BUFF_INDEX.COMMAND_BUFF_INDEX_CMD_DATA_LEN] = this.CmdLen;
        }

        /// <summary>
        /// Check reponse data of AppVersion original response data.
        /// </summary>
        protected override void CheckParam()
        {
            base.CheckParam();

            int Len = this.ResData.Length;
            int ResLen = this.ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_DATA_LEN];

            if ((ResLen != this.ResLen) || (Len != ResLen + 4))
            {
                throw new CommandLenException(
                    "SomeParameterInvalid",
                    this.Cmd, this.SubCmd, this.Name);
            }
        }
        #endregion
    }
}
