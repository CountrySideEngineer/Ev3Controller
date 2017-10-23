using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_30_00 : BrickUpdater
    {
        /// <summary>
        /// Update sensor data, especially color sensor color ambient light strength, device
        /// information of Ev3 Brick sent by GetColorSensor command.
        /// </summary>
        /// <param name="Command">GetColorSensor command data.</param>
        /// <param name="Brick">Ev3Brick object to set received data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_30_00)
            {
                int Index = 0;
                int DataTopIndex = 4;
                int DevNum = Command.ResData[DataTopIndex++];
                for (Index = 0; Index < DevNum; Index++)
                {
                    int DataIndex = DataTopIndex + (Index * 2);
                    byte Port = Command.ResData[DataIndex++];
                    byte Ambient = Command.ResData[DataIndex];
                    Brick.SensorDevice(Port).ConnectedPort = (Ev3Device.INPORT)Port;
                    Brick.SensorDevice(Port).IsConnected = true;
                    Brick.SensorDevice(Port).Value1 = Ambient;
                    Brick.SensorDevice(Port).DeviceType =
                        Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR;
                }
            }
        }
    }
}
