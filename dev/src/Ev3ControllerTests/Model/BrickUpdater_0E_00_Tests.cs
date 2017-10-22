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
    public class BrickUpdater_0E_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of BrickUpdater_0C_00, update method
        [TestMethod()]
        [TestCategory("BrickUpdater_0E_00")]
        [TestCategory("BrickUpdater_0E_00_Update")]
        public void BrickUpdater_0E_00_Update_Test_001()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x03;

            var Updater = new BrickUpdater_0E_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.AreEqual(Ev3Device.INPORT.INPORT_1, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_2, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_3, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_4, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(0).DeviceType);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(2).DeviceType);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_0E_00")]
        [TestCategory("BrickUpdater_0E_00_Update")]
        public void BrickUpdater_0E_00_Update_Test_002()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x05;
            Command.ResData[6] = 0x06;
            Command.ResData[7] = 0xFF;

            var Updater = new BrickUpdater_0E_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.AreEqual(Ev3Device.INPORT.INPORT_1, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_2, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_3, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_4, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR,
                Brick.SensorDevice(0).DeviceType);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_HT_NXT_ACCEL,
                Brick.SensorDevice(1).DeviceType);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NXT_TEMP,
                Brick.SensorDevice(2).DeviceType);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_UNKNOWN,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_0E_00")]
        [TestCategory("BrickUpdater_0E_00_Update")]
        public void BrickUpdater_0E_00_Update_Test_003()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x07;
            Command.ResData[5] = 0x05;
            Command.ResData[6] = 0x06;
            Command.ResData[7] = 0xFF;

            var Updater = new BrickUpdater_0E_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.AreEqual(Ev3Device.INPORT.INPORT_1, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_2, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_3, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(Ev3Device.INPORT.INPORT_4, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_UNKNOWN,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
        }
        #endregion
    }
}