using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.ViewModel;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class BrickDataUpdater_Tests : Ev3Brick_TestBase
    {
        #region Unit test of BrickDataUpdater constructor.
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_Constructor")]
        public void BrickDataUpdater_Test()
        {
        }
        #endregion

        #region Unit test of BrickDataUpdater constructor.
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateViewModel")]
        public void BrickDataUpdater_UpdateViewModel_Test()
        {
        }
        #endregion

        #region Unit test of UpdateMotorViewModel
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_001()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_A;
            MotorDevice.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR;
            MotorDevice.Power = 10;
            Brick.MotorDeviceArray[0] = MotorDevice;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsTrue(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.AreEqual("PORT_A", ViewModel.MotorViewModelArray[0].PortName);
            Assert.AreEqual("LARGE MOTOR", ViewModel.MotorViewModelArray[0].DeviceName);
            Assert.AreEqual(10, ViewModel.MotorViewModelArray[0].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[0].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_002()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_B;
            MotorDevice.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR;
            MotorDevice.Power = 11;
            Brick.MotorDeviceArray[1] = MotorDevice;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.AreEqual("PORT_B", ViewModel.MotorViewModelArray[1].PortName);
            Assert.AreEqual("LARGE MOTOR", ViewModel.MotorViewModelArray[1].DeviceName);
            Assert.AreEqual(11, ViewModel.MotorViewModelArray[1].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[1].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_003()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_C;
            MotorDevice.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR;
            MotorDevice.Power = 12;
            Brick.MotorDeviceArray[2] = MotorDevice;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.AreEqual("PORT_C", ViewModel.MotorViewModelArray[2].PortName);
            Assert.AreEqual("LARGE MOTOR", ViewModel.MotorViewModelArray[2].DeviceName);
            Assert.AreEqual(12, ViewModel.MotorViewModelArray[2].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[2].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_004()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_D;
            MotorDevice.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR;
            MotorDevice.Power = 13;
            Brick.MotorDeviceArray[3] = MotorDevice;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[3].IsConnected);
            Assert.AreEqual("PORT_D", ViewModel.MotorViewModelArray[3].PortName);
            Assert.AreEqual("LARGE MOTOR", ViewModel.MotorViewModelArray[3].DeviceName);
            Assert.AreEqual(13, ViewModel.MotorViewModelArray[3].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[3].CurrentOutputUnit);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_005()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice1 = new Ev3MotorDevice();
            var MotorDevice2 = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice1.Power = 13;
            MotorDevice2.Power = 23;
            Brick.MotorDeviceArray[0] = MotorDevice1;
            Brick.MotorDeviceArray[1] = MotorDevice2;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsTrue(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.AreEqual(13, ViewModel.MotorViewModelArray[0].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[0].CurrentOutputUnit);
            Assert.IsTrue(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.AreEqual(23, ViewModel.MotorViewModelArray[1].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[1].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_006()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice1 = new Ev3MotorDevice();
            var MotorDevice2 = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice1.Power = 13;
            MotorDevice2.Power = 23;
            Brick.MotorDeviceArray[0] = MotorDevice1;
            Brick.MotorDeviceArray[2] = MotorDevice2;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsTrue(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.AreEqual(13, ViewModel.MotorViewModelArray[0].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[0].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.AreEqual(23, ViewModel.MotorViewModelArray[2].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[2].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_007()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice1 = new Ev3MotorDevice();
            var MotorDevice2 = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice1.Power = 13;
            MotorDevice2.Power = 23;
            Brick.MotorDeviceArray[0] = MotorDevice1;
            Brick.MotorDeviceArray[3] = MotorDevice2;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsTrue(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.AreEqual(13, ViewModel.MotorViewModelArray[0].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[0].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[3].IsConnected);
            Assert.AreEqual(23, ViewModel.MotorViewModelArray[3].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[3].CurrentOutputUnit);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_008()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice1 = new Ev3MotorDevice();
            var MotorDevice2 = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice1.Power = 13;
            MotorDevice2.Power = 23;
            Brick.MotorDeviceArray[1] = MotorDevice1;
            Brick.MotorDeviceArray[2] = MotorDevice2;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.AreEqual(13, ViewModel.MotorViewModelArray[1].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[1].CurrentOutputUnit);
            Assert.IsTrue(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.AreEqual(23, ViewModel.MotorViewModelArray[2].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[2].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_009()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice1 = new Ev3MotorDevice();
            var MotorDevice2 = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice1.Power = 13;
            MotorDevice2.Power = 23;
            Brick.MotorDeviceArray[1] = MotorDevice1;
            Brick.MotorDeviceArray[3] = MotorDevice2;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.AreEqual(13, ViewModel.MotorViewModelArray[1].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[1].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[3].IsConnected);
            Assert.AreEqual(23, ViewModel.MotorViewModelArray[3].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[3].CurrentOutputUnit);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateMotorViewModel_Test_010()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice1 = new Ev3MotorDevice();
            var MotorDevice2 = new Ev3MotorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
            }
            MotorDevice1.Power = 13;
            MotorDevice2.Power = 23;
            Brick.MotorDeviceArray[2] = MotorDevice1;
            Brick.MotorDeviceArray[3] = MotorDevice2;
            Updater.UpdateMotorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.IsTrue(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.AreEqual(13, ViewModel.MotorViewModelArray[2].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[2].CurrentOutputUnit);
            Assert.IsTrue(ViewModel.MotorViewModelArray[3].IsConnected);
            Assert.AreEqual(23, ViewModel.MotorViewModelArray[3].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[3].CurrentOutputUnit);
        }
        #endregion

        #region Unit test of UpdateMotorViewModel
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateSensorViewModel_Test_001()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var SensorDevice = new Ev3SensorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.SensorViewModelArray[index] = new Ev3SensorDeviceViewModel();
            }
            SensorDevice.ConnectedPort = Ev3Device.INPORT.INPORT_1;
            SensorDevice.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR;
            SensorDevice.Value1 = 10;
            SensorDevice.Value2 = 11;
            SensorDevice.Value3 = 12;
            Brick.SensorDeviceArray[0] = SensorDevice;
            Updater.UpdateSensorViewModel(ViewModel);

            Assert.IsTrue(ViewModel.SensorViewModelArray[0].IsConnected);
            Assert.AreEqual("PORT_1", ViewModel.SensorViewModelArray[0].PortName);
            Assert.AreEqual("COLOR", ViewModel.SensorViewModelArray[0].DeviceName);
            Assert.AreEqual(10, ViewModel.SensorViewModelArray[0].SensorValue1);
            Assert.AreEqual(11, ViewModel.SensorViewModelArray[0].SensorValue2);
            Assert.AreEqual(12, ViewModel.SensorViewModelArray[0].SensorValue3);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[0].SensorValue1Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[0].SensorValue2Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[0].SensorValue3Unit);
            Assert.IsFalse(ViewModel.SensorViewModelArray[1].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[2].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateSensorViewModel_Test_002()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var SensorDevice = new Ev3SensorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.SensorViewModelArray[index] = new Ev3SensorDeviceViewModel();
            }
            SensorDevice.ConnectedPort = Ev3Device.INPORT.INPORT_2;
            SensorDevice.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO;
            SensorDevice.Value1 = 10;
            SensorDevice.Value2 = 11;
            SensorDevice.Value3 = 12;
            Brick.SensorDeviceArray[1] = SensorDevice;
            Updater.UpdateSensorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.SensorViewModelArray[0].IsConnected);
            Assert.IsTrue(ViewModel.SensorViewModelArray[1].IsConnected);
            Assert.AreEqual("PORT_2", ViewModel.SensorViewModelArray[1].PortName);
            Assert.AreEqual("GYRO", ViewModel.SensorViewModelArray[1].DeviceName);
            Assert.AreEqual(10, ViewModel.SensorViewModelArray[1].SensorValue1);
            Assert.AreEqual(11, ViewModel.SensorViewModelArray[1].SensorValue2);
            Assert.AreEqual(12, ViewModel.SensorViewModelArray[1].SensorValue3);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[1].SensorValue1Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[1].SensorValue2Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[1].SensorValue3Unit);
            Assert.IsFalse(ViewModel.SensorViewModelArray[2].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateSensorViewModel_Test_003()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var SensorDevice = new Ev3SensorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.SensorViewModelArray[index] = new Ev3SensorDeviceViewModel();
            }
            SensorDevice.ConnectedPort = Ev3Device.INPORT.INPORT_3;
            SensorDevice.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH;
            SensorDevice.Value1 = 10;
            SensorDevice.Value2 = 11;
            SensorDevice.Value3 = 12;
            Brick.SensorDeviceArray[2] = SensorDevice;
            Updater.UpdateSensorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.SensorViewModelArray[0].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[1].IsConnected);
            Assert.IsTrue(ViewModel.SensorViewModelArray[2].IsConnected);
            Assert.AreEqual("PORT_3", ViewModel.SensorViewModelArray[2].PortName);
            Assert.AreEqual("TOUCH", ViewModel.SensorViewModelArray[2].DeviceName);
            Assert.AreEqual(10, ViewModel.SensorViewModelArray[2].SensorValue1);
            Assert.AreEqual(11, ViewModel.SensorViewModelArray[2].SensorValue2);
            Assert.AreEqual(12, ViewModel.SensorViewModelArray[2].SensorValue3);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[2].SensorValue1Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[2].SensorValue2Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[2].SensorValue3Unit);
            Assert.IsFalse(ViewModel.SensorViewModelArray[3].IsConnected);
        }
        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateMotorViewModel_Test")]
        public void BrickDataUpdater_UpdateSensorViewModel_Test_004()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var SensorDevice = new Ev3SensorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.SensorViewModelArray[index] = new Ev3SensorDeviceViewModel();
            }
            SensorDevice.ConnectedPort = Ev3Device.INPORT.INPORT_4;
            SensorDevice.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC;
            SensorDevice.Value1 = 10;
            SensorDevice.Value2 = 11;
            SensorDevice.Value3 = 12;
            Brick.SensorDeviceArray[3] = SensorDevice;
            Updater.UpdateSensorViewModel(ViewModel);

            Assert.IsFalse(ViewModel.SensorViewModelArray[0].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[1].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[2].IsConnected);
            Assert.IsTrue(ViewModel.SensorViewModelArray[3].IsConnected);
            Assert.AreEqual("PORT_4", ViewModel.SensorViewModelArray[3].PortName);
            Assert.AreEqual("ULTRASONIC", ViewModel.SensorViewModelArray[3].DeviceName);
            Assert.AreEqual(10, ViewModel.SensorViewModelArray[3].SensorValue1);
            Assert.AreEqual(11, ViewModel.SensorViewModelArray[3].SensorValue2);
            Assert.AreEqual(12, ViewModel.SensorViewModelArray[3].SensorValue3);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[3].SensorValue1Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[3].SensorValue2Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[3].SensorValue3Unit);
        }
        #endregion

        [TestMethod()]
        [TestCategory("BrickDataUpdater")]
        [TestCategory("BrickDataUpdater_UpdateViewModel_Test")]
        public void BrickDataUpdater_UpdateViewModel_Test_001()
        {
            var Updater = new BrickDataUpdater();
            var ViewModel = new Ev3ControllerMainViewModel();
            var MotorDevice = new Ev3MotorDevice();
            var SensorDevice = new Ev3SensorDevice();
            var Brick = Ev3Brick.GetInstance();

            for (int index = 0; index < 4; index++)
            {
                ViewModel.MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
                ViewModel.SensorViewModelArray[index] = new Ev3SensorDeviceViewModel();
            }
            MotorDevice.ConnectedPort = Ev3Device.OUTPORT.OUTPORT_A;
            MotorDevice.DeviceType = Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR;
            MotorDevice.Power = 10;
            Brick.MotorDeviceArray[0] = MotorDevice;
            SensorDevice.ConnectedPort = Ev3Device.INPORT.INPORT_1;
            SensorDevice.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR;
            SensorDevice.Value1 = 10;
            SensorDevice.Value2 = 11;
            SensorDevice.Value3 = 12;
            Brick.SensorDeviceArray[0] = SensorDevice;
            Updater.UpdateViewModel(ViewModel);

            Assert.IsTrue(ViewModel.MotorViewModelArray[0].IsConnected);
            Assert.AreEqual("PORT_A", ViewModel.MotorViewModelArray[0].PortName);
            Assert.AreEqual("LARGE MOTOR", ViewModel.MotorViewModelArray[0].DeviceName);
            Assert.AreEqual(10, ViewModel.MotorViewModelArray[0].CurrentOutput);
            Assert.AreEqual("%", ViewModel.MotorViewModelArray[0].CurrentOutputUnit);
            Assert.IsFalse(ViewModel.MotorViewModelArray[1].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[2].IsConnected);
            Assert.IsFalse(ViewModel.MotorViewModelArray[3].IsConnected);
            Assert.IsTrue(ViewModel.SensorViewModelArray[0].IsConnected);
            Assert.AreEqual("PORT_1", ViewModel.SensorViewModelArray[0].PortName);
            Assert.AreEqual("COLOR", ViewModel.SensorViewModelArray[0].DeviceName);
            Assert.AreEqual(10, ViewModel.SensorViewModelArray[0].SensorValue1);
            Assert.AreEqual(11, ViewModel.SensorViewModelArray[0].SensorValue2);
            Assert.AreEqual(12, ViewModel.SensorViewModelArray[0].SensorValue3);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[0].SensorValue1Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[0].SensorValue2Unit);
            Assert.AreEqual("", ViewModel.SensorViewModelArray[0].SensorValue3Unit);
            Assert.IsFalse(ViewModel.SensorViewModelArray[1].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[2].IsConnected);
            Assert.IsFalse(ViewModel.SensorViewModelArray[3].IsConnected);
        }
    }
}