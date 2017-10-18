using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command.Tests
{
    [TestClass()]
    public class CommandParam_12_00_Tests
    {
        #region Unit test of Command_0E_00 Constructor.
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("CommandParam_12_00")]
        [TestCategory("CommandParam_12_00_Constructor")]
        public void CommandParam_12_00_Constructor_001()
        {
            var CommandParam = new CommandParam_12_00(0, 0);

            Assert.AreEqual(0, CommandParam.Power);
            Assert.AreEqual(0, CommandParam.Direction);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("CommandParam_12_00")]
        [TestCategory("CommandParam_12_00_Constructor")]
        public void CommandParam_12_00_Constructor_002()
        {
            var CommandParam = new CommandParam_12_00(0x64, 1);

            Assert.AreEqual(0x64, CommandParam.Power);
            Assert.AreEqual(1, CommandParam.Direction);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("CommandParam_12_00")]
        [TestCategory("CommandParam_12_00_Constructor")]
        public void CommandParam_12_00_Constructor_003()
        {
            var CommandParam = new CommandParam_12_00(0x65, 2);

            Assert.AreEqual(0x64, CommandParam.Power);
            Assert.AreEqual(1, CommandParam.Direction);
        }
        #endregion
    }
}