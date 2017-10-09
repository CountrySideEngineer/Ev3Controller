﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    using Model;

    public class Ev3PortViewModel : DeviceViewModelBase
    {
        #region Private fields and constants (in a region)
        /// <summary>
        /// Dictionary contains label and status whether the connection state can change or not.
        /// </summary>
        protected static Dictionary<ConnectionState, LabelAndEnable> StateLabelMap =
            new Dictionary<ConnectionState, LabelAndEnable>
        {
            {ConnectionState.Disconnected, new LabelAndEnable(true, @"接続", @"未接続") },
            {ConnectionState.Disconnecting, new LabelAndEnable(false, @"切断", @"切断中") },
            {ConnectionState.Connecting, new LabelAndEnable(false, @"接続", @"接続中") },
            {ConnectionState.Connected, new LabelAndEnable(true, @"切断", @"接続済み") },
            {ConnectionState.Sending, new LabelAndEnable(false, @"切断", @"送信中") },
            {ConnectionState.Receiving, new LabelAndEnable(false, @"切断", @"受信中") },
            {ConnectionState.Unknown, new LabelAndEnable(true, @"不明", @"不明") },
        };
        #endregion

        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        public Ev3PortViewModel()
        {
            this.ConnectState = new ConnectState(ConnectionState.Disconnected);
            this.AvailableComPortVM = ComPortViewModel.Create();
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

                LabelAndEnable MapValue =
                    Ev3PortViewModel.StateLabelMap[this._ConnectState.State];
                this.CanChangePort = MapValue.CanChange;
                this.ActionName = MapValue.ActionLabel;
                this.StateLabel = MapValue.ConnLabel;
            }
        }

        /// <summary>
        /// Name to show in label area presents current action.
        /// </summary>
        protected string _ActionName;
        public string ActionName
        {
            get { return this._ActionName; }
            set
            {
                this._ActionName = value;
                this.RaisePropertyChanged("ActionName");
            }
        }

        protected string _StateLabel;
        public string StateLabel
        {
            get { return this._StateLabel; }
            set
            {
                this._StateLabel = value;
                this.RaisePropertyChanged("StateLabel");
            }
        }

        /// <summary>
        /// List of available COM port.
        /// </summary>
        public IEnumerable<ComPortViewModel> AvailableComPortVM { get; protected set; }

        /// <summary>
        /// Current selected ComPortViewModel
        /// </summary>
        protected ComPortViewModel _SelectedComPortVM;
        public ComPortViewModel SelectedComPortVM
        {
            get { return this._SelectedComPortVM; }
            set
            {
                this._SelectedComPortVM = value;
                this.RaisePropertyChanged("SelectedComPortVM");
            }
        }

        /// <summary>
        /// ComPortAccessSequenceRunner object to access COM port.
        /// </summary>
        public ComPortAccessSequenceRunner AccessRunner { get; protected set; }

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

        #region Other methods and private properties in calling order.
        public void PortConnectExecute()
        {
            if (this.IsConnected) { return; }//Nothing to do if the port has been connected.

            this.ReleaseEventHandler();
            this.AccessRunner = new ComPortAccessSequenceRunner(this.SelectedComPortVM.ComPort);
            this.SetupEventHandler();
            this.AccessRunner.ChangeAndStartSequence(
                ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);
        }
        public void PortDisconnectExecute()
        {
            if (!this.IsConnected) { return; }//Nothing to do if the port has not been connected.
            this.AccessRunner.ChangeAndStartSequence(
                ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);
        }

        /// <summary>
        /// Callback method called when ConnectStateChanged event raised.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Value to represent event data.</param>
        public virtual void ConnectedStateChangedCallback(object sender, EventArgs e)
        {
            if (e is ConnectStateChangedEventArgs)
            {
                var Args = e as ConnectStateChangedEventArgs;
                this.ConnectState = Args.NewValue;
                switch (this.ConnectState.State)
                {
                    case ConnectionState.Connected:
                    case ConnectionState.Disconnecting:
                    case ConnectionState.Sending:
                    case ConnectionState.Receiving:
                        this.IsConnected = true;
                        break;

                    case ConnectionState.Connecting:
                    case ConnectionState.Disconnected:
                    case ConnectionState.Unknown:
                    default:
                        this.IsConnected = false;
                        break;

                }
            }
            //Other properties are update in ConnectState setter.
        }

        public void SetupEventHandler()
        {
            if (null != this.AccessRunner)
            {
                this.AccessRunner.SequenceStartingEvent += this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceStartedEvent += this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceFinishedEvent += this.ConnectedStateChangedCallback;
            }
        }
        public void ReleaseEventHandler()
        {
            if (null != this.AccessRunner)
            {
                this.AccessRunner.SequenceStartingEvent -= this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceStartedEvent -= this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceFinishedEvent -= this.ConnectedStateChangedCallback;
            }
        }

        /// <summary>
        /// Handle data sending and response receiving event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void DataSendAndReceivedFinishedCallback(object sender, EventArgs e)
        {
            Console.WriteLine("DataSendAndReceivedFinishedCallback called");
        }

        #region Inner class
        /// <summary>
        /// Inner class contains label and status whether the connection state can change or not.
        /// </summary>
        protected class LabelAndEnable
        {
            #region Constructors and the Finalizer
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="CanChange">The port can change or not.</param>
            /// <param name="ActionLabel">Action name which will be executed.</param>
            /// <param name="ConnLabel">State of connection name.</param>
            public LabelAndEnable(bool CanChange, string ActionLabel, string ConnLabel)
            {
                this.CanChange = CanChange;
                this.ActionLabel = ActionLabel;
                this.ConnLabel = ConnLabel;
            }
            #endregion

            #region Public Properties
            /// <summary>
            /// Represents whether the port can change or not.
            /// </summary>
            public bool CanChange { get; protected set; }
            
            /// <summary>
            /// Represents which action will be executed.
            /// </summary>
            public string ActionLabel { get; protected set; }

            /// <summary>
            /// Represents the state of connection.
            /// </summary>
            public string ConnLabel { get; protected set; }
            #endregion
        }
        #endregion
        #endregion
    }
}
