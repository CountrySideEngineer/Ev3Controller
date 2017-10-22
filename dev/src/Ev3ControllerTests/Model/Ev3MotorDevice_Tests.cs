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
    public class Ev3MotorDevice_Tests
    {
        #region Unit test of Constructor.
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_Constructor")]
        public void Ev3MotorDevice_Test_001()
        {
            var Device = new Ev3MotorDevice();
            Assert.AreEqual("", Device.Port);
            Assert.AreEqual("NO DEVICE", Device.Device);
            Assert.AreEqual(0, Device.Power);
            Assert.AreEqual(0, Device.Counts);
        }
        #endregion

        #region Unit test of GetPortName method.
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetPortName")]
        public void Ev3MotorDevice_GetPortName_Test_001()
        {
            var Device = new Ev3MotorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_A;

            Assert.AreEqual("PORT_A", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetPortName")]
        public void Ev3MotorDevice_GetPortName_Test_002()
        {
            var Device = new Ev3MotorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_B;

            Assert.AreEqual("PORT_B", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetPortName")]
        public void Ev3MotorDevice_GetPortName_Test_003()
        {
            var Device = new Ev3MotorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_C;

            Assert.AreEqual("PORT_C", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetPortName")]
        public void Ev3MotorDevice_GetPortName_Test_004()
        {
            var Device = new Ev3MotorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_D;

            Assert.AreEqual("PORT_D", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetPortName")]
        public void Ev3MotorDevice_GetPortName_Test_005()
        {
            var Device = new Ev3MotorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_MAX;

            Assert.AreEqual("", Device.Port);
        }
        #endregion

        #region Unit test of GetDeviceName()
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetDeviceName")]
        public void Ev3MotorDevice_GetDeviceName_Test_001()
        {
            var Device = new Ev3MotorDevice();
            Device.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_NO_DEVICE;

            Assert.AreEqual("NO DEVICE", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetDeviceName")]
        public void Ev3MotorDevice_GetDeviceName_Test_002()
        {
            var Device = new Ev3MotorDevice();
            Device.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR;

            Assert.AreEqual("LARGE MOTOR", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetDeviceName")]
        public void Ev3MotorDevice_GetDeviceName_Test_003()
        {
            var Device = new Ev3MotorDevice();
            Device.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_MEDIUM_MOTOR;

            Assert.AreEqual("MEDIUM MOTOR", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetDeviceName")]
        public void Ev3MotorDevice_GetDeviceName_Test_004()
        {
            var Device = new Ev3MotorDevice();
            Device.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_UNADJUSTED;

            Assert.AreEqual("UnAdjusted", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetDeviceName")]
        public void Ev3MotorDevice_GetDeviceName_Test_005()
        {
            var Device = new Ev3MotorDevice();
            Device.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN;

            Assert.AreEqual("Unknown", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3MotorDevice")]
        [TestCategory("Ev3MotorDevice_GetDeviceName")]
        public void Ev3MotorDevice_GetDeviceName_Test_006()
        {
            var Device = new Ev3MotorDevice();
            Device.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_MAX;

            Assert.AreEqual("Unknown", Device.Device);
        }
        #endregion
    }
}