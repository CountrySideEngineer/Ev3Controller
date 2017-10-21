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
    public class BrickUpdater_04_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of Updat method of BrickUpdater_04_00
        [TestMethod()]
        [TestCategory("BrickUpdater_04_00")]
        [TestCategory("BrickUpdater_04_00_Update")]
        public void BrickUpdater_04_00_Update_Test_001()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x03;
            Command.ResData[7] = 0x04;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_04_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(0x0201, Brick.Battery.Voltage);
            Assert.AreEqual(0x0403, Brick.Battery.Current);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_04_00")]
        [TestCategory("BrickUpdater_04_00_Update")]
        public void BrickUpdater_04_00_Update_Test_002()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0xFF;
            Command.ResData[5] = 0xFF;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0x7F;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_04_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(-1, Brick.Battery.Voltage);
            Assert.AreEqual(32767, Brick.Battery.Current);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_04_00")]
        [TestCategory("BrickUpdater_04_00_Update")]
        public void BrickUpdater_04_00_Update_Test_003()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0xFF;
            Command.ResData[5] = 0x7F;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x80;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_04_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(32767, Brick.Battery.Voltage);
            Assert.AreEqual(-32768, Brick.Battery.Current);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_04_00")]
        [TestCategory("BrickUpdater_04_00_Update")]
        public void BrickUpdater_04_00_Update_Test_004()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0xFF;
            Command.ResData[5] = 0x7F;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_04_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(32767, Brick.Battery.Voltage);
            Assert.AreEqual(0, Brick.Battery.Current);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_04_00")]
        [TestCategory("BrickUpdater_04_00_Update")]
        public void BrickUpdater_04_00_Update_Test_005()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0x7F;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_04_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(0, Brick.Battery.Voltage);
            Assert.AreEqual(32767, Brick.Battery.Current);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_04_00")]
        [TestCategory("BrickUpdater_04_00_Update")]
        public void BrickUpdater_04_00_Update_Test_006()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0xFF;
            Command.ResData[5] = 0xFF;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x80;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_04_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(-1, Brick.Battery.Voltage);
            Assert.AreEqual(-32768, Brick.Battery.Current);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_04_00")]
        [TestCategory("BrickUpdater_04_00_Update")]
        public void BrickUpdater_04_00_Update_Test_007()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x80;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0xFF;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_04_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(-32768, Brick.Battery.Voltage);
            Assert.AreEqual(-1, Brick.Battery.Current);
        }
        #endregion
    }
}