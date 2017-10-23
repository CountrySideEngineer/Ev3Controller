using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_20_00 : BrickUpdater
    {
        /// <summary>
        /// Update senor, especiallu ultra sonic sensor, device information of Ev3 Brick
        /// sent by GetSonicSensor command.
        /// </summary>
        /// <param name="Command">GetSonicSensor command data.</param>
        /// <param name="Brick">Ev3Brick object to set received data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_20_00)
            {
                int Index = 0;
                int DataTopIndex = 4;
                int DevNum = Command.ResData[DataTopIndex++];
                for (Index = 0; Index < DevNum; Index++)
                {
                    int DataIndex = DataTopIndex + (Index * 3);
                    byte Port = Command.ResData[DataIndex++];
                    ushort Dist = (ushort)(
                        (ushort)Command.ResData[DataIndex] +
                        (((ushort)Command.ResData[DataIndex + 1]) << 8));
                    Brick.SensorDevice(Port).ConnectedPort = (Ev3Device.INPORT)Port;
                    Brick.SensorDevice(Port).IsConnected = true;
                    Brick.SensorDevice(Port).Value1 = (int)Dist;
                    Brick.SensorDevice(Port).DeviceType =
                        Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC;
                }
            }
        }
    }
}
