using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class BrickUpdater_00_00_Tests : Ev3Brick_TestBase
    {
        #region Initialize test environment.
        [TestMethod]
        [TestInitialize]
        public override void Init() { base.Init(); }
        #endregion

        [TestMethod()]
        [TestCategory("BrickUpdater_00_00")]
        [TestCategory("BrickUpdater_00_00_Update")]
        public void BrickUpdater_00_00_Update_Test_001()
        {
            var Updater = new BrickUpdater_00_00();
            Updater.Update(new Command_00_00(), Ev3Brick.GetInstance());
        }
    }
}