using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;

namespace Ev3ControllerTests.Ev3Command
{
    [TestClass]
    public class Command_0E_10_Tests
    {
        #region Unit test of Command_0E_00 Constructor.
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Constructor")]
        public void Command_0E_10_Constructor_001()
        {
            var Command = new Command_0E_10();

            Assert.AreEqual(Command.Name, "GetSensors");
            Assert.AreEqual(Command.Cmd, 0x0E);
            Assert.AreEqual(Command.SubCmd, 0x10);
            Assert.AreEqual(Command.CmdLen, 0x00);
            Assert.AreEqual(Command.Res, 0x0F);
            Assert.AreEqual(Command.SubRes, 0x10);
            Assert.AreEqual(Command.ResLen, 0xFF);
            Assert.AreEqual(Command.CmdData[0], 0x0E);
            Assert.AreEqual(Command.CmdData[1], 0x10);
            Assert.AreEqual(Command.CmdData[2], 0x00);
        }
        #endregion

        #region Unit test of Command_0E_00 check method.
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_001()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_002()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[7];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;

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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_003()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[7];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;

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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_004()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[7];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x00;

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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_005()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[7];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x00;

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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_006()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[9];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x05;
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x01;
            Command.ResData[8] = 0x00;

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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_007()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[11];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x07;
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x01;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x01;
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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        public void Command_0E_10_Check_008()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x01;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x01;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x01;
            Command.ResData[12] = 0x00;

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
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_009()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x04;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_010()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_011()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_012()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x04;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_013()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_014()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x04;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_015()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x02;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_016()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x4;
            Command.ResData[12] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_10")]
        [TestCategory("Command_0E_10_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_10_Check_017()
        {
            var Command = new Command_0E_10();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x10;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x02;

            Command.Check();
        }
        #endregion
    }
}
