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
    public class BrickUpdater_Tests
    {
        #region Unit test of Factory method of BrickUpdater.
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_001()
        {
            var Command = new Command_00_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_00_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_002()
        {
            var Command = new Command_02_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_02_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_003()
        {
            var Command = new Command_04_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_04_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_004()
        {
            var Command = new Command_06_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_06_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_005()
        {
            var Command = new Command_0C_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_0C_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_006()
        {
            var Command = new Command_0E_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_0E_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_007()
        {
            var Command = new Command_10_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_10_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_008()
        {
            var Command = new Command_20_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_20_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_009()
        {
            var Command = new Command_20_01();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_20_01);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_010()
        {
            var Command = new Command_30_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_30_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_011()
        {
            var Command = new Command_30_01();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_30_01);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_012()
        {
            var Command = new Command_30_02();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_30_02);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_013()
        {
            var Command = new Command_40_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_40_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_014()
        {
            var Command = new Command_50_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_50_00);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_015()
        {
            var Command = new Command_50_01();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_50_01);
        }
        [TestMethod()]
        [TestCategory("BrickUpdater")]
        [TestCategory("BrickUpdater_Factory_Test")]
        public void BrickUpdater_Factory_Test_016()
        {
            var Command = new Command_A0_00();
            var Updater = BrickUpdater.Factory(Command);

            Assert.IsTrue(Updater is BrickUpdater_A0_00);
        }
        #endregion
    }
}