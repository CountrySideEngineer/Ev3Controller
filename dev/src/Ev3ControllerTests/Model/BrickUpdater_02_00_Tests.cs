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
    public class BrickUpdater_02_00_Tests : Ev3Brick_TestBase
    {
        #region Unit test of Update method of BrickUpdater_02_00.
        [TestMethod()]
        [TestCategory("BrickUpdater_02_00")]
        [TestCategory("BrickUpdater_02_00_Update")]
        public void BrickUpdater_02_00_Update_Test_001()
        {
            var Command = new Command_02_00();
            Command.ResData = new byte[6];
            Command.ResData[4] = 0xAA;
            Command.ResData[5] = 0x55;

            var Updater = new BrickUpdater_02_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.AreEqual(0xAA, Brick.Version.Major);
            Assert.AreEqual(0x55, Brick.Version.Minor);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater_02_00")]
        [TestCategory("BrickUpdater_02_00_Update")]
        public void BrickUpdater_02_00_Update_Test_002()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[6];
            Command.ResData[4] = 0xAA;
            Command.ResData[5] = 0x55;

            var Updater = new BrickUpdater_02_00();
            var Brick = Ev3Brick.GetInstance();
            Updater.Update(Command, Brick);

            Assert.AreEqual(0x00, Brick.Version.Major);
            Assert.AreEqual(0x00, Brick.Version.Minor);
        }
        #endregion
    }
}