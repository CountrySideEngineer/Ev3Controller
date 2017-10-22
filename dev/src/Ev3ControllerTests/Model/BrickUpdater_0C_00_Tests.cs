using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using static Ev3Controller.Model.Ev3MotorDevice;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class BrickUpdater_0C_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of BrickUpdater_0C_00, update method
        [TestMethod()]
        [TestCategory("BrickUpdater_0C_00")]
        [TestCategory("BrickUpdater_0C_00_Update")]
        public void BrickUpdater_0C_00_Update_Test_001()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x03;

            var Updater = new BrickUpdater_0C_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_A, Brick.MotorDevice(0).ConnectedPort);
            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_B, Brick.MotorDevice(1).ConnectedPort);
            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_C, Brick.MotorDevice(2).ConnectedPort);
            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_D, Brick.MotorDevice(3).ConnectedPort);
            Assert.AreEqual(DEVICE_TYPE.MOTOR_DEVICE_NO_DEVICE, Brick.MotorDevice(0).DeviceType);
            Assert.AreEqual(DEVICE_TYPE.MOTOR_DEVICE_MEDIUM_MOTOR, Brick.MotorDevice(1).DeviceType);
            Assert.AreEqual(DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR, Brick.MotorDevice(2).DeviceType);
            Assert.AreEqual(DEVICE_TYPE.MOTOR_DEVICE_UNADJUSTED, Brick.MotorDevice(3).DeviceType);
            Assert.AreEqual("PORT_A", Brick.MotorDevice(0).Port);
            Assert.AreEqual("PORT_B", Brick.MotorDevice(1).Port);
            Assert.AreEqual("PORT_C", Brick.MotorDevice(2).Port);
            Assert.AreEqual("PORT_D", Brick.MotorDevice(3).Port);
            Assert.AreEqual("NO DEVICE", Brick.MotorDevice(0).Device);
            Assert.AreEqual("MEDIUM MOTOR", Brick.MotorDevice(1).Device);
            Assert.AreEqual("LARGE MOTOR", Brick.MotorDevice(2).Device);
            Assert.AreEqual("UnAdjusted", Brick.MotorDevice(3).Device);
            Assert.IsFalse(Brick.MotorDevice(0).IsConnected);
            Assert.IsTrue(Brick.MotorDevice(1).IsConnected);
            Assert.IsTrue(Brick.MotorDevice(2).IsConnected);
            Assert.IsTrue(Brick.MotorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_0C_00")]
        [TestCategory("BrickUpdater_0C_00_Update")]
        public void BrickUpdater_0C_00_Update_Test_002()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[4] = 0xFE;
            Command.ResData[5] = 0xFF;
            Command.ResData[6] = 0x04;
            Command.ResData[7] = 0x00;

            var Updater = new BrickUpdater_0C_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_A, Brick.MotorDevice(0).ConnectedPort);
            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_B, Brick.MotorDevice(1).ConnectedPort);
            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_C, Brick.MotorDevice(2).ConnectedPort);
            Assert.AreEqual(Ev3Device.OUTPORT.OUTPORT_D, Brick.MotorDevice(3).ConnectedPort);
            Assert.AreEqual(DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN, Brick.MotorDevice(0).DeviceType);
            Assert.AreEqual(DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN, Brick.MotorDevice(1).DeviceType);
            Assert.AreEqual(DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN, Brick.MotorDevice(2).DeviceType);
            Assert.AreEqual("PORT_A", Brick.MotorDevice(0).Port);
            Assert.AreEqual("PORT_B", Brick.MotorDevice(1).Port);
            Assert.AreEqual("PORT_C", Brick.MotorDevice(2).Port);
            Assert.AreEqual("Unknown", Brick.MotorDevice(0).Device);
            Assert.AreEqual("Unknown", Brick.MotorDevice(1).Device);
            Assert.AreEqual("Unknown", Brick.MotorDevice(2).Device);
            Assert.IsFalse(Brick.MotorDevice(0).IsConnected);
            Assert.IsFalse(Brick.MotorDevice(1).IsConnected);
            Assert.IsFalse(Brick.MotorDevice(2).IsConnected);
        }
        #endregion
    }
}