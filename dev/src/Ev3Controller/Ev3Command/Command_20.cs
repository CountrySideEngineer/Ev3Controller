using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public abstract class Command_20 : ACommand_ResLenFlex
    {
        #region Constructors and the Finalizer
        public Command_20(ICommandParam CommandParam) : base(CommandParam) { }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Initialize command and response code, and its command name.
        /// </summary>
        protected override void Init()
        {
            this.Name = "GetSonicSensor";
            this.Cmd = 0x20;
            this.Res = 0x21;

            base.Init();
        }

        /// <summary>
        /// Check whether size of response data buffer and length set in reponse data, 
        /// calcurated data lenght from the number of device in the data, matche.
        /// (To be more precise, the size is 4 byte more than the length.)
        /// If they are not match, CommandLenException will be thrown.
        /// </summary>
        /// <param name="OptDataIndex">Index of option data.</param>
        /// <returns>Length written in response data.</returns>
        protected override int CheckLen()
        {
            int ResLen = base.CheckLen();
            int DataIndex = (int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_DATA_TOP;
            int DevNum = this.ResData[DataIndex];

            if (ResLen != (DevNum * this.OneDataLen) + 1)
            {
                throw new CommandLenException(
                        "Command or response data Len error",
                        this.Cmd, this.SubCmd, this.Name);
            }
            return ResLen;
        }
        #endregion
    }
}
