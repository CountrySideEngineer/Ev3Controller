using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    /// <summary>
    /// Implement each sequence to access COM port, open and close , and read and write.
    /// </summary>
    public abstract class ComPortAccessSequence
    {
        #region Public constants
        /// <summary>
        /// Flag whether the loop continues or not.
        /// This flag must be changed only in this class method, \"Sequence\" or \"StopSequence\".
        /// </summary>
        public bool DoesContinue { get; protected set; }

        /// <summary>
        /// Flag shows the method \"Sequence\" is running or not.
        /// </summary>
        public bool IsRunning { get; protected set; }
        #endregion

        #region Public Properties
        /// <summary>
        /// Flag show whether the object has message to show when the sequence starting.
        /// </summary>
        public bool HasStartingMessage { get; protected set; }

        /// <summary>
        /// Flag show whether the object has message to show when the sequence started.
        /// </summary>
        public bool HasStartedMessage { get; protected set; }

        /// <summary>
        /// Flag show whether the object has message to show when the sequence finished.
        /// </summary>
        public bool HasFinishedMessage { get; protected set; }

        /// <summary>
        /// A message shown when the sequence starting.
        /// </summary>
        public string StartingMessage { get; protected set; }

        /// <summary>
        /// A message shown when the sequence started.
        /// </summary>
        public string StartedMessage { get; protected set; }

        /// <summary>
        /// A message shown when the sequence finished.
        /// </summary>
        public string FinishedMessage { get; protected set; }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Call a sequence of.
        /// </summary>
        /// <param name="obj"></param>
        public object StartSequence(ComPortAccess ComPortAcc)
        {
            return this.Sequence(ComPortAcc);
        }

        /// <summary>
        /// Wait for Sequence method does finish.
        /// </summary>
        public void StopSequence()
        {
            if (this.IsRunning)
            {
                this.DoesContinue = false;
                while (this.IsRunning);
            }
        }

        /// <summary>
        /// Abstract method to run main sequence to access COM port.
        /// </summary>
        /// <param name="ComPortAcc">ComPortAccess object used to access COM port.</param>
        /// <returns>Result of the sequence.</returns>
        public abstract object Sequence(ComPortAccess ComPortAcc);
        #endregion
    }
}
