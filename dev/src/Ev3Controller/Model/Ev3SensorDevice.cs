using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class Ev3SensorDevice : Ev3Device
    {
        #region Constructors and the Finalizer
        public Ev3SensorDevice()
        {
            this.Value1 = 0;
            this.Value2 = 0;
            this.Value3 = 0;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Sensor value1.
        /// </summary>
        public int Value1 { get; set; }

        /// <summary>
        /// Sensor value2.
        /// </summary>
        public int Value2 { get; set; }

        /// <summary>
        /// Sensor value3.
        /// </summary>
        public int Value3 { get; set; }
        #endregion
    }
}
