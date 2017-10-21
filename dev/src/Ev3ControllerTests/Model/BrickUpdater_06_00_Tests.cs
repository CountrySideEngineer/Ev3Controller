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
    public class BrickUpdater_06_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of Updat method of BrickUpdater_06_00
        [TestMethod()]
        [TestCategory("BrickUpdater_06_00")]
        [TestCategory("BrickUpdater_06_00_Update")]
        public void BrickUpdater_06_00_Update_Test_001()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[4] = 0x00;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_06_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(SafeState.SAFE_STATE.SAFE_STATE_SAFE, Brick.State.State);
            Assert.AreEqual("Safe", Brick.State.StateName);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_06_00")]
        [TestCategory("BrickUpdater_06_00_Update")]
        public void BrickUpdater_06_00_Update_Test_002()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[4] = 0x01;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_06_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(SafeState.SAFE_STATE.SAFE_STATE_ATTN, Brick.State.State);
            Assert.AreEqual("Attention", Brick.State.StateName);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_06_00")]
        [TestCategory("BrickUpdater_06_00_Update")]
        public void BrickUpdater_06_00_Update_Test_003()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[4] = 0x02;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_06_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(SafeState.SAFE_STATE.SAFE_STATE_WARN, Brick.State.State);
            Assert.AreEqual("Warning", Brick.State.StateName);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_06_00")]
        [TestCategory("BrickUpdater_06_00_Update")]
        public void BrickUpdater_06_00_Update_Test_004()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[4] = 0x03;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_06_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(SafeState.SAFE_STATE.SAFE_STATE_STOP, Brick.State.State);
            Assert.AreEqual("STOP", Brick.State.StateName);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_06_00")]
        [TestCategory("BrickUpdater_06_00_Update")]
        public void BrickUpdater_06_00_Update_Test_005()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[4] = 0x04;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_06_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(SafeState.SAFE_STATE.SAFE_STATE_UNKNOWN, Brick.State.State);
            Assert.AreEqual("ERROR", Brick.State.StateName);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_06_00")]
        [TestCategory("BrickUpdater_06_00_Update")]
        public void BrickUpdater_06_00_Update_Test_006()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[4] = 0x06;
            var Brick = Ev3Brick.GetInstance();
            var Updater = new BrickUpdater_06_00();
            Updater.Update(Command, Brick);

            Assert.AreEqual(SafeState.SAFE_STATE.SAFE_STATE_UNKNOWN, Brick.State.State);
            Assert.AreEqual("ERROR", Brick.State.StateName);
        }
        #endregion
    }
}