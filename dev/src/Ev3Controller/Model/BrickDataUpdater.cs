using Ev3Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class BrickDataUpdater
    {
        #region Constructors and the Finalizer
        public BrickDataUpdater() { }
        #endregion

        #region Other methods and private properties in calling order
        public void UpdateViewModel(Ev3ControllerMainViewModel ViewModel)
        {
            this.UpdateMotorViewModel(ViewModel);
            this.UpdateSensorViewModel(ViewModel);
        }

        /// <summary>
        /// Reset device data by calling 
        /// </summary>
        /// <param name="ViewModel"></param>
        public void ResetViewModel(Ev3ControllerMainViewModel ViewModel)
        {
            for (int index = 0; index < 4; index++)
            {
                if (null != ViewModel.MotorViewModelArray[index])
                {
                    ViewModel.MotorViewModelArray[index].ResetDevice();
                }
                if (null != ViewModel.SensorViewModelArray[index])
                {
                    ViewModel.SensorViewModelArray[index].ResetDevice();
                }
            }
        }

        /// <summary>
        /// Set motor data into controller view model.
        /// </summary>
        /// <param name="ViewModel"></param>
        public void UpdateMotorViewModel(Ev3ControllerMainViewModel ViewModel)
        {
            var Brick = Ev3Brick.GetInstance();
            for (int index = 0; index < 4; index++)
            {
                var DeviceViewModel = ViewModel.MotorViewModelArray[index];
                try
                {
                    var Device = Brick.MotorDeviceArray[index];
                    DeviceViewModel.PortName = Device.Port;
                    DeviceViewModel.DeviceName = Device.Device;
                    DeviceViewModel.CurrentOutput = Device.Power;
                    DeviceViewModel.IsConnected = Device.IsConnected;
                    DeviceViewModel.CurrentOutputUnit = @"%";
                }
#pragma warning disable 168
                catch (NullReferenceException ex)
                {
                    DeviceViewModel.IsConnected = false;
                    DeviceViewModel.TargetOutput = 0;
                    DeviceViewModel.TargetOutputUnit = "";
                    DeviceViewModel.CurrentOutput = 0;
                    DeviceViewModel.CurrentOutputUnit = "";
                }
#pragma warning restore
            }
        }

        /// <summary>
        /// Set sensor data into controller view model.
        /// </summary>
        /// <param name="ViewModel"></param>
        public void UpdateSensorViewModel(Ev3ControllerMainViewModel ViewModel)
        {
            var Brick = Ev3Brick.GetInstance();
            for (int index = 0; index < 4; index++)
            {
                var DeviceViewModel = ViewModel.SensorViewModelArray[index];
                try
                {
                    var Device = Brick.SensorDeviceArray[index];
                    DeviceViewModel.PortName = Device.Port;
                    DeviceViewModel.DeviceName = Device.Device;
                    DeviceViewModel.IsConnected = true;
                    DeviceViewModel.SensorValue1 = Device.Value1;
                    DeviceViewModel.SensorValue1Unit = "";
                    DeviceViewModel.SensorValue2 = Device.Value2;
                    DeviceViewModel.SensorValue2Unit = "";
                    DeviceViewModel.SensorValue3 = Device.Value3;
                    DeviceViewModel.SensorValue3Unit = "";
                }
#pragma warning disable 168
                catch (NullReferenceException ex)
                {
                    DeviceViewModel.IsConnected = false;
                    DeviceViewModel.SensorValue1 = 0;
                    DeviceViewModel.SensorValue1Unit = "";
                    DeviceViewModel.SensorValue2 = 0;
                    DeviceViewModel.SensorValue2Unit = "";
                    DeviceViewModel.SensorValue3 = 0;
                    DeviceViewModel.SensorValue3Unit = "";
                }
#pragma warning restore
            }
        }
        #endregion
    }
}
