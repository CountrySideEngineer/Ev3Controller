using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    public class PortConnectDeviceViewModelBase : DeviceViewModelBase
    {
        #region Constructors and the Finalizer
        public PortConnectDeviceViewModelBase() { }
        #endregion

        #region Public Properties
        /// <summary>
        /// Name of port the device connected to.
        /// </summary>
        protected string _PortName;
        public string PortName
        {
            get { return this._PortName; }
            set
            {
                this._PortName = value;
                this.RaisePropertyChanged("PortName");
            }
        }

        /// <summary>
        /// Name of device connected to a port.
        /// </summary>
        protected string _DeviceName;
        public string DeviceName
        {
            get { return this._DeviceName; }
            set
            {
                this._DeviceName = value;
                this.RaisePropertyChanged("DeviceName");
            }
        }
        #endregion
    }
}
