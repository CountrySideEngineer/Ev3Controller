using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;

namespace Ev3ControllerTests.Ev3Command
{
    [TestClass]
    public class Command_0E_00_Tests
    {
        #region Unit test of Command_0E_00 Constructor.
        [TestMethod]
        [TestCategory("Constructor")]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Constructor")]
        public void Command_0E_00_Constructor_001()
        {
            var Command = new Command_0E_00();

            Assert.AreEqual(Command.Name, "GetSensors");
            Assert.AreEqual(Command.Cmd, 0x0E);
            Assert.AreEqual(Command.SubCmd, 0x00);
            Assert.AreEqual(Command.CmdLen, 0x00);
            Assert.AreEqual(Command.Res, 0x0F);
            Assert.AreEqual(Command.SubRes, 0x00);
            Assert.AreEqual(Command.ResLen, 0x04);
            Assert.AreEqual(Command.CmdData[0], 0x0E);
            Assert.AreEqual(Command.CmdData[1], 0x00);
            Assert.AreEqual(Command.CmdData[2], 0x00);
        }
        #endregion

        #region Unit test of Command_0E_00 Check method.
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_001()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_002()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_003()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_004()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_005()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x04;

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
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_006()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x05;

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
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_007()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x06;

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
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_008()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x07;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_009()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0xFF;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_010()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_011()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_012()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_013()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x04;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_014()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x05;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_015()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x06;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_016()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x07;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_017()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_018()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_019()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_020()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_021()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x04;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_022()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x05;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_023()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x06;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_024()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x07;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_025()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0xFF;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_027()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_028()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_029()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x03;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_030()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x04;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_031()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x05;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        public void Command_0E_00_Check_032()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x06;
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
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_033()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x07;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        [TestMethod]
        [TestCategory("Command_0E_00")]
        [TestCategory("Command_0E_00_Check")]
        [ExpectedExceptionAttribute(typeof(CommandOperationException))]
        public void Command_0E_00_Check_034()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];

            Command.ResData[0] = 0x0F;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0xFF;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            Command.Check();
        }
        #endregion
    }
}
