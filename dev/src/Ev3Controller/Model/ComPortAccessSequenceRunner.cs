using System;
using System.Collections.Generic;
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
            SEQUENCE_NAME_MAX,
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
        public Task task;

        /// <summary>
        /// Sequence now running.
        /// </summary>
        public ComPortAccessSequence CurSequence { get; protected set; }
        #endregion

        #region Factory Methods
        /// <summary>
        /// A factory method to create concrete ComPortAccessSequence object.
        /// </summary>
        /// <param name="SeqName">
        /// Identifier used int creating ComPortAccessSequence concrete object.
        /// </param>
        /// <returns>Concrete ComPortAccessSequence object.</returns>
        protected static ComPortAccessSequence SequenceFactory(SequenceName SeqName)
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
                default:
                    AccessSequence = null;
                    break;
            }
            return AccessSequence;
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ComPort">ComPort contains port name and its configuration.</param>
        public ComPortAccessSequenceRunner(ComPort ComPort)
        {
            this.ComPort = ComPort;
            this.ComPortAcc = new ComPortAccess(this.ComPort);
        }
        
        /// <summary>
        /// Stop current running sequence and start new one.
        /// </summary>
        /// <param name="SeqName">Identifier of new sequence.</param>
        public void ChangeSequence(SequenceName SeqName)
        {
            this.task = this.StartSequence(
                ComPortAccessSequenceRunner.SequenceFactory(SeqName));
        }

        /// <summary>
        /// Start new sequence in other async thread.
        /// </summary>
        /// <param name="NextSequence">New Sequence.</param>
        /// <returns>Task newly run.</returns>
        public Task StartSequence(ComPortAccessSequence NextSequence)
        {
            Task<object> task = Task<object>.Run(() =>
            {
                this.OnSequenceStartingEvent(null);

                if (null != this.CurSequence)
                {
                    this.CurSequence.StopSequence();
                    this.CurSequence.TaskFinishedEvent -= this.SequenceFinisedEvent;
                    this.CurSequence = null;
                }

                this.CurSequence = NextSequence;
                this.CurSequence.TaskFinishedEvent += this.SequenceFinisedEvent;
                Task MainTask = this.CurSequence.StartSequence(this.ComPortAcc);

                this.OnSequenceStartedEvent(null);

                return (object)MainTask;
            });
            return (Task)(task.Result);
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

        public void SequenceFinisedEvent(object sender, EventArgs e)
        {
            this.OnSequenceFinishedEvent(e);
        }
        #endregion
    }
}
