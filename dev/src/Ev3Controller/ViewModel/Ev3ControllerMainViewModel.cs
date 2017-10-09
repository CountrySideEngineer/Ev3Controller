using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    public class Ev3ControllerMainViewModel : ViewModelBase
    {
        #region Constructors and the Finalizer
        public Ev3ControllerMainViewModel()
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// View model object about COM port, Ev3PortViewModel.
        /// </summary>
        protected Ev3PortViewModel _PortViewModel;
        public Ev3PortViewModel PortViewModel
        {
            get
            {
                if (null == this._PortViewModel)
                {
                    this._PortViewModel = new Ev3PortViewModel();
                }
                return this._PortViewModel;
            }
        }
        #endregion
    }
}
