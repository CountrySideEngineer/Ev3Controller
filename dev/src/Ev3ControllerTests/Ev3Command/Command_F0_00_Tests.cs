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
    public class Command_F0_00_Tests
    {
        #region Unit test of Command_F0_00 Constructor.
        [TestMethod()]
        [TestCategory("Command_F0_00")]
        public void Command_F0_00_Test()
        {
            var Command = new Command_F0_00();

            Assert.AreEqual("GetSensorsParameter", Command.Name);
            Assert.AreEqual(0xF0, Command.Cmd);
            Assert.AreEqual(0x00, Command.SubCmd);
            Assert.AreEqual(0x00, Command.CmdLen);
            Assert.AreEqual(0xF0, Command.CmdData[0]);
            Assert.AreEqual(0x00, Command.CmdData[1]);
            Assert.AreEqual(0x00, Command.CmdData[2]);
            Assert.AreEqual(0xF1, Command.Res);
            Assert.AreEqual(0x00, Command.SubRes);
            Assert.AreEqual(0xFF, Command.ResLen);
        }
        #endregion

        #region Unit test of Command_F0_00 CheckParam method.
        [TestMethod()]
        [TestCategory("Command_F0_00")]
        [TestCategory("Command_F0_00_Check")]
        public void Command_F0_00_CheckParamTest_001()
        {
            var Command = new Command_F0_00();
            Command.ResData = new byte[12];
            Command.ResData[0] = 0xF1;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x08;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;

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
        [TestCategory("Command_F0_00")]
        [TestCategory("Command_F0_00_Check")]
        public void Command_F0_00_CheckParamTest_002()
        {
            var Command = new Command_F0_00();
            Command.ResData = new byte[15];
            Command.ResData[0] = 0xF1;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0B;
            Command.ResData[4] = 0x20;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0xBB;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;
            Command.ResData[13] = 0x00;
            Command.ResData[14] = 0x00;

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
        [TestCategory("Command_F0_00")]
        [TestCategory("Command_F0_00_Check")]
        public void Command_F0_00_CheckParamTest_003()
        {
            var Command = new Command_F0_00();
            Command.ResData = new byte[15];
            Command.ResData[0] = 0xF1;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0B;
            Command.ResData[4] = 0x30;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x07;
            Command.ResData[8] = 0x55;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;
            Command.ResData[13] = 0x00;
            Command.ResData[14] = 0x00;

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
        [TestCategory("Command_F0_00")]
        [TestCategory("Command_F0_00_Check")]
        public void Command_F0_00_CheckParamTest_004()
        {
            var Command = new Command_F0_00();
            Command.ResData = new byte[13];
            Command.ResData[0] = 0xF1;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x09;
            Command.ResData[4] = 0x40;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x00;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
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
        [TestMethod()]
        [TestCategory("Command_F0_00")]
        [TestCategory("Command_F0_00_Check")]
        public void Command_F0_00_CheckParamTest_005()
        {
            var Command = new Command_F0_00();
            Command.ResData = new byte[16];
            Command.ResData[0] = 0xF1;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x0C;
            Command.ResData[4] = 0x50;
            Command.ResData[5] = 0x04;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x04;
            Command.ResData[9] = 0x05;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x00;
            Command.ResData[13] = 0x00;
            Command.ResData[14] = 0x00;
            Command.ResData[15] = 0x00;

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
        [TestCategory("Command_F0_00")]
        [TestCategory("Command_F0_00_Check")]
        public void Command_F0_00_CheckParamTest_006()
        {
            var Command = new Command_F0_00();
            Command.ResData = new byte[23];
            Command.ResData[0] = 0xF1;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x13;
            Command.ResData[4] = 0x50;
            Command.ResData[5] = 0x04;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x04;
            Command.ResData[9] = 0x05;
            Command.ResData[10] = 0x40;
            Command.ResData[11] = 0x01;
            Command.ResData[12] = 0x01;
            Command.ResData[13] = 0x30;
            Command.ResData[14] = 0x03;
            Command.ResData[15] = 0x64;
            Command.ResData[16] = 0x05;
            Command.ResData[17] = 0x10;
            Command.ResData[18] = 0x20;
            Command.ResData[19] = 0x03;
            Command.ResData[20] = 0x12;
            Command.ResData[21] = 0x34;
            Command.ResData[22] = 0x01;

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