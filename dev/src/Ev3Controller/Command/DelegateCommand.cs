using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ev3Controller.Command
{
    public class DelegateCommand : ICommand
    {
        #region Private fields and constants (in a region)
        /// <summary>
        /// Body of command operation.
        /// </summary>
        protected Action _Execute;

        /// <summary>
        /// Body of command operation with argument.
        /// </summary>
        protected Action<object> _ExecuteObj;
        
        /// <summary>
        /// Shows whether the command can execute or not.
        /// </summary>
        protected Func<bool> _CanExecute;
        #endregion

        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor.
        /// Create the object with specifying the method called when the Execute method run.
        /// </summary>
        /// <param name="_Execute"></param>
        public DelegateCommand(Action _Execute) : this(_Execute, () => true) { }
        public DelegateCommand(Action _Execute, Func<bool> _CanExecute)
        {
            if (null == _Execute)
            {
                throw new ArgumentNullException("_Execute");
            }
            if (null == _CanExecute)
            {
                throw new ArgumentNullException("_CanExecute");
            }
            this._Execute = _Execute;
            this._CanExecute = _CanExecute;
        }
        public DelegateCommand(Action<object> _ExecuteObj) : this(_ExecuteObj, () => true) { }
        public DelegateCommand(Action<object> _ExecuteObj, Func<bool> _CanExecute)
        {
            if (null == _Execute)
            {
                throw new ArgumentNullException("_ExecuteObj");
            }
            if (null == _CanExecute)
            {
                throw new ArgumentNullException("_CanExecute");
            }
            this._ExecuteObj = _ExecuteObj;
            this._CanExecute = _CanExecute;
        }
        #endregion

        #region Event
        /// <summary>
        /// Event to notify the CanExecute method result has changed.
        /// </summary>
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return this._CanExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            this._Execute();
        }
        #endregion
    }

    public class DelegateCommand<T> : ICommand
    {
        #region Private fields and constants
        private readonly Action<T> _Execute;
        private readonly Predicate<object> _CanExecute;
        #endregion

        #region Event
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        public bool CanExecute(object parameter)
        {
            return this._CanExecute == null ? true : this._CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._Execute((T)parameter);
        }

        #region Constructors and the Finalizer
        public DelegateCommand(Action<T> _Execute, Predicate<object> _CanExecute)
        {
            if (null == _Execute)
            {
                throw new ArgumentNullException("_Execute");
            }
            this._Execute = _Execute;
            this._CanExecute = _CanExecute;
        }
        #endregion
    }
}
