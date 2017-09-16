using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    using Model;

    public class Ev3PortViewModel : DeviceViewModelBase
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        public Ev3PortViewModel()
        {

        }
        #endregion

        #region Events
        /// <summary>
        /// Event to notify that the state of connection with device is changed.
        /// </summary>
        /// <param name="sender">Source object of event.</param>
        /// <param name="e">Event argument contains state of connection when event raised.</param>
        public delegate void ConnectStateChangedEventHandler(object sender, ConnectStateChangedEventArgs e);
        public event ConnectStateChangedEventHandler ConnectStateChanged;
        public virtual void OnConnectStateChanged(ConnectStateChangedEventArgs e)
        {
            this.ConnectStateChanged?.Invoke(this, e);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// State of connection.
        /// </summary>
        protected ConnectState _ConnectState;
        public ConnectState ConnectState
        {
            get { return this._ConnectState; }
            set
            {
                this._ConnectState = value;
            }
        }

        /// <summary>
        /// Name to show in label area presents current action.
        /// </summary>
        protected string _ActionName;
        public string ActionName
        {
            get { return this.ActionName; }
            set
            {
                this._ActionName = value;
                this.RaisePropertyChanged("ActionName");
            }
        }

        /// <summary>
        /// Represents whether the port used to connect with device can be changed or not.
        /// </summary>
        protected bool _CanChangePort;
        public bool CanChangePort
        {
            get { return this._CanChangePort; }
            set
            {
                this._CanChangePort = value;
                this.RaisePropertyChanged("CanChangePort");
            }
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Callback method called when ConnectStateChanged event raised.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Value to represent event data.</param>
        public virtual void ConnectedStateChangedCallback(object sender, ConnectStateChangedEventArgs e)
        {
            //Write code here to handle ConnectStateChanged event.
        }
        #endregion
    }
}
