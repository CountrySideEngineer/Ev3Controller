using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        #region Other methods and private properties in calling order
        /// <summary>
        /// Reset device data of safe state 
        /// </summary>
        public override void ResetDevice()
        {
            base.ResetDevice();

            this.SafetyState = "";
        }

        /// <summary>
        /// Image source for connect state.
        /// </summary>
        protected BitmapImage _ImageSource;
        public BitmapImage ImageSource
        {
            get
            {
                return this._ImageSource;
            }
            set
            {
                this._ImageSource = value;
                this.RaisePropertyChanged("ImageSource");
            }
        }
        #endregion
    }
}
