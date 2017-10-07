using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;

namespace Ev3ControllerTests.Ev3Command
{
    [TestClass]
    public class Command_0E_20_Tests
    {
        #region Unit test of Command_0E_20 constructor
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Constructor")]
        public void Command_0E_20_Constructor_001()
        {
            var Command = new Command_0E_20();

            Assert.AreEqual(Command.Name, "GetSensors");
            Assert.AreEqual(Command.Cmd, 0x0E);
            Assert.AreEqual(Command.SubCmd, 0x20);
            Assert.AreEqual(Command.CmdLen, 0x00);
            Assert.AreEqual(Command.Res, 0x0F);
            Assert.AreEqual(Command.SubRes, 0x20);
            Assert.AreEqual(Command.ResLen, 0xFF);
            Assert.AreEqual(Command.CmdData[0], 0x0E);
            Assert.AreEqual(Command.CmdData[1], 0x20);
            Assert.AreEqual(Command.CmdData[2], 0x00);
            Assert.AreEqual(Command.OneDataLen, 0x03);
        }
        #endregion
        #region Unit test of Command_0E_20 Check method.
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        public void Command_0E_20_Check_001()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[8];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;//The number of connected device.
            Command.ResData[5] = 0x00;//Port number device connected.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x22;//Sensor value upper byte.

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
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        public void Command_0E_20_Check_002()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[11];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x07;
            Command.ResData[4] = 0x02;//The number of connected device.
            Command.ResData[5] = 0x00;//Port number device connected.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x21;//Sensor value upper byte.
            Command.ResData[8] = 0x01;//Port number device connected.
            Command.ResData[9] = 0x12;//Sensor value lower byte.
            Command.ResData[10] = 0x22;//Sensor value upper byte.

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
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        public void Command_0E_20_Check_003()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[14];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0A;
            Command.ResData[4] = 0x03;//The number of connected device.
            Command.ResData[5] = 0x00;//Port number device connected.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x22;//Sensor value upper byte.
            Command.ResData[8] = 0x01;//Port number device connected.
            Command.ResData[9] = 0x12;//Sensor value lower byte.
            Command.ResData[10] = 0x22;//Sensor value upper byte.
            Command.ResData[11] = 0x02;//Port number device connected.
            Command.ResData[12] = 0x13;//Sensor value lower byte.
            Command.ResData[13] = 0x23;//Sensor value upper byte.

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
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        public void Command_0E_20_Check_004()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;//The number of connected device.
            Command.ResData[5] = 0x00;//Port number device connected.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x21;//Sensor value upper byte.
            Command.ResData[8] = 0x01;//Port number device connected.
            Command.ResData[9] = 0x12;//Sensor value lower byte.
            Command.ResData[10] = 0x22;//Sensor value upper byte.
            Command.ResData[11] = 0x02;//Port number device connected.
            Command.ResData[12] = 0x11;//Sensor value lower byte.
            Command.ResData[13] = 0x21;//Sensor value upper byte.
            Command.ResData[14] = 0x03;//Port number device connected.
            Command.ResData[15] = 0x12;//Sensor value lower byte.
            Command.ResData[16] = 0x22;//Sensor value upper byte.

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
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_20_Check_005()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;//The number of connected device.
            Command.ResData[5] = 0x00;//Port number device connected.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x21;//Sensor value upper byte.
            Command.ResData[8] = 0x01;//Port number device connected.
            Command.ResData[9] = 0x12;//Sensor value lower byte.
            Command.ResData[10] = 0x22;//Sensor value upper byte.
            Command.ResData[11] = 0x02;//Port number device connected.
            Command.ResData[12] = 0x11;//Sensor value lower byte.
            Command.ResData[13] = 0x21;//Sensor value upper byte.
            Command.ResData[14] = 0x04;//Port number device connected:Invalid.
            Command.ResData[15] = 0x12;//Sensor value lower byte.
            Command.ResData[16] = 0x22;//Sensor value upper byte.

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_20_Check_006()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;//The number of connected device.
            Command.ResData[5] = 0x00;//Port number device connected.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x21;//Sensor value upper byte.
            Command.ResData[8] = 0x01;//Port number device connected.
            Command.ResData[9] = 0x12;//Sensor value lower byte.
            Command.ResData[10] = 0x22;//Sensor value upper byte.
            Command.ResData[11] = 0x04;//Port number device connected:Invalid.
            Command.ResData[12] = 0x11;//Sensor value lower byte.
            Command.ResData[13] = 0x21;//Sensor value upper byte.
            Command.ResData[14] = 0x03;//Port number device connected.
            Command.ResData[15] = 0x12;//Sensor value lower byte.
            Command.ResData[16] = 0x22;//Sensor value upper byte.

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_20_Check_007()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;//The number of connected device.
            Command.ResData[5] = 0x00;//Port number device connected.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x21;//Sensor value upper byte.
            Command.ResData[8] = 0x04;//Port number device connected:Invalid.
            Command.ResData[9] = 0x12;//Sensor value lower byte.
            Command.ResData[10] = 0x22;//Sensor value upper byte.
            Command.ResData[11] = 0x02;//Port number device connected.
            Command.ResData[12] = 0x11;//Sensor value lower byte.
            Command.ResData[13] = 0x21;//Sensor value upper byte.
            Command.ResData[14] = 0x03;//Port number device connected.
            Command.ResData[15] = 0x12;//Sensor value lower byte.
            Command.ResData[16] = 0x22;//Sensor value upper byte.

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_20")]
        [TestCategory("Command_0E_20_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_20_Check_008()
        {
            var Command = new Command_0E_20();
            Command.ResData = new byte[17];
            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x20;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0D;
            Command.ResData[4] = 0x04;//The number of connected device.
            Command.ResData[5] = 0x04;//Port number device connected:Invalid.
            Command.ResData[6] = 0x11;//Sensor value lower byte.
            Command.ResData[7] = 0x21;//Sensor value upper byte.
            Command.ResData[8] = 0x01;//Port number device connected.
            Command.ResData[9] = 0x12;//Sensor value lower byte.
            Command.ResData[10] = 0x22;//Sensor value upper byte.
            Command.ResData[11] = 0x02;//Port number device connected.
            Command.ResData[12] = 0x11;//Sensor value lower byte.
            Command.ResData[13] = 0x21;//Sensor value upper byte.
            Command.ResData[14] = 0x03;//Port number device connected.
            Command.ResData[15] = 0x12;//Sensor value lower byte.
            Command.ResData[16] = 0x22;//Sensor value upper byte.

            Command.Check();
        }
        #endregion
    }
}
