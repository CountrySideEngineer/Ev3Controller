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
    public class Command_0C_00_Tests
    {
        #region Unit test of Command_0C_00
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Constructor")]
        public void Command_0C_00_Tests_001()
        {
            var Command = new Command_0C_00();

            Assert.AreEqual(Command.CmdData[0], 0x0C);
            Assert.AreEqual(Command.CmdData[1], 0x00);
            Assert.AreEqual(Command.CmdData[2], 0x00);
            Assert.AreEqual(Command.Name, "GetMotors");
        }
        #endregion

        #region Unit tes of Check method of Command_0C_00.
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_001()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_002()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x01;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [TestCategory("Constructor")]
        public void Command_0C_00_CheckTests_003()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x02;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [TestCategory("Constructor")]
        public void Command_0C_00_CheckTests_004()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x03;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_005()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0xFE;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_006()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0xFF;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_007()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_008()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_009()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x03;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_010()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xFE;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_011()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_012()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_013()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_014()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_015()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0xFE;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_016()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0xFF;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_017()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_018()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        public void Command_0C_00_CheckTests_019()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_020()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0xFE;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0C_00_CheckTests_021()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0xFF;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_0C_00_CheckTests_022()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_0C_00_CheckTests_023()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x05;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_0C_00_CheckTests_024()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[7];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_0C_00")]
        [TestCategory("Command_0C_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_0C_00_CheckTests_025()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[9];
            Command.ResData[0] = 0x0D;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.Check();
        }
        #endregion
    }
}
