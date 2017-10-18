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
    public class Command_20_00_Tests
    {
        #region Unit test of constructor.
        [TestMethod()]
        [TestCategory("Command_20_00")]
        public void Command_20_00_Test()
        {
            var Command = new Command_20_00();

            Assert.AreEqual("GetSonicSensor", Command.Name);
            Assert.AreEqual(0x20, Command.Cmd);
            Assert.AreEqual(0x00, Command.SubCmd);
            Assert.AreEqual(0x21, Command.Res);
            Assert.AreEqual(0x00, Command.SubRes);
            Assert.AreEqual(0x00, Command.CmdLen);
            Assert.AreEqual(0xFF, Command.ResLen);
        }
        #endregion

        #region Unit test of Check method.
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_001()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[5];

            Command.ResData[0] = 0x21;
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
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_002()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_003()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_004()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

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
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_005()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_006()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[11];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x07;
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;

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
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_007()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[14];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0A;
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[10] = 0x02;
            Command.ResData[10] = 0x00;
            Command.ResData[10] = 0x00;

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
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        public void Command_20_00_Check_Test_008()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[17];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x00;
            Command.ResData[13] = 0x00;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x00;
            Command.ResData[16] = 0x00;

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
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_20_00_Check_Test_009()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x04;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_20_00_Check_Test_010()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_20_00_Check_Test_011()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x05;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod()]
        [TestCategory("Command_20_00")]
        [TestCategory("Command_20_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_20_00_Check_Test_012()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x21;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x05;
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        #endregion
    }
}