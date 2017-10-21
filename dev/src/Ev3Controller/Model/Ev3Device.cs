using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class Ev3Device
    {
        #region Constructors and the Finalizer
        public Ev3Device()
        {
            this.Port = "";
            this.Name = "";
            this.Device = "";
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Name of port.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Device name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Device type.
        /// </summary>
        public string Device { get; set; }
        #endregion
    }
}
