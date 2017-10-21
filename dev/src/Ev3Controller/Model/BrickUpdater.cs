using Ev3Controller.Ev3Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public abstract class BrickUpdater
    {
        #region Factory Methods
        public static void Factory(ACommand Cmd)
        {

        }
        #endregion

        #region
        public abstract void Update(ACommand Command, Ev3Brick Brick);
        #endregion
    }
}
