using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    /// <summary>
    /// Argument for IsConnectedChanged event.
    /// </summary>
    public class IsConnectedChangedEventArgs : EventArgs
    {
        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="OldValue">Value before event.</param>
        /// <param name="NewValue">Value after event.</param>
        public IsConnectedChangedEventArgs(bool OldValue, bool NewValue)
        {
            this.OldValue = OldValue;
            this.NewValue = NewValue;
        }
        /// <summary>
        /// Constructor with one argument, only NewValue.
        /// If this constructor used, OldValue property is set false.
        /// </summary>
        /// <param name="NewValue">Value after event.</param>
        public IsConnectedChangedEventArgs(bool NewValue)
        {
            this.OldValue = false;
            this.NewValue = NewValue;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Connection state, connected to device or not, before event raised.
        /// </summary>
        public bool OldValue { get; protected set; }

        /// <summary>
        /// Connection state, connected to device or not, result of event.
        /// </summary>
        public bool NewValue { get; protected set; }
        #endregion
    }
}
