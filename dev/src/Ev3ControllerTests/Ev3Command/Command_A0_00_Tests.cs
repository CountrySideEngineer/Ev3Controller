using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ev3Controller.Ev3Command.Tests
{
    [TestClass]
    public class Command_A0_00_Tests
    {
        #region Unit test of Command_A0_00 Constructor.
        [TestMethod()]
        [TestCategory("Command_A0_00")]
        public void Command_A0_00_Test()
        {
            var Command = new Command_A0_00();

            Assert.AreEqual("GetSafetyState", Command.Name);
            Assert.AreEqual(0xA0, Command.Cmd);
            Assert.AreEqual(0x00, Command.SubCmd);
            Assert.AreEqual(0x00, Command.CmdLen);
            Assert.AreEqual(0xA0, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x00, Command.CmdData[2]);
            Assert.AreEqual(0xA1, Command.Res);
            Assert.AreEqual(0x00, Command.SubRes);
            Assert.AreEqual(0x01, Command.ResLen);
        }
        #endregion
    }
}
