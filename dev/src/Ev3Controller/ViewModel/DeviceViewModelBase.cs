using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    using Model;

    /// <summary>
    /// Common base class for EV3 device view.
    /// </summary>
    public class DeviceViewModelBase : ViewModelBase
    {
        #region Constructors and the Finalizer
        public DeviceViewModelBase()
        {
            this.IsConnected = false;
        }
        #endregion

        #region Events

        /// <summary>
        /// Event to notify that the state of connection, connected or not, changed.
        /// </summary>
        /// <param name="sender">Source object of event.</param>
        /// <param name="e">Event argument contains state of connection in boolean, true is connected, false is disconnected.</param>
        public delegate void IsConnectedChangedEventHandler(object sender, IsConnectedChangedEventArgs e);
        public event IsConnectedChangedEventHandler IsConnectedChanged;
        public virtual void OnIsConenctedChanged(IsConnectedChangedEventArgs e)
        {
            this.IsConnectedChanged?.Invoke(this, e);
        }
        #endregion

        #region Public properties
        protected bool _IsConnected;
        public bool IsConnected
        {
            get { return this._IsConnected; }
            set
            {
                this._IsConnected = value;
                this.RaisePropertyChanged("IsConnected");
            }
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Callback method called when IsConnectedChanged event raised.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Value to represent event data.</param>
        public virtual void IsConnectedCallback(object sender, IsConnectedChangedEventArgs e)
        {
            this.IsConnected = e.NewValue;
        }

        /// <summary>
        /// Reset device data by setting "IsConnected" property.
        /// </summary>
        public virtual void ResetDevice()
        {
            this.IsConnected = false;
        }
        #endregion
    }
}
