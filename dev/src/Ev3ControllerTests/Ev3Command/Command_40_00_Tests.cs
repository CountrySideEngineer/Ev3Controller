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
    public class Command_40_00_Tests
    {
        #region Unit test of Command_40_00 Constructor.
        [TestMethod()]
        [TestCategory("Command_40_00")]
        public void Command_40_00_Test()
        {
            var Command = new Command_40_00();

            Assert.AreEqual("GetTouchSensor", Command.Name);
            Assert.AreEqual(0x40, Command.Cmd);
            Assert.AreEqual(0x00, Command.SubCmd);
            Assert.AreEqual(0x00, Command.CmdLen);
            Assert.AreEqual(0x40, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x00, Command.CmdData[2]);
            Assert.AreEqual(0x02, Command.OneDataLen);
            Assert.AreEqual(0x41, Command.Res);
            Assert.AreEqual(0x00, Command.SubRes);
            Assert.AreEqual(0xFF, Command.ResLen);
        }
        #endregion
    }
}