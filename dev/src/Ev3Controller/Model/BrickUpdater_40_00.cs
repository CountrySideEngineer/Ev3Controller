using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_40_00 : BrickUpdater
    {
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_40_00)
            {
                int Index = 0;
                int DataTopIndex = 4;
                int DevNum = Command.ResData[DataTopIndex++];
                for (Index = 0; Index < DevNum; Index++)
                {
                    int DataIndex = DataTopIndex + (Index * 2);
                    byte Port = Command.ResData[DataIndex++];
                    byte IsTouch = Command.ResData[DataIndex];
                    var Device = Brick.SensorDevice(Port);
                    Device.ConnectedPort = (Ev3Device.INPORT)Port;
                    Device.IsConnected = true;
                    Device.Value1 = IsTouch;
                    Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH;
                }
            }
        }
    }
}
