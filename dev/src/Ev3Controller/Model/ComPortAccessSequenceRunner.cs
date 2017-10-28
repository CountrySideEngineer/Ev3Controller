using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class ComPortAccessSequenceRunner
    {
        public enum SequenceName
        {
            SEQUENCE_NAME_CONNECT,
            SEQUENCE_NAME_DISCONNECT,
            SEQUENCE_NAME_SEND_AND_RECV,
            SEQUENCE_NAME_UNKNOWN,
            SEQUENCE_NAME_MAX,
        };

        //ここに、シーケンスの順番をまとめたリストを作成する。
        public static Dictionary<SequenceName, SequenceManager> SequenceDictionary =
            new Dictionary<SequenceName, SequenceManager>()
        {
                { SequenceName.SEQUENCE_NAME_CONNECT,
                    new SequenceManager(SequenceName.SEQUENCE_NAME_SEND_AND_RECV) },
                { SequenceName.SEQUENCE_NAME_DISCONNECT,
                    new SequenceManager() },
                { SequenceName.SEQUENCE_NAME_SEND_AND_RECV,
                    new SequenceManager() }
        };

        #region Events
        /// <summary>
        /// Delegate to notify the sequence prepared starting.
        /// </summary>
        public delegate void SequenceStartingEventHandler(object sender, EventArgs e);
        public event SequenceStartingEventHandler SequenceStartingEvent;

        /// <summary>
        /// Delegate to notify the sequence has been started.
        /// </summary>
        public delegate void SequenceStartedEventHandler(object sender, EventArgs e);
        public event SequenceStartedEventHandler SequenceStartedEvent;

        /// <summary>
        /// Delegate to notify the sequence finished.
        /// </summary>
        public delegate void SequenceFinishedEventHandler(object sender, EventArgs e);
        public event SequenceFinishedEventHandler SequenceFinishedEvent;

        /// <summary>
        /// Delegate to notify a sent data and received data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DataSendReceiveEventHandler(object sender, EventArgs e);
        public event DataSendReceiveEventHandler DataSendReceiveEvent;

        /// <summary>
        /// Delegate to notify an exception occurred.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ExceptionReceivedEventHandler(object sender, EventArgs e);
        public event ExceptionReceivedEventHandler ExceptionReceivedEvent;
        #endregion

        #region Public Properties
        /// <summary>
        /// Port information used to access COM port.
        /// </summary>
        public ComPort ComPort { get; protected set; }

        /// <summary>
        /// ComPort interface to access COM port.
        /// </summary>
        public ComPortAccess ComPortAcc { get; protected set; }

        /// <summary>
        /// Task accessing COM port.
        /// </summary>
        public Task CurTask;

        /// <summary>
        /// Sequence now running.
        /// </summary>
        public ComPortAccessSequence CurSequence { get; protected set; }

        /// <summary>
        /// Sequence name data of running currently.
        /// </summary>
        public SequenceName SeqName { get; protected set; }
        #endregion

        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        public ComPortAccessSequenceRunner()
        {
            this.ComPort = null;
            this.ComPortAcc = null;
            this.CurTask = null;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ComPort">ComPort contains port name and its configuration.</param>
        public ComPortAccessSequenceRunner(ComPort ComPort)
        {
            this.SetComPort(ComPort);
        }
        #endregion

        #region Factory Methods
        /// <summary>
        /// A factory method to create concrete ComPortAccessSequence object.
        /// </summary>
        /// <param name="SeqName">
        /// Identifier used int creating ComPortAccessSequence concrete object.
        /// </param>
        /// <returns>Concrete ComPortAccessSequence object.</returns>
        public static ComPortAccessSequence SequenceFactory(SequenceName SeqName)
        {
            ComPortAccessSequence AccessSequence = null;
            switch (SeqName)
            {
                case SequenceName.SEQUENCE_NAME_CONNECT:
                    AccessSequence = new ComPortConnectSequence();
                    break;

                case SequenceName.SEQUENCE_NAME_DISCONNECT:
                    AccessSequence = new ComPortDisconnectSequence();
                    break;

                case SequenceName.SEQUENCE_NAME_SEND_AND_RECV:
                    AccessSequence = new EchoBackComPortSendRecvSequence();
                    break;

                default:
                    AccessSequence = null;
                    break;
            }
            return AccessSequence;
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Setup ComPort object, contains COM port information used to accesss, 
        /// and ComPortAccesss object.
        /// </summary>
        /// <param name="ComPort"></param>
        public void SetComPort(ComPort ComPort)
        {
            this.ComPort = ComPort;
            this.ComPortAcc = new ComPortAccess(this.ComPort);

            this.CurTask = null;
        }
        
        /// <summary>
        /// Stop current running sequence and start new one.
        /// </summary>
        /// <param name="SeqName">Identifier of new sequence.</param>
        public void ChangeAndStartSequence(SequenceName SeqName)
        {
            this.CurTask = this.StartSequence(
                ComPortAccessSequenceRunner.SequenceFactory(SeqName));
            if (null == this.CurTask)
            {
                this.SeqName = SequenceName.SEQUENCE_NAME_UNKNOWN;
            }
            else
            {
                this.SeqName = SeqName;
            }
        }

        /// <summary>
        /// Start new sequence in other async thread.
        /// </summary>
        /// <param name="NextSequence">New Sequence.</param>
        /// <returns>Task newly run.</returns>
        public Task StartSequence(ComPortAccessSequence NextSequence)
        {
            if (null == NextSequence)
            {
                return null;
            }

            Task<object> task = Task<object>.Run(() =>
            {
                this.OnSequenceStartingEvent(
                    new ConnectStateChangedEventArgs(
                        new ConnectState(NextSequence.StartingConnectionState)));

                if (null != this.CurSequence)
                {
                    this.CurSequence.StopSequence();
                    this.ReleaseEventHandler(this.CurSequence);
                    this.CurSequence = null;
                }

                this.CurSequence = NextSequence;
                this.SetupEventHandler(this.CurSequence);
                Task MainTask = this.CurSequence.StartSequence(this.ComPortAcc);
                this.OnSequenceStartedEvent(
                        new ConnectStateChangedEventArgs(
                            new ConnectState(this.CurSequence.StartedConnectionState)));

                return (object)MainTask;
            });
            return (Task)(task.Result);
        }

        /// <summary>
        /// Setup event handler to sequence passed by arguemnt.
        /// </summary>
        /// <param name="Sequence"></param>
        public void SetupEventHandler(ComPortAccessSequence Sequence)
        {
            Sequence.TaskFinishedEvent += this.SequenceFinisedEventCallback;
            Sequence.NotifySendReceiveDataEvent += this.NotifySendReceiveDataEventCallback;
            Sequence.NotifyRecvExceptionEvent += this.NotifyRecvExceptionEventCallback;
        }

        /// <summary>
        /// Release event handler from sequence passed by arguemnt.
        /// </summary>
        /// <param name="Sequence"></param>
        public void ReleaseEventHandler(ComPortAccessSequence Sequence)
        {
            Sequence.TaskFinishedEvent -= this.SequenceFinisedEventCallback;
            Sequence.NotifySendReceiveDataEvent -= this.NotifySendReceiveDataEventCallback;
            Sequence.NotifyRecvExceptionEvent -= this.NotifyRecvExceptionEventCallback;
        }

        /// <summary>
        /// Raise event to notify the sequence is ready for starting.
        /// </summary>
        /// <param name="e"></param>
        public void OnSequenceStartingEvent(EventArgs e)
        {
            this.SequenceStartingEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Raise event to notify the sequence has been started.
        /// </summary>
        /// <param name="e"></param>
        public void OnSequenceStartedEvent(EventArgs e)
        {
            this.SequenceStartedEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Raise event to notify the sequence has been finished.
        /// </summary>
        /// <param name="e"></param>
        public void OnSequenceFinishedEvent(EventArgs e)
        {
            this.SequenceFinishedEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Raise event to notify an exception has occurred.
        /// </summary>
        /// <param name="e"></param>
        public void OnExceptionReceiveEvent(EventArgs e)
        {
            this.ExceptionReceivedEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Raise event to notify the sequence has been finished.
        /// </summary>
        /// <param name="sender">Source of event. Not refered in this method.</param>
        /// <param name="e">Detail information about this event.</param>
        public void SequenceFinisedEventCallback(object sender, EventArgs e)
        {
            try
            {
                var Args = e as SequenceChangedEventArgs;
                bool ChangeResult = Args.SequenceChangedResult;
                this.OnSequenceFinishedEvent(
                    new ConnectStateChangedEventArgs(
                        new ConnectState(Args.ConnectState), ChangeResult));

                var SeqManager = ComPortAccessSequenceRunner.SequenceDictionary[this.SeqName];
                var Next = SequenceName.SEQUENCE_NAME_UNKNOWN;
                if (ChangeResult)
                {
                    Next = SeqManager.Success;
                }
                else
                {
                    Next = SeqManager.Failure;
                }
                //this.ChangeAndStartSequence(Next);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);

                this.OnSequenceFinishedEvent(
                    new ConnectStateChangedEventArgs(
                        new ConnectState(this.CurSequence.FinishedConnectionState)));
            }
        }

        /// <summary>
        /// Callback of notify send and Receive data event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotifySendReceiveDataEventCallback(object sender, EventArgs e)
        {
            this.OnDataSendReceiveEvent(e);
        }

        /// <summary>
        /// Callback to notify an exception has been occurred.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotifyRecvExceptionEventCallback(object sender, EventArgs e)
        {
            this.OnExceptionReceiveEvent(e);
        }
        /// <summary>
        /// Raise event to notify the sent and received data.
        /// </summary>
        /// <param name="e"></param>
        public void OnDataSendReceiveEvent(EventArgs e)
        {
            this.DataSendReceiveEvent?.Invoke(this, e);
        }
        #endregion

        #region Inner class of ComPortAccessSequenceRunner
        public class SequenceManager
        {
            public SequenceManager(
                SequenceName Success = SequenceName.SEQUENCE_NAME_UNKNOWN,
                SequenceName Failure = SequenceName.SEQUENCE_NAME_UNKNOWN)
            {
                this.Success = Success;
                this.Failure = Failure;
            }
            public SequenceName Success { get; protected set; }
            public SequenceName Failure { get; protected set; }
        }
        #endregion
    }
}
