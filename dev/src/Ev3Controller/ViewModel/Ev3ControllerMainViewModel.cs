using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    using Ev3Controller.Model;
    using System.Timers;

    public class Ev3ControllerMainViewModel : ViewModelBase
    {
        #region Constructors and the Finalizer
        public Ev3ControllerMainViewModel()
        {
            this.PortViewModel.ConnectStateChanged += this.ConnectStateChangedCallback;
            this.UpdateTimer = null;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// View model object about COM port, Ev3PortViewModel.
        /// </summary>
        protected Ev3PortViewModel _PortViewModel;
        public Ev3PortViewModel PortViewModel
        {
            get
            {
                if (null == this._PortViewModel)
                {
                    this._PortViewModel = new Ev3PortViewModel();
                }
                return this._PortViewModel;
            }
            set
            {
                this._PortViewModel = value;
                this.RaisePropertyChanged("PortViewModel");
            }
        }

        /// <summary>
        /// View model object about safe state.
        /// </summary>
        protected Ev3SafeStateViewModel _SafeStateViewModel;
        public Ev3SafeStateViewModel SafeStateViewModel
        {
            get
            {
                if (null == this._SafeStateViewModel)
                {
                    this._SafeStateViewModel = new Ev3SafeStateViewModel();
                }
                return this._SafeStateViewModel;
            }
            set
            {
                this._SafeStateViewModel = value;
                this.RaisePropertyChanged("SafeStateViewModel");
            }
        }

        /// <summary>
        /// View model object about motor device connected port A of Brick.
        /// </summary>
        public Ev3MotorDeviceViewModel MotorViewModelA
        {
            get
            {
                if (null == this.MotorViewModelArray[0])
                {
                    this.MotorViewModelArray[0] = new Ev3MotorDeviceViewModel();
                }
                return this.MotorViewModelArray[0];
            }
            set
            {
                this._MotorViewModelArray[0] = value;
                this.RaisePropertyChanged("MotorViewModelA");
            }
        }

        /// <summary>
        /// View model object about motor device connected port B of Brick.
        /// </summary>
        public Ev3MotorDeviceViewModel MotorViewModelB
        {
            get
            {
                if (null == this.MotorViewModelArray[1])
                {
                    this.MotorViewModelArray[1] = new Ev3MotorDeviceViewModel();
                }
                return this.MotorViewModelArray[1];
            }
            set
            {
                this._MotorViewModelArray[1] = value;
                this.RaisePropertyChanged("MotorViewModelB");
            }
        }

        /// <summary>
        /// View model object about motor device connected port C of Brick.
        /// </summary>
        public Ev3MotorDeviceViewModel MotorViewModelC
        {
            get
            {
                if (null == this.MotorViewModelArray[2])
                {
                    this.MotorViewModelArray[2] = new Ev3MotorDeviceViewModel();
                }
                return this.MotorViewModelArray[2];
            }
            set
            {
                this._MotorViewModelArray[2] = value;
                this.RaisePropertyChanged("MotorViewModelC");
            }
        }

        /// <summary>
        /// View model object about motor device connected port D of Brick.
        /// </summary>
        public Ev3MotorDeviceViewModel MotorViewModelD
        {
            get
            {
                if (null == this.MotorViewModelArray[3])
                {
                    this.MotorViewModelArray[3] = new Ev3MotorDeviceViewModel();
                }
                return this.MotorViewModelArray[3];
            }
            set
            {
                this._MotorViewModelArray[3] = value;
                this.RaisePropertyChanged("MotorViewModelD");
            }
        }

        /// <summary>
        /// Array list of Ev3MotorDeviceViewModel.
        /// </summary>
        protected Ev3MotorDeviceViewModel[] _MotorViewModelArray;
        public Ev3MotorDeviceViewModel[] MotorViewModelArray
        {
            get
            {
                if (null == this._MotorViewModelArray)
                {
                    this._MotorViewModelArray = new Ev3MotorDeviceViewModel[4];
                }
                for (int index = 0; index < 4; index++)
                {
                    if (null == this._MotorViewModelArray[index])
                    {
                        this._MotorViewModelArray[index] = new Ev3MotorDeviceViewModel();
                    }
                }
                return this._MotorViewModelArray;
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 1 of Brick.
        /// </summary>
        public Ev3SensorDeviceViewModel SensorViewModel1
        {
            get
            {
                if (null == this.SensorViewModelArray[0])
                {
                    this.SensorViewModelArray[0] = new Ev3SensorDeviceViewModel();
                }
                return this.SensorViewModelArray[0];
            }
            set
            {
                this._SensorViewModelArray[0] = value;
                this.RaisePropertyChanged("SensorViewModel1");
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 2 of Brick.
        /// </summary>
        public Ev3SensorDeviceViewModel SensorViewModel2
        {
            get
            {
                if (null == this.SensorViewModelArray[1])
                {
                    this.SensorViewModelArray[1] = new Ev3SensorDeviceViewModel();
                }
                return this.SensorViewModelArray[1];
            }
            set
            {
                this.SensorViewModelArray[1] = value;
                this.RaisePropertyChanged("SensorViewModel2");
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 3 of Brick.
        /// </summary>
        public Ev3SensorDeviceViewModel SensorViewModel3
        {
            get
            {
                if (null == this.SensorViewModelArray[2])
                {
                    this.SensorViewModelArray[2] = new Ev3SensorDeviceViewModel();
                }
                return this.SensorViewModelArray[2];
            }
            set
            {
                this.SensorViewModelArray[2] = value;
                this.RaisePropertyChanged("SensorViewModel3");
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 4 of Brick.
        /// </summary>
        public Ev3SensorDeviceViewModel SensorViewModel4
        {
            get
            {
                if (null == this.SensorViewModelArray[3])
                {
                    this.SensorViewModelArray[3] = new Ev3SensorDeviceViewModel();
                }
                return this.SensorViewModelArray[3];
            }
            set
            {
                this._SensorViewModelArray[3] = value;
                this.RaisePropertyChanged("SensorViewModel4");
            }
        }

        protected Ev3SensorDeviceViewModel[] _SensorViewModelArray;
        public Ev3SensorDeviceViewModel[] SensorViewModelArray
        {
            get
            {
                if (null == this._SensorViewModelArray)
                {
                    this._SensorViewModelArray = new Ev3SensorDeviceViewModel[4];
                }
                for (int index = 0; index < 4; index++)
                {
                    if (null == this._SensorViewModelArray[index])
                    {
                        this._SensorViewModelArray[index] = new Ev3SensorDeviceViewModel();
                    }
                }
                return this._SensorViewModelArray;
            }
        }

        protected Timer _UpdateTimer;
        public Timer UpdateTimer
        {
            get
            {
                if (null == this._UpdateTimer)
                {
                    this._UpdateTimer = new Timer(10);
                }
                return this._UpdateTimer;
            }
            set { this._UpdateTimer = value; }
        }
        #endregion

        #region Other methods and private properties in calling order
        public void ConnectStateChangedCallback(object sender, EventArgs e)
        {
            Console.WriteLine("Connection State chagned.");

            if (e is ConnectStateChangedEventArgs)
            {
                var Arg = e as ConnectStateChangedEventArgs;
                if (Arg.NewValue.State.Equals(ConnectionState.Connected))
                {
                    this.UpdateTimer.Elapsed += (send_source, arg_data) =>
                    {
                        try
                        {
                            this.UpdateTimer.Stop();
                            var Updater = new BrickDataUpdater();
                            Updater.UpdateViewModel(this);
                        }
                        finally
                        {
                            this.UpdateTimer.Start();
                        }
                    };
                    this.UpdateTimer.Start();
                }
                else if (Arg.NewValue.State.Equals(ConnectionState.Disconnected))
                {
                    try
                    {
                        this.UpdateTimer.Stop();
                        this.UpdateTimer.Elapsed -= this.UpdateTimerEvent;
                        this.UpdateTimer.Elapsed += this.ResetTimerEvent;
                        this.UpdateTimer.Interval = 1;
                        this.UpdateTimer.Start();
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Timer has not been started.");
                    }
                }
            }
        }

        /// <summary>
        /// Timer dispatcher to update by Ev3Brick data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateTimerEvent(object sender, EventArgs e)
        {
            try
            {
                this.UpdateTimer.Stop();
                var Updater = new BrickDataUpdater();
                Updater.UpdateViewModel(this);
            }
            finally
            {
                this.UpdateTimer.Start();
            }
        }

        /// <summary>
        /// Timer dispatcher to reset device data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ResetTimerEvent(object sender, EventArgs e)
        {
            try
            {
                var Updater = new BrickDataUpdater();
                Updater.ResetViewModel(this);
            }
            finally
            {
                this.UpdateTimer.Stop();
                this.UpdateTimer.Elapsed -= ResetTimerEvent;//Remove ResetTimerEvent from Timer object itself.
            }
        }
        #endregion
    }
}
