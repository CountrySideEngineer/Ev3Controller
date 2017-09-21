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
        public ComPortAccessSequenceRunner(ComPort ComPort)
        {
            this.ComPort = ComPort;
            this.ComPortAcc = new ComPortAccess(this.ComPort);
        }

        public void ChangeSequence(SequenceName SeqName)
        {
            this.task = this.StartSequence(
                ComPortAccessSequenceRunner.SequenceFactory(SeqName));
        }

        public Task StartSequence(ComPortAccessSequence NextSequence)
        {
            Task task = Task.Run(() =>
            {
                this.OnSequenceStartingEvent(null);

                if (null != this.CurSequence)
                {
                    this.CurSequence.StopSequence();
                }

                this.CurSequence = NextSequence;
                this.CurSequence.StartSequence(this.ComPortAcc);

                this.OnSequenceStartingEvent(null);
            }).ContinueWith((PreTask) =>
            {
                this.OnSequenceFinisheedEvent(null);
            });
            return task;
        }

        public void OnSequenceStartingEvent(EventArgs e)
        {
            this.SequenceStartingEvent?.Invoke(this, e);
        }

        public void OnSequenceStartedEvent(EventArgs e)
        {
            this.SequenceStartedEvent?.Invoke(this, e);
        }

        public void OnSequenceFinisheedEvent(EventArgs e)
        {
            this.SequenceFinishedEvent?.Invoke(this, e);
        }
        #endregion
    }
}
