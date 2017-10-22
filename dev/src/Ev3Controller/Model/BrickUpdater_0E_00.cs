using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;
using static Ev3Controller.Model.Ev3SensorDevice;

namespace Ev3Controller.Model
{
    public class BrickUpdater_0E_00 : BrickUpdater
    {
        #region Public read-only static fields
        protected static readonly Dictionary<byte, Ev3SensorDevice.DEVICE_TYPE>
            DeviceTypeDictionary = new Dictionary<byte, Ev3SensorDevice.DEVICE_TYPE>()
            {
                { 0x00, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE },
                { 0x01, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC },
                { 0x02, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO },
                { 0x03, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH },
                { 0x04, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR },
                { 0x05, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_HT_NXT_ACCEL },
                { 0x06, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_NXT_TEMP },
                { 0xFF, Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_UNKNOWN },
            };
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Update sensor device information of Ev3 Brick by GetSensors command.
        /// </summary>
        /// <param name="Command">GetSensors command.</param>
        /// <param name="Brick">Object to set data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_0E_00)
            {
                int Index = 0;
                int DataTopIndex = 4;
                for (Index = 0; Index < 4; Index++)
                {
                    Brick.SensorDevice(Index).ConnectedPort = (Ev3Device.INPORT)Index;

                    DEVICE_TYPE DeviceType = DEVICE_TYPE.SENSOR_DEVICE_NO_DEVICE;
                    byte Type = Command.ResData[DataTopIndex + Index];
                    bool HasValue = DeviceTypeDictionary.ContainsKey(Type);
                    if (HasValue)
                    {
                        DeviceType = DeviceTypeDictionary[Type];
                    }
                    else
                    {
                        DeviceType = DEVICE_TYPE.SENSOR_DEVICE_UNKNOWN;
                    }
                    Brick.SensorDevice(Index).DeviceType = DeviceType;
                    switch (DeviceType)
                    {
                        case DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC:
                        case DEVICE_TYPE.SENSOR_DEVICE_GYRO:
                        case DEVICE_TYPE.SENSOR_DEVICE_TOUCH:
                        case DEVICE_TYPE.SENSOR_DEVICE_COLOR:
                        case DEVICE_TYPE.SENSOR_DEVICE_HT_NXT_ACCEL:
                        case DEVICE_TYPE.SENSOR_DEVICE_NXT_TEMP:
                            Brick.SensorDevice(Index).IsConnected = true;
                            break;

                        default:
                            Brick.SensorDevice(Index).IsConnected = false;
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
