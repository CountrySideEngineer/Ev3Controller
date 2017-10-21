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
    public class Ev3SensorDevice_Tests
    {
        #region Unit test of constructor.
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_Constructor")]
        public void Ev3SensorDevice_Test()
        {
            var Device = new Ev3SensorDevice();

            Assert.AreEqual("", Device.Port);
            Assert.AreEqual("NO DEVICE", Device.Device);
            Assert.AreEqual(0, Device.Value1);
            Assert.AreEqual(0, Device.Value2);
            Assert.AreEqual(0, Device.Value3);
        }
        #endregion

        #region Unit test of GetPortName method.
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetPortName")]
        public void Ev3SensorDevice_GetPortName_Test_001()
        {
            var Device = new Ev3SensorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_A;

            Assert.AreEqual("PORT_A", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetPortName")]
        public void Ev3SensorDevice_GetPortName_Test_002()
        {
            var Device = new Ev3SensorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_B;

            Assert.AreEqual("PORT_B", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetPortName")]
        public void Ev3SensorDevice_GetPortName_Test_003()
        {
            var Device = new Ev3SensorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_C;

            Assert.AreEqual("PORT_C", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetPortName")]
        public void Ev3SensorDevice_GetPortName_Test_004()
        {
            var Device = new Ev3SensorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_D;

            Assert.AreEqual("PORT_D", Device.Port);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetPortName")]
        public void Ev3SensorDevice_GetPortName_Test_005()
        {
            var Device = new Ev3SensorDevice();
            Device.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_MAX;

            Assert.AreEqual("", Device.Port);
        }
        #endregion

        #region Unit test of GetPortName method.
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_001()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE;

            Assert.AreEqual("NO DEVICE", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_002()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC;

            Assert.AreEqual("ULTRASONIC", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_003()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO;

            Assert.AreEqual("GYRO", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_004()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH;

            Assert.AreEqual("TOUCH", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_005()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR;

            Assert.AreEqual("COLOR", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_006()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_HT_NXT_ACCEL;

            Assert.AreEqual("HTX", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_007()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NXT_TEMP;

            Assert.AreEqual("TEMPERATURE", Device.Device);
        }
        [TestMethod()]
        [TestCategory("Ev3SensorDevice")]
        [TestCategory("Ev3SensorDevice_GetDeviceName")]
        public void Ev3SensorDevice_GetDeviceName_Test_008()
        {
            var Device = new Ev3SensorDevice();
            Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_MAX;

            Assert.AreEqual("UNKNOWN", Device.Device);
        }
        #endregion
    }
}