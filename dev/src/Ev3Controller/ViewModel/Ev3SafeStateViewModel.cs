using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    public class Ev3SafeStateViewModel : DeviceViewModelBase
    {
        #region Public Properties
        /// <summary>
        /// State that shows safe state.
        /// </summary>
        protected string _SafetyState;
        public string SafetyState
        {
            get { return _SafetyState; }
            set
            {
                this._SafetyState = value;
                this.RaisePropertyChanged("SafetyState");
            }
        }
        #endregion
    }
}
