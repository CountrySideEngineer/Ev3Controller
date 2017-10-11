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
    public class ComPortConnectSequenceTests
    {
        [TestMethod()]
        [TestCategory("ComPortConnectSequence_ComPortConnectSequence")]
        public void ComPortConnectSequenceTest()
        {
            var TestTarget = new ComPortConnectSequence();

            Assert.IsTrue(TestTarget.HasStartingMessage);
            Assert.IsTrue(TestTarget.HasStartedMessage);
            Assert.IsTrue(TestTarget.HasFinishedMessage);
            Assert.AreEqual(TestTarget.StartingMessage, "Connecting");
            Assert.AreEqual(TestTarget.StartedMessage, "Connecting");
            Assert.AreEqual(TestTarget.FinishedMessage, "Connected");
            Assert.AreEqual(TestTarget.StartingConnectionState, ConnectionState.Connecting);
            Assert.AreEqual(TestTarget.StartedConnectionState, ConnectionState.Connecting);
            Assert.AreEqual(TestTarget.FinishedConnectionState, ConnectionState.Connected);
        }
    }
}