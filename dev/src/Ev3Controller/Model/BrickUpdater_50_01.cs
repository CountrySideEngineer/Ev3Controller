using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_50_01 : BrickUpdater
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

            if (Command is Command_50_01)
            {
                int Index = 0;
                int DataTopIndex = 4;
                int DevNum = Command.ResData[DataTopIndex++];
                for (Index = 0; Index < DevNum; Index++)
                {
                    int DataIndex = DataTopIndex + (Index * 3);
                    byte Port = Command.ResData[DataIndex++];
                    short Velocity = (short)
                        ((ushort)Command.ResData[DataIndex] +
                        (((ushort)Command.ResData[DataIndex + 1]) << 8));
                    Brick.SensorDevice(Port).ConnectedPort = (Ev3Device.INPORT)Port;
                    Brick.SensorDevice(Port).IsConnected = true;
                    Brick.SensorDevice(Port).Value2 = Velocity;
                    Brick.SensorDevice(Port).DeviceType =
                        Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO;
                }
            }
        }
    }
}
