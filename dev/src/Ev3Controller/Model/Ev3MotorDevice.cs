using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class Ev3MotorDevice : Ev3Device
    {
        #region Constructors and the Finalizer
        public Ev3MotorDevice()
        {
            this.Power = 0;
            this.Counts = 0;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Motor output power.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Angle position of motor.
        /// </summary>
        public long Counts { get; set; }
        #endregion
    }
}
