﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel
{
    public class Ev3MotorSteerViewModel : ViewModelBase
    {
        #region
        public Ev3MotorSteerViewModel()
        {
            this.TargetMotorOutput = 0;
            this.TargetSteer = 0;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Target motor output value.
        /// Positive value means the motor drives forward and negative means it rorates back reverse
        /// direction.
        /// </summary>
        protected int _TargetMotorOutput;
        public int TargetMotorOutput
        {
            get { return this._TargetMotorOutput; }
            set
            {
                this._TargetMotorOutput = value;
                this.RaisePropertyChanged("TargetMotorOutput");
            }
        }

        /// <summary>
        /// Target steering.
        /// Positive value means that a vehicle turns left and negative means it turns right.
        /// </summary>
        protected int _TargetSteer;
        public int TargetSteer
        {
            get { return this._TargetSteer; }
            set
            {
                this._TargetSteer = value;
                this.RaisePropertyChanged("TargetSteer");
            }
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Reset properties.
        /// </summary>
        public void Reset()
        {
            this.ResetMotorOutput();
            this.ResetSteer();
        }
        public void ResetMotorOutput() { this.TargetMotorOutput = 0; }
        public void ResetSteer() { this.TargetSteer = 0; }
        #endregion
    }
}
