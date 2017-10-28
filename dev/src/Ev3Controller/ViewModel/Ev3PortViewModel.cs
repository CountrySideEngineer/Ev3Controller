using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    using Command;
    using Ev3Command;
    using Model;
    using System.Windows.Media.Imaging;
    using Ev3Controller.Util;
    using System.Windows;

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
            {ConnectionState.Connected, new LabelAndEnable(false, @"切断", @"接続済み") },
            {ConnectionState.Sending, new LabelAndEnable(true, @"切断", @"送信中") },
            {ConnectionState.Receiving, new LabelAndEnable(true, @"切断", @"受信中") },
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
            this.UpdateState();

            this.AvailableComPorts = ComPortViewModel.Create();
            this.SelectedComPort = this.AvailableComPorts.First();
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

                this.ImageResource = this._ConnectState.StateImage;
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
        public IEnumerable<ComPortViewModel> AvailableComPorts { get; protected set; }

        /// <summary>
        /// Current selected ComPortViewModel
        /// </summary>
        protected ComPortViewModel _SelectedComPort;
        public ComPortViewModel SelectedComPort
        {
            get { return this._SelectedComPort; }
            set
            {
                this._SelectedComPort = value;
                this.RaisePropertyChanged("SelectedComPort");
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

        /// <summary>
        /// Command to access COM port.
        /// </summary>
        protected DelegateCommand _ComPortAccessCommand;
        public DelegateCommand ComPortAccessCommand
        {
            get
            {
                if (null == this._ComPortAccessCommand)
                {
                    this._ComPortAccessCommand = new DelegateCommand(
                        this.PortConnectAndDisConnectExecute,
                        this.CanPortConnectAndDisConnectExecute);
                }
                return this._ComPortAccessCommand;
            }
        }

        /// <summary>
        /// Flag shows whether the command to access COM port can execute or not.
        /// </summary>
        public bool CanComPortAccessCommand { get; protected set; }

        /// <summary>
        /// Image source for connect state.
        /// </summary>
        protected BitmapImage _ImageResource;
        public BitmapImage ImageResource
        {
            get
            {
                return this._ImageResource;
            }
            protected set
            {
                this._ImageResource = value;
                this.RaisePropertyChanged("ImageResource");
            }
        }

        public object Ev3Util { get; private set; }
        #endregion

        #region Other methods and private properties in calling order.
        /// <summary>
        /// Body of command to connect and disconnect port.
        /// </summary>
        public void PortConnectAndDisConnectExecute()
        {
            if (this.IsConnected)
            {
                this.PortDisconnectExecute();
            }
            else
            {
                this.PortConnectExecute();
            }
        }

        /// <summary>
        /// Body of command to connect port.
        /// </summary>
        public void PortConnectExecute()
        {
            if (this.IsConnected) { return; }//Nothing to do if the port has been connected.

            this.ReleaseEventHandler();
            this.AccessRunner = new ComPortAccessSequenceRunner(this.SelectedComPort.ComPort);
            this.SetupEventHandler();
            this.AccessRunner.ChangeAndStartSequence(
                ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);
        }

        /// <summary>
        /// Body of command to disconnect port.
        /// </summary>
        public void PortDisconnectExecute()
        {
            if (!this.IsConnected) { return; }//Nothing to do if the port has not been connected.
            this.AccessRunner.ChangeAndStartSequence(
                ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);
        }

        public bool CanPortConnectAndDisConnectExecute() { return this.CanComPortAccessCommand; }

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
                var OldVar = this.ConnectState;
                var NewVar = Args.NewValue;
                this.ConnectState = NewVar;
                this.UpdateState();
            }
            //Other properties are update in ConnectState setter.
        }

        /// <summary>
        /// Setup event handler to sequence passed by arguemnt.
        /// </summary>
        /// <param name="Sequence"></param>
        public void SetupEventHandler()
        {
            if (null != this.AccessRunner)
            {
                this.AccessRunner.SequenceStartingEvent += this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceStartedEvent += this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceFinishedEvent += this.ConnectedStateChangedCallback;
                this.AccessRunner.DataSendReceiveEvent += this.DataSendAndReceivedFinishedCallback;
                this.AccessRunner.ExceptionReceivedEvent += this.ExceptionRaisedCallback;
            }
        }

        /// <summary>
        /// Release event handler from sequence passed by arguemnt.
        /// </summary>
        /// <param name="Sequence"></param>
        public void ReleaseEventHandler()
        {
            if (null != this.AccessRunner)
            {
                this.AccessRunner.SequenceStartingEvent -= this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceStartedEvent -= this.ConnectedStateChangedCallback;
                this.AccessRunner.SequenceFinishedEvent -= this.ConnectedStateChangedCallback;
                this.AccessRunner.DataSendReceiveEvent -= this.DataSendAndReceivedFinishedCallback;
                this.AccessRunner.ExceptionReceivedEvent -= this.ExceptionRaisedCallback;
            }
        }

        /// <summary>
        /// Handle data sending and response receiving event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void DataSendAndReceivedFinishedCallback(object sender, EventArgs e)
        {
            if (e is NotifySendReceiveDataEventArgs)
            {
                try
                {
                    var Args = e as NotifySendReceiveDataEventArgs;
                    Console.WriteLine(@"Snd:" + Ev3Utility.Buff2String(Args.SendData));
                    Console.WriteLine(@"Rcv:" + Ev3Utility.Buff2String(Args.RecvData));

                    var Command = Args.Command;
                    var Updater = BrickUpdater.Factory(Command);
                    Updater.Update(Command, Ev3Brick.GetInstance());
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Handle exception raised in command sequence. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void ExceptionRaisedCallback(object sender, EventArgs e)
        {
            if (e is NotifyCommandException)
            {
                var Except = e as NotifyCommandException;
                var CmdExcept = Except.Except as CommandException;
                Console.WriteLine(
                    string.Format(
                        @"{0} Name:{1} Code:0x{2:x2}-0x{3:x2}",
                            CmdExcept.Message, CmdExcept.Name, CmdExcept.Cmd, CmdExcept.SubCmd));
            }
            else if (e is NotifyConnectExceptionEventArgs)
            {
                var Args = e as NotifyConnectExceptionEventArgs;
                var Except = Args.Except as Exception;

                MessageBox.Show(
                    Except.Message,
                    "接続更新エラー");
            }
        }

        /// <summary>
        /// Update parameters.
        /// </summary>
        public void UpdateState()
        {
            LabelAndEnable MapValue =
                Ev3PortViewModel.StateLabelMap[this.ConnectState.State];
            this.CanChangePort = MapValue.CanChange;
            this.ActionName = MapValue.ActionLabel;
            this.StateLabel = MapValue.ConnLabel;

            this.ImageResource = this.ConnectState.StateImage;

            //Change connection state, connected or not.
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

            //Change the flag shows the COM port access command can excecte or not.
            switch (this.ConnectState.State)
            {
                case ConnectionState.Connected:
                case ConnectionState.Disconnected:
                case ConnectionState.Sending:
                case ConnectionState.Receiving:
                    this.CanComPortAccessCommand = true;
                    break;

                case ConnectionState.Disconnecting:
                case ConnectionState.Connecting:
                case ConnectionState.Unknown:
                default:
                    this.CanComPortAccessCommand = false;
                    break;
            }
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
