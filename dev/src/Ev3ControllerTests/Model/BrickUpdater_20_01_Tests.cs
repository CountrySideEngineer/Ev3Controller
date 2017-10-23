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
    public class BrickUpdater_20_01_Tests : Ev3Brick_TestBase
    {
        #region Unit test of Update method of BrickUpdater_20_01.
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_001()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_002()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_003()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x00;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_004()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_005()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x00;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_006()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_007()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x00;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_008()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_009()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x01;
            Command.ResData[8] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_010()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x01;
            Command.ResData[8] = 0x00;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_011()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x02;
            Command.ResData[8] = 0x00;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_012()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x02;
            Command.ResData[8] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_013()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x00;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_014()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_015()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_016()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_017()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_018()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[9];
            Command.ResData[4] = 0x02;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x01;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_019()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x01;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x02;
            Command.ResData[10] = 0x02;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x02, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_020()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x01;
            Command.ResData[8] = 0x01;
            Command.ResData[9] = 0x03;
            Command.ResData[10] = 0x03;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(2).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x03, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_021()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x02;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x03;
            Command.ResData[10] = 0x03;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x00, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsFalse(Brick.SensorDevice(1).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x02, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x03, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_022()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[11];
            Command.ResData[4] = 0x03;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x02;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x03;
            Command.ResData[10] = 0x03;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsFalse(Brick.SensorDevice(0).IsConnected);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x02, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x03, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_20_01")]
        [TestCategory("BrickUpdater_20_01_Update")]
        public void BrickUpdater_20_01_Update_Test_023()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[13];
            Command.ResData[4] = 0x04;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x02;
            Command.ResData[8] = 0x02;
            Command.ResData[9] = 0x03;
            Command.ResData[10] = 0x03;
            Command.ResData[11] = 0x00;
            Command.ResData[12] = 0x04;

            var Updater = new BrickUpdater_20_01();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.IsTrue(Brick.SensorDevice(0).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)0, Brick.SensorDevice(0).ConnectedPort);
            Assert.AreEqual(0x04, Brick.SensorDevice(0).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(0).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(1).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)1, Brick.SensorDevice(1).ConnectedPort);
            Assert.AreEqual(0x01, Brick.SensorDevice(1).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(1).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(2).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)2, Brick.SensorDevice(2).ConnectedPort);
            Assert.AreEqual(0x02, Brick.SensorDevice(2).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(2).DeviceType);
            Assert.IsTrue(Brick.SensorDevice(3).IsConnected);
            Assert.AreEqual((Ev3Device.INPORT)3, Brick.SensorDevice(3).ConnectedPort);
            Assert.AreEqual(0x03, Brick.SensorDevice(3).Value2);
            Assert.AreEqual(Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC,
                Brick.SensorDevice(3).DeviceType);
        }
        #endregion
    }
}