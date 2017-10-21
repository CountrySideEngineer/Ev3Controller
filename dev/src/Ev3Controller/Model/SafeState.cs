using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class SafeState
    {
        #region Private fields and constants (in a region)
        protected Dictionary<SAFE_STATE, string> SafeStateDictionary = new Dictionary<SAFE_STATE, string>()
        {
            { SAFE_STATE.SAFE_STATE_SAFE, "Safe" },
            { SAFE_STATE.SAFE_STATE_ATTN, "Attention" },
            { SAFE_STATE.SAFE_STATE_WARN, "Warning" },
            { SAFE_STATE.SAFE_STATE_STOP, "STOP" },
        };
        #endregion

        #region Public constants
        public enum SAFE_STATE
        {
            SAFE_STATE_SAFE,
            SAFE_STATE_ATTN,
            SAFE_STATE_WARN,
            SAFE_STATE_STOP,
            SAFE_STATE_MAX,
        };
        #endregion

        #region Constructors and the Finalizer
        public SafeState()
        {
            this.State = SAFE_STATE.SAFE_STATE_SAFE;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Safe state informatino.
        /// </summary>
        public SAFE_STATE State { get; set; }

        /// <summary>
        /// Safe state string.
        /// </summary>
        public string StateName
        {
            get
            {
                return SafeStateDictionary[this.State];
            }
        }
        #endregion
    }
}
