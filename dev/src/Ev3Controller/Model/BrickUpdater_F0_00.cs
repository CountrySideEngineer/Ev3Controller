using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;
using System.Diagnostics;

namespace Ev3Controller.Model
{
    public class BrickUpdater_F0_00 : BrickUpdater
    {
        /// <summary>
        /// Update sensor data by connected device data included in response data.
        /// </summary>
        /// <param name="Command">GetSonicSensor command data.</param>
        /// <param name="Brick">Ev3Brick object to set received data.</param>
        public override void Update(ACommand Command, Ev3Brick Brick)
        {
            Debug.Assert(Command != null);
            Debug.Assert(Brick != null);

            if (Command is Command_F0_00)
            {
                int Index = 0;
                int DataTopIndex = 4;
                int DataOffset = 0;

                BrickUpdater_F0_00_DevBase Updater = null;
                for (Index = 0; Index < 4; Index++)
                {
                    byte DeviceType = Command.ResData[DataTopIndex];
                    switch (DeviceType)
                    {
                        case 0x20:
                            Updater = new BrickUpdater_F0_00_Ultrasonic();
                            break;

                        case 0x30:
                            Updater = new BrickUpdater_F0_00_Color();
                            break;

                        case 0x40:
                            Updater = new BrickUpdater_F0_00_Touch();
                            break;

                        case 0x50:
                            Updater = new BrickUpdater_F0_00_Gyro();
                            break;

                        default:
                            Updater = null;
                            break;
                    }
                    try
                    {
                        DataOffset = Updater.Update(Command, Brick, Index, DataTopIndex);
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DataOffset = 2;
                    }
                    DataTopIndex += DataOffset;
                }
            }
        }

        public abstract class BrickUpdater_F0_00_DevBase
        {
            public virtual int Update(ACommand Command, Ev3Brick Brick, int Port, int StartIndex)
            {
                Brick.SensorDevice(Port).ConnectedPort = (Ev3Device.INPORT)Port;
                Brick.SensorDevice(Port).IsConnected = true;

                return 2;
            }
        }
        public class BrickUpdater_F0_00_Ultrasonic : BrickUpdater_F0_00_DevBase
        {
            public override int Update(ACommand Command, Ev3Brick Brick, int Port, int StartIndex)
            {
                short Distance = (short)
                    ((ushort)Command.ResData[StartIndex + 2] +
                    (((ushort)Command.ResData[StartIndex + 3]) << 8));
                byte IsListen = Command.ResData[StartIndex + 4];
                var Device = Brick.SensorDevice(Port);
                Device.Value1 = Distance;
                Device.Value2 = IsListen;
                Device.Value3 = 0;
                Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_ULTRASONIC;

                return (base.Update(Command, Brick, Port, StartIndex) + 3);
            }
        }
        public class BrickUpdater_F0_00_Color : BrickUpdater_F0_00_DevBase
        {
            public override int Update(ACommand Command, Ev3Brick Brick, int Port, int StartIndex)
            {
                var Device = Brick.SensorDevice(Port);
                Device.Value1 = Command.ResData[StartIndex + 2];
                Device.Value2 = Command.ResData[StartIndex + 3];
                Device.Value3 = Command.ResData[StartIndex + 4];
                Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_COLOR;

                return (base.Update(Command, Brick, Port, StartIndex) + 3);
            }
        }
        public class BrickUpdater_F0_00_Touch : BrickUpdater_F0_00_DevBase
        {
            public override int Update(ACommand Command, Ev3Brick Brick, int Port, int StartIndex)
            {
                var Device = Brick.SensorDevice(Port);
                Device.Value1 = Command.ResData[StartIndex + 2];
                Device.Value2 = 0;
                Device.Value3 = 0;
                Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_TOUCH;

                return (base.Update(Command, Brick, Port, StartIndex) + 1);
            }
        }
        public class BrickUpdater_F0_00_Gyro : BrickUpdater_F0_00_DevBase
        {
            public override int Update(ACommand Command, Ev3Brick Brick, int Port, int StartIndex)
            {
                short Angle = (short)
                    ((ushort)Command.ResData[StartIndex + 2] + 
                    (((ushort)Command.ResData[StartIndex + 3]) << 8));
                short Speed = (short)
                    ((ushort)Command.ResData[StartIndex + 4] +
                    (((ushort)Command.ResData[StartIndex + 5]) << 8));

                var Device = Brick.SensorDevice(Port);
                Device.Value1 = Angle;
                Device.Value2 = Speed;
                Device.Value3 = 0;
                Device.DeviceType = Ev3SensorDevice.DEVICE_TYPE.SENSOR_DEVICE_GYRO;

                return (base.Update(Command, Brick, Port, StartIndex) + 4);
            }
        }
    }
}
