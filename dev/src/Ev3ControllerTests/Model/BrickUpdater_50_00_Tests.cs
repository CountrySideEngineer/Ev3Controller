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
    public class BrickUpdater_50_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of Update method of BrickUpdater_50_00
        [TestMethod()]
        [TestCategory("BrickUpdater_50_00")]
        [TestCategory("BrickUpdater_50_00_Update")]
        public void BrickUpdater_50_00_Update_Test_001()
        {
            var Command = new Command_50_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;

            var Updater = new BrickUpdater_50_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x0000, Brick.SensorDevice(0).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(0).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_50_00")]
        [TestCategory("BrickUpdater_50_00_Update")]
        public void BrickUpdater_50_00_Update_Test_002()
        {
            var Command = new Command_50_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0x00;

            var Updater = new BrickUpdater_50_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x00FF, Brick.SensorDevice(1).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(1).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_50_00")]
        [TestCategory("BrickUpdater_50_00_Update")]
        public void BrickUpdater_50_00_Update_Test_003()
        {
            var Command = new Command_50_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0xFF;
            Command.ResData[7] = 0x7F;

            var Updater = new BrickUpdater_50_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x7FFF, Brick.SensorDevice(2).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(2).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_50_00")]
        [TestCategory("BrickUpdater_50_00_Update")]
        public void BrickUpdater_50_00_Update_Test_004()
        {
            var Command = new Command_50_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x80;

            var Updater = new BrickUpdater_50_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(-32768, Brick.SensorDevice(3).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_50_00")]
        [TestCategory("BrickUpdater_50_00_Update")]
        public void BrickUpdater_50_00_Update_Test_005()
        {
            var Command = new Command_50_00();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0xFF;
            Command.ResData[10] = 0x7F;

            var Updater = new BrickUpdater_50_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x0000, Brick.SensorDevice(0).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(0).DeviceType);
            Assert.AreEqual((Ev3SensorDevice.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x7FFF, Brick.SensorDevice(1).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(1).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_50_00")]
        [TestCategory("BrickUpdater_50_00_Update")]
        public void BrickUpdater_50_00_Update_Test_006()
        {
            var Command = new Command_50_00();
            Command.ResData = new byte[14];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x00;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0xFF;
            Command.ResData[10] = 0x7F;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0xFF;
            Command.ResData[13] = 0xFF;

            var Updater = new BrickUpdater_50_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x0000, Brick.SensorDevice(0).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x7FFF, Brick.SensorDevice(1).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3SensorDevice.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(-1, Brick.SensorDevice(2).Value1);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(2).DeviceType);
        }
        #endregion
    }
}