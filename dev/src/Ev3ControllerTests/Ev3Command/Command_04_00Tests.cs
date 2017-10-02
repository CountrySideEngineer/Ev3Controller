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
    public class Command_04_00Tests
    {
        #region Unit test of Command_04_00
        [TestMethod()]
        [TestCategory("Command_04_00")]
        [TestCategory("Constructor")]
        public void Command_04_00Tests_001()
        {
            var Command = new Command_04_00();

            Assert.AreEqual(Command.CmdData[0], 0x04);
            Assert.AreEqual(Command.CmdData[1], 0x00);
            Assert.AreEqual(Command.CmdData[2], 0x00);
        }
        #endregion

        #region Unit tes of Check method of Command_04_00.
        [TestMethod()]
        [TestCategory("Command_04_00_Check")]
        public void Command_04_00_CheckTests_001()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x05;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x11;
            Command.ResData[5] = 0x22;
            Command.ResData[6] = 0x33;
            Command.ResData[7] = 0x44;

            try
            {
                Command.Check();
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        [TestCategory("Command_04_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_04_00_CheckTests_002()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[7];
            Command.ResData[0] = 0x05;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x11;
            Command.ResData[5] = 0x22;
            Command.ResData[6] = 0x33;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_04_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_04_00_CheckTests_003()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[9];
            Command.ResData[0] = 0x05;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x11;
            Command.ResData[5] = 0x22;
            Command.ResData[6] = 0x33;
            Command.ResData[7] = 0x44;
            Command.ResData[8] = 0x55;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_04_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_04_00_CheckTests_004()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x05;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x11;
            Command.ResData[5] = 0x22;
            Command.ResData[6] = 0x33;
            Command.ResData[7] = 0x44;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_04_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_04_00_CheckTests_005()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x05;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x05;
            Command.ResData[4] = 0x11;
            Command.ResData[5] = 0x22;
            Command.ResData[6] = 0x33;
            Command.ResData[7] = 0x44;

            Command.Check();
        }
        #endregion
    }
}