using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class EV3Brick_Tests
    {
        #region Unit test of "MotorDevice" method.
        [TestMethod()]
        [TestCategory("EV3Brick_SensorDevice")]
        public void EV3Brick_SensorDevice_Test_001()
        {
            var Brick = new EV3Brick();
            var SensorDevice = Brick.SensorDevice(0);

            Assert.AreEqual(0, SensorDevice.Value1);
            Assert.AreEqual(0, SensorDevice.Value2);
            Assert.AreEqual(0, SensorDevice.Value3);

            SensorDevice.Value1 = 1;
            SensorDevice.Value2 = 2;
            SensorDevice.Value3 = 3;

            var SensorDevice2 = Brick.SensorDevice(0);
            Assert.AreEqual(1, SensorDevice2.Value1);
            Assert.AreEqual(2, SensorDevice2.Value2);
            Assert.AreEqual(3, SensorDevice2.Value3);
        }
        [TestMethod()]
        [TestCategory("EV3Brick_SensorDevice")]
        public void EV3Brick_SensorDevice_Test_002()
        {
            var Brick = new EV3Brick();
            var SensorDevice = Brick.SensorDevice(3);

            Assert.AreEqual(0, SensorDevice.Value1);
            Assert.AreEqual(0, SensorDevice.Value2);
            Assert.AreEqual(0, SensorDevice.Value3);
        }
        [TestMethod()]
        [TestCategory("EV3Brick_SensorDevice")]
        public void EV3Brick_SensorDevice_Test_003()
        {
            var Brick = new EV3Brick();
            var SensorDevice = Brick.SensorDevice(-1);

            Assert.IsNull(SensorDevice);
        }
        [TestMethod()]
        [TestCategory("EV3Brick_SensorDevice")]
        public void EV3Brick_SensorDevice_Test_004()
        {
            var Brick = new EV3Brick();
            var SensorDevice = Brick.SensorDevice(4);

            Assert.IsNull(SensorDevice);
        }
        #endregion

        #region Unit test of "SensorDevice" method
        [TestMethod()]
        [TestCategory("EV3Brick_MotorDevice")]
        public void EV3Brick_MotorDevice_Test_001()
        {
            var Brick = new EV3Brick();
            var Device = Brick.MotorDevice(0);

            Assert.AreEqual(0, Device.Power);
            Assert.AreEqual(0, Device.Counts);

            Device.Power = 1;
            Device.Counts = 2;

            var SensorDevice2 = Brick.SensorDevice(0);
            Assert.AreEqual(1, Device.Power);
            Assert.AreEqual(2, Device.Counts);
        }
        [TestMethod()]
        [TestCategory("EV3Brick_MotorDevice")]
        public void EV3Brick_MotorDevice_Test_002()
        {
            var Brick = new EV3Brick();
            var Device = Brick.MotorDevice(3);

            Assert.AreEqual(0, Device.Power);
            Assert.AreEqual(0, Device.Counts);
        }
        [TestMethod()]
        [TestCategory("EV3Brick_MotorDevice")]
        public void EV3Brick_MotorDevice_Test_003()
        {
            var Brick = new EV3Brick();
            var Device = Brick.MotorDevice(-1);

            Assert.IsNull(Device);
        }
        [TestMethod()]
        [TestCategory("EV3Brick_MotorDevice")]
        public void EV3Brick_MotorDevice_Test_004()
        {
            var Brick = new EV3Brick();
            var Device = Brick.MotorDevice(4);

            Assert.IsNull(Device);
        }
        #endregion
    }
}