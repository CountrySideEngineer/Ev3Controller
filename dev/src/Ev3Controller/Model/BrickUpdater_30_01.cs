using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_30_01 : BrickUpdater
    {
        /// <summary>
        /// Updater sensor data, especially color sensor refrection data, device information
        /// of Ev3Brick sent by GetColorSensor command.
        /// </summary>
        /// <param name="Command">GetColorSensor command data.</param>
        /// <param name="Brick">Ev3Brick object to set received data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_30_01)
            {
                int Index = 0;
                int DataTopIndex = 4;
                int DevNum = Command.ResData[DataTopIndex++];
                for (Index = 0; Index < DevNum; Index++)
                {
                    int DataIndex = DataTopIndex + (DevNum * 2);
                    byte Port = Command.ResData[DataIndex++];
                    byte Color = Command.ResData[DataIndex];
                    Brick.SensorDevice(Port).ConnectedPort = (Ev3SensorDevice.INPORT)Port;
                    Brick.SensorDevice(Port).IsConnected = true;
                    Brick.SensorDevice(Port).Value2 = Color;
                }
            }
        }
    }
}
