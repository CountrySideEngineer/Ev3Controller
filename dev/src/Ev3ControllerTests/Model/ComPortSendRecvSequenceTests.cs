using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ev3ControllerTests.Model.Tests;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class ComPortSendRecvSequenceTests : ComPortAccessSequenceTestBase
    {
        [TestMethod()]
        [TestCategory("ComPortSendRecvSequence_Sequence")]
        public void SequenceTest_001()
        {
            this.Init();

            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);
            while (!Runner.CurTask.Status.Equals(TaskStatus.RanToCompletion)) ;

            Assert.IsTrue(this.IsSequenceStartedEventHandler);
            Assert.IsTrue(this.IsSequenceStartingEventHandler);
            Assert.IsTrue(this.IsSequenceFinishedEventHandler);
            Assert.AreEqual(this.IsSequenceStartingEventHandlerCount, 1);
            Assert.AreEqual(this.IsSequenceStartedEventHandlerCount, 1);
            Assert.AreEqual(this.IsSequenceFinishedEventHandlerCount, 1);

            this.Init();
            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_SEND_AND_RECV);

            Thread.Sleep(1000);

            Assert.IsTrue(this.IsSequenceStartedEventHandler);
            Assert.IsTrue(this.IsSequenceStartingEventHandler);
            Assert.IsFalse(this.IsSequenceFinishedEventHandler);
            Assert.AreEqual(this.IsSequenceStartingEventHandlerCount, 1);
            Assert.AreEqual(this.IsSequenceStartedEventHandlerCount, 1);
            Assert.AreEqual(this.IsSequenceFinishedEventHandlerCount, 0);

            this.Init();
            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);

            while (!Runner.CurTask.Status.Equals(TaskStatus.RanToCompletion)) ;

            Assert.IsTrue(this.IsSequenceStartedEventHandler);
            Assert.IsTrue(this.IsSequenceStartingEventHandler);
            Assert.IsTrue(this.IsSequenceFinishedEventHandler);
            Assert.AreEqual(this.IsSequenceStartingEventHandlerCount, 1);
            Assert.AreEqual(this.IsSequenceStartedEventHandlerCount, 1);
            //1st:Send and received senqeuce stopped, 2nd:Stop sequence finished.
            Assert.AreEqual(this.IsSequenceFinishedEventHandlerCount, 2);
        }
    }
}