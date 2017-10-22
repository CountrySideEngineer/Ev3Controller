using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class BrickUpdater_10_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of BrickUpdater_10_00, update method
        [TestMethod()]
        [TestCategory("BrickUpdater_10_00")]
        [TestCategory("BrickUpdater_10_00_Update")]
        public void BrickUpdater_10_00_Update_Test_001()
        {
            var Command = new Command_10_00();
            Command.ResData = new byte[12];
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x02;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x03;
            Command.ResData[10] = 0x00;
            Command.ResData[11] = 0x04;

            var Updater = new BrickUpdater_10_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.MotorDevice(0).IsConnected);
            Assert.IsFalse(Brick.MotorDevice(1).IsConnected);
            Assert.IsFalse(Brick.MotorDevice(2).IsConnected);
            Assert.IsFalse(Brick.MotorDevice(3).IsConnected);
            Assert.AreEqual(0, Brick.MotorDevice(0).Power);
            Assert.AreEqual(0, Brick.MotorDevice(1).Power);
            Assert.AreEqual(0, Brick.MotorDevice(2).Power);
            Assert.AreEqual(0, Brick.MotorDevice(3).Power);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_10_00")]
        [TestCategory("BrickUpdater_10_00_Update")]
        public void BrickUpdater_10_00_Update_Test_002()
        {
            var Command = new Command_10_00();
            Command.ResData = new byte[12];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x02;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x03;
            Command.ResData[10] = 0x01;
            Command.ResData[11] = 0x04;

            var Updater = new BrickUpdater_10_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.MotorDevice(0).IsConnected);
            Assert.IsTrue(Brick.MotorDevice(1).IsConnected);
            Assert.IsTrue(Brick.MotorDevice(2).IsConnected);
            Assert.IsTrue(Brick.MotorDevice(3).IsConnected);
            Assert.AreEqual(1, Brick.MotorDevice(0).Power);
            Assert.AreEqual(2, Brick.MotorDevice(1).Power);
            Assert.AreEqual(3, Brick.MotorDevice(2).Power);
            Assert.AreEqual(4, Brick.MotorDevice(3).Power);
        }
        #endregion
    }
}