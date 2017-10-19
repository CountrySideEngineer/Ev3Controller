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
    public class Command_50_01_Tests
    {
        #region Unit test of Command_50_01 Constructor.
        [TestMethod()]
        [TestCategory("Command_50_01")]
        public void Command_50_01_Test()
        {
            var Command = new Command_50_01();

            Assert.AreEqual("GetGyroSensor", Command.Name);
            Assert.AreEqual(0x50, Command.Cmd);
            Assert.AreEqual(0x01, Command.SubCmd);
            Assert.AreEqual(0x00, Command.CmdLen);
            Assert.AreEqual(0x50, Command.CmdData[0]);
            Assert.AreEqual(0x01, Command.CmdData[1]);
            Assert.AreEqual(0x00, Command.CmdData[2]);
            Assert.AreEqual(0x03, Command.OneDataLen);
            Assert.AreEqual(0x51, Command.Res);
            Assert.AreEqual(0x01, Command.SubRes);
            Assert.AreEqual(0xFF, Command.ResLen);
        }
        #endregion
    }
}