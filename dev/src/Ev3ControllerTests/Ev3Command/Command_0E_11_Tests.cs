using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;

namespace Ev3ControllerTests.Ev3Command
{
    [TestClass]
    public class Command_0E_11_Tests
    {
        #region Unit test of Command_0E_01 Constructor.
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Constructor")]
        public void Command_0E_11_Constructor_001()
        {
            var Command = new Command_0E_11();

            Assert.AreEqual(Command.Name, "GetSensors");
            Assert.AreEqual(Command.Cmd, 0x0E);
            Assert.AreEqual(Command.SubCmd, 0x11);
            Assert.AreEqual(Command.CmdLen, 0x00);
            Assert.AreEqual(Command.Res, 0x0F);
            Assert.AreEqual(Command.SubRes, 0x11);
            Assert.AreEqual(Command.ResLen, 0xFF);
            Assert.AreEqual(Command.CmdData[0], 0x0E);
            Assert.AreEqual(Command.CmdData[1], 0x11);
            Assert.AreEqual(Command.CmdData[2], 0x00);
        }
        #endregion
        #region Unit test of Command_0E_11 check method.
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        public void Command_0E_11_Check_001()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[5];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
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
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        public void Command_0E_11_Check_002()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;

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
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        public void Command_0E_11_Check_003()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[11];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x07;
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;

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
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        public void Command_0E_11_Check_004()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[14];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0A;
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;

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
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        public void Command_0E_11_Check_005()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x55;
            Command.ResData[16] = 0xAA;

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
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_11_Check_006()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;
            Command.ResData[14] = 0x04;
            Command.ResData[15] = 0x55;
            Command.ResData[16] = 0xAA;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_11_Check_007()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x04;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x55;
            Command.ResData[16] = 0xAA;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_11_Check_008()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x04;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x55;
            Command.ResData[16] = 0xAA;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_11_Check_009()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x04;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x55;
            Command.ResData[16] = 0xAA;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_0E_11_Check_010()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[18];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0E;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x04;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x55;
            Command.ResData[16] = 0xAA;
            Command.ResData[17] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_11")]
        [TestCategory("Command_0E_11_Check")]
        [ExpectedExceptionAttribute(typeof(CommandLenException))]
        public void Command_0E_11_Check_011()
        {
            var Command = new Command_0E_11();
            Command.ResData = new byte[18];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x11;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0C;
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x04;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0xAA;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0xAA;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x55;

            Command.Check();
        }
        #endregion
    }
}
