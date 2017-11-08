using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    public class Ev3SensorDeviceViewModel : PortConnectDeviceViewModelBase
    {
        #region Constructors and the Finalizer
        public Ev3SensorDeviceViewModel() { }
        #endregion

        #region Public Properties
        /// <summary>Sensor value 1.</summary>
        protected int _SensorValue1;
        public int SensorValue1
        {
            get { return this._SensorValue1; }
            set
            {
                this._SensorValue1 = value;
                this.RaisePropertyChanged("SensorValue1");
            }
        }

        /// <summary>Unit of sensor value 1.</summary>
        protected string _SensorValue1Unit;
        public string SensorValue1Unit
        {
            get { return this._SensorValue1Unit; }
            set
            {
                this._SensorValue1Unit = value;
                this.RaisePropertyChanged("SensorValue1Unit");
            }
        }

        /// <summary>Sensor value 2.</summary>
        protected int _SensorValue2;
        public int SensorValue2
        {
            get { return this._SensorValue2; }
            set
            {
                this._SensorValue2 = value;
                this.RaisePropertyChanged("SensorValue2");
            }
        }

        /// <summary>Unit of sensor value 2.</summary>
        protected string _SensorValue2Unit;
        public string SensorValue2Unit
        {
            get { return this._SensorValue2Unit; }
            set
            {
                this._SensorValue2Unit = value;
                this.RaisePropertyChanged("SensorValue2Unit");
            }
        }

        /// <summary>Sensor value 3.</summary>
        protected int _SensorValue3;
        public int SensorValue3
        {
            get { return this._SensorValue3; }
            set
            {
                this._SensorValue3 = value;
                this.RaisePropertyChanged("SensorValue3");
            }
        }

        /// <summary>Unit of sensor value 3.</summary>
        protected string _SensorValue3Unit;
        public string SensorValue3Unit
        {
            get { return this._SensorValue3Unit; }
            set
            {
                this._SensorValue3Unit = value;
                this.RaisePropertyChanged("SensorValue3Unit");
            }
        }
        #endregion
    }
}
