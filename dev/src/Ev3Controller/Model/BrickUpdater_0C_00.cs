using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;
using static Ev3Controller.Model.Ev3MotorDevice;

namespace Ev3Controller.Model
{
    public class BrickUpdater_0C_00 : BrickUpdater
    {
        #region Public read-only static fields
        protected static readonly Dictionary<byte, Ev3MotorDevice.DEVICE_TYPE>
            DeviceTypeDictionary = new Dictionary<byte, Ev3MotorDevice.DEVICE_TYPE>()
            {
                { 0x00, Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_NO_DEVICE },
                { 0x01, Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_MEDIUM_MOTOR },
                { 0x02, Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR },
                { 0x03, Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_UNADJUSTED },
                { 0xFE, Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN },
                { 0xFF, Ev3MotorDevice.DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN },
            };
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Update motor device information of Ev3 Brick by GetMotors command.
        /// </summary>
        /// <param name="Command">GetMotors command.</param>
        /// <param name="Brick">Object to set data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_0C_00)
            {
                int Index = 0;
                int DataTopIndex = 4;
                for (Index = 0; Index < 4; Index++)
                {
                    Brick.MotorDevice(Index).ConnectedPort = (Ev3Device.OUTPORT)Index;

                    DEVICE_TYPE DeviceType = DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN;
                    byte Type = Command.ResData[DataTopIndex + Index];
                    bool HasValue = DeviceTypeDictionary.ContainsKey(Type);
                    if (HasValue)
                    {
                        DeviceType = DeviceTypeDictionary[Type];
                    }
                    else
                    {
                        DeviceType = DEVICE_TYPE.MOTOR_DEVICE_UNKNOWN;
                    }
                    Brick.MotorDevice(Index).DeviceType = DeviceType;
                    switch (DeviceType)
                    {
                        case DEVICE_TYPE.MOTOR_DEVICE_MEDIUM_MOTOR:
                        case DEVICE_TYPE.MOTOR_DEVICE_LARGE_MOTOR:
                        case DEVICE_TYPE.MOTOR_DEVICE_UNADJUSTED:
                            Brick.MotorDevice(Index).IsConnected = true;
                            break;

                        default:
                            Brick.MotorDevice(Index).IsConnected = false;
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
