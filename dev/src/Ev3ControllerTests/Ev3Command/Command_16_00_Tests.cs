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
    public class Command_16_00_Tests
    {
        #region Unit test of Command_16_00
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("Command_16_00")]
        [TestCategory("Command_16_00_Constructor")]
        public void Command_16_00_Test_001()
        {
            var Command = new Command_16_00(new CommandParam_16_00(0));

            Assert.AreEqual(0x16, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x01, Command.CmdData[2]);
            Assert.AreEqual(0x00, Command.CmdData[3]);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("Command_16_00")]
        [TestCategory("Command_16_00_Constructor")]
        public void Command_16_00_Test_002()
        {
            var Command = new Command_16_00(new CommandParam_16_00(1));

            Assert.AreEqual(0x16, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x01, Command.CmdData[2]);
            Assert.AreEqual(0x01, Command.CmdData[3]);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("Command_16_00")]
        [TestCategory("Command_16_00_Constructor")]
        public void Command_16_00_Test_003()
        {
            var Command = new Command_16_00(new CommandParam_16_00(-1));

            Assert.AreEqual(0x16, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x01, Command.CmdData[2]);
            Assert.AreEqual(0xFF, Command.CmdData[3]);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("Command_16_00")]
        [TestCategory("Command_16_00_Constructor")]
        public void Command_16_00_Test_004()
        {
            var Command = new Command_16_00(null);

            Assert.AreEqual(0x16, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x01, Command.CmdData[2]);
            Assert.AreEqual(0x00, Command.CmdData[3]);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("Command_16_00")]
        [TestCategory("Command_16_00_Constructor")]
        public void Command_16_00_Test_005()
        {
            var Command = new Command_16_00(null);

            Assert.AreEqual(0x16, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x01, Command.CmdData[2]);
            Assert.AreEqual(0x00, Command.CmdData[3]);
        }
        #endregion
    }
}