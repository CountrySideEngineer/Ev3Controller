using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;

namespace Ev3ControllerTests.Ev3Command
{
    [TestClass]
    public class Command_10_00_Tests
    {
        #region Unit test of Command_10_00 constructor
        [TestMethod]
        [TestCategory("Command_10_00")]
        [TestCategory("Command_10_00_Constructor")]
        public void Command_10_00_Constructor_001()
        {
            var Command = new Command_10_00();

            Assert.AreEqual("GetMotorPower", Command.Name);
            Assert.AreEqual(0x10, Command.Cmd);
            Assert.AreEqual(0x00, Command.SubCmd);
            Assert.AreEqual(0x00, Command.CmdLen);
            Assert.AreEqual(0x11, Command.Res);
            Assert.AreEqual(0x00, Command.SubRes);
            Assert.AreEqual(0x01, Command.ResLen);
            Assert.AreEqual(0x10, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x00, Command.CmdData[2]);
        }
        #endregion

        #region Unit test of Command_10_00 CheckParam method.
        [TestMethod]
        [TestCategory("Command_10_00")]
        [TestCategory("Command_10_00_Check")]
        public void Command_10_00_Check_001()
        {
            var Command = new Command_10_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x11;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x00;

            try
            {
                Command.Check();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        #endregion
    }
}
