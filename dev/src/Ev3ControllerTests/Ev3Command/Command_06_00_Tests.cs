using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3ControllerTests.Ev3Command.Tests
{
    [TestClass()]
    public class Command_06_00_Tests
    {
        #region Unit test of Command_06_00
        [TestMethod()]
        [TestCategory("Command_06_00")]
        [TestCategory("Constructor")]
        public void Command_06_00_Tests_001()
        {
            var Command = new Command_06_00();

            Assert.AreEqual(Command.CmdData[0], 0x06);
            Assert.AreEqual(Command.CmdData[1], 0x00);
            Assert.AreEqual(Command.CmdData[2], 0x00);
        }
        #endregion

        #region Unit test of Check method fo Command_06_00.
        [TestMethod()]
        [TestCategory("Command_06_00_Check")]
        public void Command_06_00_CheckTests_001()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x01;

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
        [TestCategory("Command_06_00_Check")]
        public void Command_06_00_CheckTests_002()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x02;

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
        [TestCategory("Command_06_00_Check")]
        public void Command_06_00_CheckTests_003()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x03;

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
        [TestCategory("Command_06_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_06_00_CheckTests_004()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x04;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_06_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_06_00_CheckTests_005()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x00;
            Command.ResData[4] = 0x04;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_06_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_06_00_CheckTests_006()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x02;
            Command.ResData[4] = 0x04;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_06_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_06_00_CheckTests_007()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[6];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x04;
            Command.ResData[4] = 0x05;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_06_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_06_00_CheckTests_008()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[4];
            Command.ResData[0] = 0x07;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;

            Command.Check();
        }
        #endregion
    }
}
