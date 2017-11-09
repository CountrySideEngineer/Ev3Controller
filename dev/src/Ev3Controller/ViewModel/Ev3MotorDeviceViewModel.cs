using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    public class Ev3MotorDeviceViewModel : PortConnectDeviceViewModelBase
    {
        #region Constructors and the Finalizer
        public Ev3MotorDeviceViewModel() { }
        #endregion

        #region Public Properties
        /// <summary>Target motor output power.</summary>
        protected int _TargetOutput;
        public int TargetOutput
        {
            get { return this._TargetOutput; }
            set
            {
                this._TargetOutput = value;
                this.RaisePropertyChanged("TargetOutput");
            }
        }

        /// <summary>Unit of target motor output power.</summary>
        protected string _TargetOutputUnit;
        public string TargetOutputUnit
        {
            get { return this._TargetOutputUnit; }
            set
            {
                this._TargetOutputUnit = value;
                this.RaisePropertyChanged("TargetOutputUnit");
            }
        }

        /// <summary>Current motor output power.</summary>
        protected int _CurrentOutput;
        public int CurrentOutput
        {
            get { return this._CurrentOutput; }
            set
            {
                this._CurrentOutput = value;
                this.RaisePropertyChanged("CurrentOutput");
            }
        }

        /// <summary>Unit of current motor output power.</summary>
        protected string _CurrentOutputUnit;
        public string CurrentOutputUnit
        {
            get { return this._CurrentOutputUnit; }
            set
            {
                this._CurrentOutputUnit = value;
                this.RaisePropertyChanged("CurrentOutputUnit");
            }
        }
        #endregion
    }
}
