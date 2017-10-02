using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command
{
    public abstract class ACommand
    {
        #region Private fields and constants (in a region)
        /// <summary>
        /// Enumlator of command data format.
        /// </summary>
        protected enum COMMAND_BUFF_INDEX
        {
            COMMAND_BUFF_INDEX_CMD_CODE,
            COMMAND_BUFF_INDEX_CMD_SUB_CODE,
            COMMAND_BUFF_INDEX_CMD_DATA_LEN,
            COMMAND_BUFF_INDEX_CMD_DATA_TOP,
        };

        /// <summary>
        /// Enumlator response data format.
        /// </summary>
        protected enum RESPONSE_BUFF_INDEX
        {
            RESPONSE_BUFF_INDEX_RES_CODE,
            RESPONSE_BUFF_INDEX_RES_SUB_CODE,
            RESPONSE_BUFF_INDEX_RES_RESULT,
            RESPONSE_BUFF_INDEX_RES_DATA_LEN,
            RESPONSE_BUFF_INDEX_RES_DATA_TOP,
        };
        #endregion

        #region 
        /// <summary>
        /// Command and response buffer size.
        /// </summary>
        public static int BUFF_SIZE = 32;
        #endregion

        #region Constructors and the Finalizer
        public ACommand()
        {
            this.Init();
            this.SetUp();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Name of command.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Command code.
        /// </summary>
        public byte Cmd { get; protected set; }

        /// <summary>
        /// Sub command code.
        /// </summary>
        public byte SubCmd { get; protected set; }

        /// <summary>
        /// Length of command parameter in command data.
        /// </summary>
        public byte CmdLen { get; protected set; }

        /// <summary>
        /// Response code.
        /// </summary>
        public byte Res { get; protected set; }

        /// <summary>
        /// Sub reponse code.
        /// </summary>
        public byte SubRes { get; protected set; }

        /// <summary>
        /// Expected length of response data len.
        /// If the value is unmatch in reponse data, a exception will be raised.
        /// And if the value is -1, this value will be not checked.
        /// </summary>
        public byte ResLen { get; protected set; }

        /// <summary>
        /// Buffer to store the data to send.
        /// </summary>
        public byte[] CmdData { get; protected set; }

        /// <summary>
        /// Buffer to store received data.
        /// </summary>
        public byte[] ResData { get; set; }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Initialize buffer and setup basic command and response data, command, sub command
        /// code, expecting response, and epecting sub response code.
        /// </summary>
        protected virtual void Init()
        {
            this.CmdData = new byte[ACommand.BUFF_SIZE];

            for (int index = 0; index < ACommand.BUFF_SIZE; index++)
            {
                this.CmdData[index] = 0x00;
            }
            this.CmdData[(int)COMMAND_BUFF_INDEX.COMMAND_BUFF_INDEX_CMD_CODE] = this.Cmd;
            this.CmdData[(int)COMMAND_BUFF_INDEX.COMMAND_BUFF_INDEX_CMD_SUB_CODE] = this.SubCmd;
        }

        /// <summary>
        /// Setup command data format.
        /// </summary>
        protected abstract void SetUp();

        /// <summary>
        /// Check response data.
        /// </summary>
        public void Check()
        {
            this.CheckRes();
            this.CheckParam();
        }

        /// <summary>
        /// Check response and sub response code.
        /// If these values are invalid, CommandUnExpected will be raised.
        /// </summary>
        protected void CheckRes()
        {
            try
            {
                byte Res = this.ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_CODE];
                byte SubRes =
                    this.ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_SUB_CODE];

                if ((Res != this.Res) || (SubRes != this.SubRes))
                {
                    throw new CommandUnExpectedResponse(
                        "CommandError",
                        this.Cmd, this.SubCmd, this.Name);
                }
            }
#pragma warning disable 0168
            catch (NullReferenceException ex)
            {
                throw new CommandNoResponseException(
                    "NoResponseReceived",
                    this.Cmd, this.SubCmd, this.Name);
            }
#pragma warning restore 0168
        }

        /// <summary>
        /// Check result code in response data.
        /// If the data is invalid, corresponding exception will be raised.
        /// </summary>
        protected virtual void CheckParam()
        {
            byte Result = this.ResData[(int)RESPONSE_BUFF_INDEX.RESPONSE_BUFF_INDEX_RES_RESULT];

            switch (Result)
            {
                case 0xFF:
                    throw new CommandOperationException(
                        "CommandError",
                        this.Cmd, this.SubCmd, this.Name);

                case 0xFE:
                    throw new CommandLenException(
                        "CommandOrResponseLenError",
                        this.Cmd, this.SubCmd, this.Name);

                case 0xFD:
                    throw new CommandInvalidParamException(
                        "InvalidSubCommandCode",
                        this.Cmd, this.SubCmd, this.Name);

                case 0xFC:
                    throw new CommandParamException(
                        "SomeParameterInvalid",
                        this.Cmd, this.SubCmd, this.Name);
            }
        }
        #endregion
    }
}
