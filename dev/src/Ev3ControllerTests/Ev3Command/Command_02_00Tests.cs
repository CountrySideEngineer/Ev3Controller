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
    public class Command_02_00Tests
    {
        #region Unit test of Command_02_00
        [TestMethod()]
        [TestCategory("Command_02_00")]
        [TestCategory("Constructor")]
        public void Command_02_00Tests_001()
        {
            var Command = new Command_02_00();

            Assert.AreEqual(Command.CmdData[0], 0x02);
            Assert.AreEqual(Command.CmdData[1], 0x00);
            Assert.AreEqual(Command.CmdData[2], 0x00);
        }

        [TestMethod()]
        [TestCategory("Command_02_00_Check")]
        [TestCategory("MemberMethod")]
        public void Command_02_00_CheckTests_001()
        {
            var Command = new Command_02_00();
            Command.ResData = new byte[6];
            Command.ResData[0] = 0x03;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x02;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;

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