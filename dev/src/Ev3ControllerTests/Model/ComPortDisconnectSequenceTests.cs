using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class ComPortDisconnectSequenceTests
    {
        [TestMethod()]
        [TestCategory("ComPortDisconnectSequence_ComPortDisconnectSequence")]
        public void ComPortDisconnectSequenceTest_001()
        {
            var TestTarget = new ComPortDisconnectSequence();

            Assert.IsTrue(TestTarget.HasStartingMessage);
            Assert.IsTrue(TestTarget.HasStartedMessage);
            Assert.IsTrue(TestTarget.HasFinishedMessage);
            Assert.AreEqual(TestTarget.StartingMessage, "Disconnecting");
            Assert.AreEqual(TestTarget.StartedMessage, "Disconnecting");
            Assert.AreEqual(TestTarget.FinishedMessage, "Disconnected");
        }
    }
}