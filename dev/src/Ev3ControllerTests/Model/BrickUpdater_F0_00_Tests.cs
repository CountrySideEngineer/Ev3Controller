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
    public class BrickUpdater_F0_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of Update method in BrickUpdater_F0_00.
        [TestMethod()]
        [TestCategory("BrickUpdater_F0_00")]
        [TestCategory("BrickUpdater_F0_00_Update")]
        public void BrickUpdater_F0_00_Update_Test_001()
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

            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_F0_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_F0_00")]
        [TestCategory("BrickUpdater_F0_00_Update")]
        public void BrickUpdater_F0_00_Update_Test_002()
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

            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_F0_00();
            Updater.Update(Command, Brick);
            ushort Expected = 0xBBAA;

            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((int)((short)(Expected)), Brick.SensorDevice(0).Value1);
            Assert.AreEqual(0x01, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_F0_00")]
        [TestCategory("BrickUpdater_F0_00_Update")]
        public void BrickUpdater_F0_00_Update_Test_003()
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

            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_F0_00();
            Updater.Update(Command, Brick);
            ushort ExpectedAmbient = 0xAA;
            ushort ExpectedReflect = 0x55;

            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((int)((short)(ExpectedAmbient)), Brick.SensorDevice(0).Value1);
            Assert.AreEqual(7, Brick.SensorDevice(0).Value2);
            Assert.AreEqual((int)((short)(ExpectedReflect)), Brick.SensorDevice(0).Value3);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_F0_00")]
        [TestCategory("BrickUpdater_F0_00_Update")]
        public void BrickUpdater_F0_00_Update_Test_004()
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

            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_F0_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual(1, Brick.SensorDevice(0).Value1);
            Assert.AreEqual(0, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(0, Brick.SensorDevice(0).Value3);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_F0_00")]
        [TestCategory("BrickUpdater_F0_00_Update")]
        public void BrickUpdater_F0_00_Update_Test_005()
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

            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_F0_00();
            Updater.Update(Command, Brick);
            ushort ExpectedAngle = 0x0302;
            ushort ExpectedApeed = 0x0504;

            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((int)((short)ExpectedAngle), Brick.SensorDevice(0).Value1);
            Assert.AreEqual((int)((short)ExpectedApeed), Brick.SensorDevice(0).Value2);
            Assert.AreEqual(0, Brick.SensorDevice(0).Value3);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_F0_00")]
        [TestCategory("BrickUpdater_F0_00_Update")]
        public void BrickUpdater_F0_00_Update_Test_006()
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

            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_F0_00();
            Updater.Update(Command, Brick);
            ushort ExpectedAngle = 0x0302;
            ushort ExpectedApeed = 0x0504;
            ushort ExpectedAmbient = 0x64;
            ushort ExpectedReflect = 0x10;
            ushort ExpectedDistance = 0x3412;

            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((int)((short)ExpectedAngle), Brick.SensorDevice(0).Value1);
            Assert.AreEqual((int)((short)ExpectedApeed), Brick.SensorDevice(0).Value2);
            Assert.AreEqual(0, Brick.SensorDevice(0).Value3);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual(1, Brick.SensorDevice(1).Value1);
            Assert.AreEqual(0, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(0, Brick.SensorDevice(1).Value3);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((int)((short)ExpectedAmbient), Brick.SensorDevice(2).Value1);
            Assert.AreEqual(5, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(ExpectedReflect, Brick.SensorDevice(2).Value3);
            Assert.AreEqual(
                Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((int)((short)ExpectedDistance), Brick.SensorDevice(3).Value1);
            Assert.AreEqual(1, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(0, Brick.SensorDevice(3).Value3);
        }
        #endregion
    }
}