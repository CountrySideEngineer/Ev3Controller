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
    public class BrickUpdater_20_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of Update method of BrickUpdater_20_00.
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_001()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x02;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0x0201, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_002()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0xAA;
            Command.ResData[7] = 0x55;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x01, (Brick.SensorDevice(1).ConnectedPort));
            Assert.AreEqual(0x55AA, (Brick.SensorDevice(1).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_003()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x02, (Brick.SensorDevice(2).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(2).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_004()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x03, (Brick.SensorDevice(3).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(3).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_005()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x11;
            Command.ResData[10] = 0x22;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x01, (Brick.SensorDevice(1).ConnectedPort));
            Assert.AreEqual(0x2211, (Brick.SensorDevice(1).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_006()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x33;
            Command.ResData[10] = 0x44;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x02, (Brick.SensorDevice(2).ConnectedPort));
            Assert.AreEqual(0x4433, (Brick.SensorDevice(2).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_007()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;
            Command.ResData[8] = 0x03;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0x66;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x03, (Brick.SensorDevice(3).ConnectedPort));
            Assert.AreEqual(0x6655, (Brick.SensorDevice(3).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_008()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[14];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x11;
            Command.ResData[10] = 0x22;
            Command.ResData[11] = 0x02;
            Command.ResData[12] = 0x33;
            Command.ResData[13] = 0x44;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x01, (Brick.SensorDevice(1).ConnectedPort));
            Assert.AreEqual(0x2211, (Brick.SensorDevice(1).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x02, (Brick.SensorDevice(2).ConnectedPort));
            Assert.AreEqual(0x4433, (Brick.SensorDevice(2).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_009()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[14];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x11;
            Command.ResData[10] = 0x22;
            Command.ResData[11] = 0x03;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0x66;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x01, (Brick.SensorDevice(1).ConnectedPort));
            Assert.AreEqual(0x2211, (Brick.SensorDevice(1).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x03, (Brick.SensorDevice(3).ConnectedPort));
            Assert.AreEqual(0x6655, (Brick.SensorDevice(3).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_010()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[14];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x55;
            Command.ResData[7] = 0xAA;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x33;
            Command.ResData[10] = 0x44;
            Command.ResData[11] = 0x03;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0x66;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0xAA55, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x02, (Brick.SensorDevice(2).ConnectedPort));
            Assert.AreEqual(0x4433, (Brick.SensorDevice(2).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x03, (Brick.SensorDevice(3).ConnectedPort));
            Assert.AreEqual(0x6655, (Brick.SensorDevice(3).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_011()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[14];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x11;
            Command.ResData[7] = 0x22;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x33;
            Command.ResData[10] = 0x44;
            Command.ResData[11] = 0x03;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0x66;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x01, (Brick.SensorDevice(1).ConnectedPort));
            Assert.AreEqual(0x2211, (Brick.SensorDevice(1).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x02, (Brick.SensorDevice(2).ConnectedPort));
            Assert.AreEqual(0x4433, (Brick.SensorDevice(2).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x03, (Brick.SensorDevice(3).ConnectedPort));
            Assert.AreEqual(0x6655, (Brick.SensorDevice(3).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_012()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[17];
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x11;
            Command.ResData[7] = 0x22;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x33;
            Command.ResData[10] = 0x44;
            Command.ResData[11] = 0x03;
            Command.ResData[12] = 0x55;
            Command.ResData[13] = 0x66;
            Command.ResData[14] = 0x00;
            Command.ResData[15] = 0xAA;
            Command.ResData[16] = 0x55;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0x55AA, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x01, (Brick.SensorDevice(1).ConnectedPort));
            Assert.AreEqual(0x2211, (Brick.SensorDevice(1).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x02, (Brick.SensorDevice(2).ConnectedPort));
            Assert.AreEqual(0x4433, (Brick.SensorDevice(2).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x03, (Brick.SensorDevice(3).ConnectedPort));
            Assert.AreEqual(0x6655, (Brick.SensorDevice(3).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_00")]
        [TestCategory("BrickUpdater_20_00_Update")]
        public void BrickUpdater_20_00_Update_Test_013()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[17];
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x77;
            Command.ResData[7] = 0x88;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x55;
            Command.ResData[10] = 0x66;
            Command.ResData[11] = 0x01;
            Command.ResData[12] = 0x33;
            Command.ResData[13] = 0x44;
            Command.ResData[14] = 0x00;
            Command.ResData[15] = 0x11;
            Command.ResData[16] = 0x22;

            var Updater = new BrickUpdater_20_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x00, (Brick.SensorDevice(0).ConnectedPort));
            Assert.AreEqual(0x2211, (Brick.SensorDevice(0).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x01, (Brick.SensorDevice(1).ConnectedPort));
            Assert.AreEqual(0x4433, (Brick.SensorDevice(1).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x02, (Brick.SensorDevice(2).ConnectedPort));
            Assert.AreEqual(0x6655, (Brick.SensorDevice(2).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0x03, (Brick.SensorDevice(3).ConnectedPort));
            Assert.AreEqual(0x8877, (Brick.SensorDevice(3).Value1));
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        #endregion
    }
}