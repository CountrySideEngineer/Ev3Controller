using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_50_00 : BrickUpdater
    {
        /// <summary>
        /// Updater sensor data, especially gyro sensor, device information of Ev3Brick sent
        /// by GetGyroSensor command.
        /// </summary>
        /// <param name="Command">GetGyroSensor command data.</param>
        /// <param name="Brick">Ev3Brick object to set received data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_50_00)
            {
                int Index = 0;
                int DataTopIndex = 4;
                int DevNum = Command.ResData[DataTopIndex++];
                for (Index = 0; Index < DevNum; Index++)
                {
                    int DataIndex = DataTopIndex + (Index * 3);
                    byte Port = Command.ResData[DataIndex++];
                    short AnglePos = (short)
                        ((ushort)Command.ResData[DataIndex] +
                        (((ushort)Command.ResData[DataIndex + 1]) << 8));
                    var Device = Brick.SensorDevice(Port);
                    Device.ConnectedPort = (Ev3Device.INPORT)Port;
                    Device.IsConnected = true;
                    Device.Value1 = AnglePos;
                    Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO;
                }
            }
        }
    }
}
