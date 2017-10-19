using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command.Tests
{
    [TestClass()]
    public class ACommandTests
    {
        #region Unit test of Command_00_00
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Constructor")]
        public void Command_00_00Test_001()
        {
            var Command = new Command_00_00();

            Assert.AreEqual(Command.CmdData[0], 0x00);
            Assert.AreEqual(Command.CmdData[1], 0x00);
            Assert.AreEqual(Command.CmdData[2], 0x06);
            for (int index = 0; index < 0x06; index++) {
                Assert.AreEqual(Command.CmdData[3 + index], index);
            }
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Constructor")]
        public void Command_00_00Test_002()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }
            //Expect:No exception will be raised.
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandUnExpectedResponse))]
        public void Command_00_00Test_003()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x02;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandUnExpectedResponse))]
        public void Command_00_00Test_004()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x00;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandUnExpectedResponse))]
        public void Command_00_00Test_005()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x01;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandUnExpectedResponse))]
        public void Command_00_00Test_006()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0xFF;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_00_00Test_007()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0xFF;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_00_00Test_008()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0xFE;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandInvalidParamException))]
        public void Command_00_00Test_009()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0xFD;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandParamException))]
        public void Command_00_00Test_010()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0xFC;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_00_00Test_011()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x05;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_00_00Test_012()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x07;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_00_00Test_013()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[11];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_00_00Test_014()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[11];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandParamException))]
        public void Command_00_00Test_015()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }
            Command.ResData[4] = 0x01;

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandParamException))]
        public void Command_00_00Test_016()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }
            Command.ResData[4] = 0xFF;

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandParamException))]
        public void Command_00_00Test_017()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }
            Command.ResData[9] = 0x06;

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandParamException))]
        public void Command_00_00Test_018()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];

            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            for (int index = 0; index < 6; index++)
            {
                Command.ResData[(byte)(4 + index)] = (byte)index;
            }
            Command.ResData[9] = 0x07;

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandNoResponseException))]
        public void Command_00_00Test_019()
        {
            var Command = new Command_00_00();
            Command.ResData = null;

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckDevNum")]
        public void Command_00_00Test_020()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x06;

            var PrivateCommand = new PrivateObject(Command);
            int DevNum = (int)PrivateCommand.Invoke("CheckDevNum");

            Assert.AreEqual(0, DevNum);
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckDevNum")]
        public void Command_00_00Test_CheckDevNumAndThrowException_001()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x03;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x06;

            var PrivateCommand = new PrivateObject(Command);
            int DevNum = (int)PrivateCommand.Invoke("CheckDevNum");

            Assert.AreEqual(3, DevNum);
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckDevNum")]
        public void Command_00_00Test_CheckDevNumAndThrowException_002()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x06;

            var PrivateCommand = new PrivateObject(Command);
            int DevNum = (int)PrivateCommand.Invoke("CheckDevNum");

            Assert.AreEqual(0, DevNum);
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckDevNum")]
        public void Command_00_00Test_CheckDevNumAndThrowException_003()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x04;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x06;

            var PrivateCommand = new PrivateObject(Command);
            int DevNum = (int)PrivateCommand.Invoke("CheckDevNum");

            Assert.AreEqual(4, DevNum);
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckDevNum")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_00_00Test_CheckDevNumAndThrowException_004()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x05;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x06;

            var PrivateCommand = new PrivateObject(Command);
            int DevNum = (int)PrivateCommand.Invoke("CheckDevNum");
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckLen")]
        public void Command_00_00Test_CheckLenAndThrowException_001()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;

            var PrivateCommand = new PrivateObject(Command as ACommand_ResLenFix);
            int DevNum = (int)PrivateCommand.Invoke("CheckLen");
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckLen")]
        public void Command_00_00Test_CheckLenAndThrowException_002()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;

            var PrivateCommand = new PrivateObject(Command as ACommand_ResLenFix);
            int ResLen = (int)PrivateCommand.Invoke("CheckLen");

            Assert.AreEqual(6, ResLen);
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckLen")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_00_00Test_CheckLenAndThrowException_003()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x05;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;

            var PrivateCommand = new PrivateObject(Command as ACommand_ResLenFix);
            int ResLen = (int)PrivateCommand.Invoke("CheckLen");
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckLenAndThrowException")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_00_00Test_CheckLenAndThrowException_004()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x07;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;

            var PrivateCommand = new PrivateObject(Command);
            int ResLen = (int)PrivateCommand.Invoke("CheckLen");
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckPort")]
        public void Command_00_00Test_CheckPort_001()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x00;//The port number, 0
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;

            var PrivateCommand = new PrivateObject(Command);
            byte PortNum = (byte)PrivateCommand.Invoke("CheckPort", 5);

            Assert.AreEqual(0, PortNum);
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckPort")]
        public void Command_00_00Test_CheckPort_002()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x03;//The port number, 3
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;

            var PrivateCommand = new PrivateObject(Command);
            byte PortNum = (byte)PrivateCommand.Invoke("CheckPort", 5);

            Assert.AreEqual(3, PortNum);
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Command_00_00_CheckPort")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_00_00Test_CheckPort_003()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            Command.ResData[4] = 0x00;//The number of connected device.
            Command.ResData[5] = 0x04;//The port number, 4
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;

            var PrivateCommand = new PrivateObject(Command);
            byte PortNum = (byte)PrivateCommand.Invoke("CheckPort", 5);
        }
        #endregion
    }
}