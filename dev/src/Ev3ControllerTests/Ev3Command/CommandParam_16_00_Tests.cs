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
    public class CommandParam_16_00_Tests
    {
        #region Unit test of CommandParam_16_00
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("CommandParam_16_00")]
        [TestCategory("CommandParam_16_00_Constructor")]
        public void CommandParam_16_00_Test_001()
        {
            var CommandParam = new CommandParam_16_00(0);

            Assert.AreEqual(0, CommandParam.Steer);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("CommandParam_16_00")]
        [TestCategory("CommandParam_16_00_Constructor")]
        public void CommandParam_16_00_Test_002()
        {
            var CommandParam = new CommandParam_16_00(1);

            Assert.AreEqual(1, CommandParam.Steer);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        [TestCategory("CommandParam_16_00")]
        [TestCategory("CommandParam_16_00_Constructor")]
        public void CommandParam_16_00_Test_003()
        {
            var CommandParam = new CommandParam_16_00(-1);

            Assert.AreEqual(-1, CommandParam.Steer);
        }
        #endregion
    }
}