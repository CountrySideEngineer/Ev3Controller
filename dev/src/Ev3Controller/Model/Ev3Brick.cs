using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class Ev3Brick
    {
        #region Constructors and the Finalizer
        protected Ev3Brick() { }
        #endregion

        #region Public Properties
        /// <summary>
        /// Battery of EV3 Brick.
        /// </summary>
        protected Power _Battery;
        public Power Battery
        {
            get
            {
                if (null == this._Battery )
                {
                    this._Battery = new Power();
                }
                return this._Battery;
            }
            set { this.Battery = value; }
        }

        /// <summary>
        /// Led color data.
        /// </summary>
        protected LedColor _Led;
        public LedColor Led
        {
            get
            {
                if (null == this._Led)
                {
                    this._Led = new LedColor();
                }
                return this._Led;
            }
        }

        /// <summary>
        /// State of safe.
        /// </summary>
        protected SafeState _State;
        public SafeState State
        {
            get
            {
                if (null == this._State)
                {
                    this._State = new SafeState();
                }
                return this._State;
            }
        }

        /// <summary>
        /// Application version running on Ev3.
        /// </summary>
        protected AppVersion _Version;
        public AppVersion Version
        {
            get
            {
                if (null == this._Version)
                {
                    this._Version = new AppVersion();
                }
                return this._Version;
            }
        }

        /// <summary>
        /// Sensor device data.
        /// </summary>
        protected Ev3SensorDevice[] _SensorDevice;

        /// <summary>
        /// Motor device data.
        /// </summary>
        protected Ev3MotorDevice[] _MotorDevice;

        /// <summary>
        /// Instance for singleton.
        /// </summary>
        protected static Ev3Brick _Instance = new Ev3Brick();
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Returns the MotorDevice object specified by PortIndex, index of array. 
        /// </summary>
        /// <param name="PortIndex">Abstracted port number.</param>
        /// <returns></returns>
        public Ev3MotorDevice MotorDevice(int PortIndex)
        {
            if (null == this._MotorDevice)
            {
                this._MotorDevice = new Ev3MotorDevice[4];
            }
            try
            {
                if (null == this._MotorDevice[PortIndex])
                {
                    this._MotorDevice[PortIndex] = new Ev3MotorDevice();
                }
                return this._MotorDevice[PortIndex];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Returns the SensorDevice object specified by PortIdnex, index of array.
        /// </summary>
        /// <param name="PortIndex">Abstracted port number.</param>
        /// <returns></returns>
        public Ev3SensorDevice SensorDevice(int PortIndex)
        {
            if (null == this._SensorDevice)
            {
                this._SensorDevice = new Ev3SensorDevice[4];
            }
            try
            {
                if (null == this._SensorDevice[PortIndex])
                {
                    this._SensorDevice[PortIndex] = new Ev3SensorDevice();
                }
                return this._SensorDevice[PortIndex];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Returns Ev3Brick instance, singleton object.
        /// </summary>
        /// <returns></returns>
        public static Ev3Brick GetInstance()
        {
            if (null == Ev3Brick._Instance)
            {
                _Instance = new Ev3Brick();
            }
            return _Instance;
        }
        #endregion
    }
}
