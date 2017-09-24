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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
        [TestCategory("Constructor")]
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
            Command.ResData[9] = 0x05;

            //In the method below, the exception will be raised.
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_00_00")]
        [TestCategory("Constructor")]
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


        #endregion
    }
}