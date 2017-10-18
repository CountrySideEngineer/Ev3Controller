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
    public class Command_12_00_Tests
    {
        #region Unit test of Command_12_00 constructor
        [TestMethod()]
        [TestCategory("Command_12_00")]
        [TestCategory("Command_12_00_Constructor")]
        public void Command_12_00_Test_001()
        {
            var Command = new Command_12_00(new CommandParam_12_00(0, 0));

            Assert.AreEqual(0x12, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x02, Command.CmdData[2]);
            Assert.AreEqual(0x00, Command.CmdData[3]);
            Assert.AreEqual(0x00, Command.CmdData[4]);
            Assert.IsNotNull(Command.CommandParam);
        }
        [TestMethod()]
        [TestCategory("Command_12_00")]
        [TestCategory("Command_12_00_Constructor")]
        public void Command_12_00_Test_002()
        {
            var Command = new Command_12_00(new CommandParam_12_00(0xFF, 1));

            Assert.AreEqual(0x12, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x02, Command.CmdData[2]);
            Assert.AreEqual(0x64, Command.CmdData[3]);
            Assert.AreEqual(0x01, Command.CmdData[4]);
        }
        [TestMethod()]
        [TestCategory("Command_12_00")]
        [TestCategory("Command_12_00_Constructor")]
        public void Command_12_00_Test_003()
        {
            var Command = new Command_12_00(new CommandParam_12_00(0xFF, 2));

            Assert.AreEqual(0x12, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x02, Command.CmdData[2]);
            Assert.AreEqual(0x64, Command.CmdData[3]);
            Assert.AreEqual(0x01, Command.CmdData[4]);
        }
        #endregion
    }
}