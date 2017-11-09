using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    public class Ev3ControllerMainViewModel : ViewModelBase
    {
        #region Constructors and the Finalizer
        public Ev3ControllerMainViewModel()
        {

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
        /// View model object about motor device connected port A of Brick.
        /// </summary>
        protected Ev3MotorDeviceViewModel _MotorViewModelA;
        public Ev3MotorDeviceViewModel MotorViewModelA
        {
            get
            {
                if (null == this._MotorViewModelA)
                {
                    this._MotorViewModelA = new Ev3MotorDeviceViewModel();
                }
                return this._MotorViewModelA;
            }
            set
            {
                this._MotorViewModelA = value;
                this.RaisePropertyChanged("MotorViewModelA");
            }
        }

        /// <summary>
        /// View model object about motor device connected port B of Brick.
        /// </summary>
        protected Ev3MotorDeviceViewModel _MotorViewModelB;
        public Ev3MotorDeviceViewModel MotorViewModelB
        {
            get
            {
                if (null == this._MotorViewModelB)
                {
                    this._MotorViewModelB = new Ev3MotorDeviceViewModel();
                }
                return this._MotorViewModelB;
            }
            set
            {
                this._MotorViewModelB = value;
                this.RaisePropertyChanged("MotorViewModelB");
            }
        }

        /// <summary>
        /// View model object about motor device connected port C of Brick.
        /// </summary>
        protected Ev3MotorDeviceViewModel _MotorViewModelC;
        public Ev3MotorDeviceViewModel MotorViewModelC
        {
            get
            {
                if (null == this._MotorViewModelC)
                {
                    this._MotorViewModelC = new Ev3MotorDeviceViewModel();
                }
                return this._MotorViewModelC;
            }
            set
            {
                this._MotorViewModelC = value;
                this.RaisePropertyChanged("MotorViewModelC");
            }
        }

        /// <summary>
        /// View model object about motor device connected port D of Brick.
        /// </summary>
        protected Ev3MotorDeviceViewModel _MotorViewModelD;
        public Ev3MotorDeviceViewModel MotorViewModelD
        {
            get
            {
                if (null == this._MotorViewModelD)
                {
                    this._MotorViewModelD = new Ev3MotorDeviceViewModel();
                }
                return this._MotorViewModelD;
            }
            set
            {
                this._MotorViewModelD = value;
                this.RaisePropertyChanged("MotorViewModelD");
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 1 of Brick.
        /// </summary>
        protected Ev3SensorDeviceViewModel _SensorViewModel1;
        public Ev3SensorDeviceViewModel SensorViewModel1
        {
            get
            {
                if (null == this._SensorViewModel1)
                {
                    this._SensorViewModel1 = new Ev3SensorDeviceViewModel();
                }
                return this._SensorViewModel1;
            }
            set
            {
                this._SensorViewModel1 = value;
                this.RaisePropertyChanged("SensorViewModel1");
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 2 of Brick.
        /// </summary>
        protected Ev3SensorDeviceViewModel _SensorViewModel2;
        public Ev3SensorDeviceViewModel SensorViewModel2
        {
            get
            {
                if (null == this._SensorViewModel2)
                {
                    this._SensorViewModel2 = new Ev3SensorDeviceViewModel();
                }
                return this._SensorViewModel2;
            }
            set
            {
                this._SensorViewModel2 = value;
                this.RaisePropertyChanged("SensorViewModel2");
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 3 of Brick.
        /// </summary>
        protected Ev3SensorDeviceViewModel _SensorViewModel3;
        public Ev3SensorDeviceViewModel SensorViewModel3
        {
            get
            {
                if (null == this._SensorViewModel3)
                {
                    this._SensorViewModel3 = new Ev3SensorDeviceViewModel();
                }
                return this._SensorViewModel3;
            }
            set
            {
                this._SensorViewModel3 = value;
                this.RaisePropertyChanged("SensorViewModel3");
            }
        }

        /// <summary>
        /// View model obejct about sensor device connected port 4 of Brick.
        /// </summary>
        protected Ev3SensorDeviceViewModel _SensorViewModel4;
        public Ev3SensorDeviceViewModel SensorViewModel4
        {
            get
            {
                if (null == this._SensorViewModel4)
                {
                    this._SensorViewModel4 = new Ev3SensorDeviceViewModel();
                }
                return this._SensorViewModel4;
            }
            set
            {
                this._SensorViewModel4 = value;
                this.RaisePropertyChanged("SensorViewModel4");
            }
        }
        #endregion
    }
}
