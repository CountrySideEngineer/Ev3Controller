using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class ComPortAccessSequenceRunnerTests
    {
        [TestMethod()]
        public void ChangeSequenceTest()
        {
            ComPortAccessSequenceRunner Runner = new ComPortAccessSequenceRunner(new ComPort("", ""));

            Task tsk = Runner.StartSequence(null);

            Thread.Sleep(4000);

            Console.WriteLine("End test");

        }

        [TestMethod()]
        [TestCategory("ComPortAccessSequenceRunner_ChangeSequence")]
        public void ComPortAccessSequenceRunnerTest_001()
        {
            this.IsSequenceStartedEventHandler = false;
            this.IsSequenceStartingEventHandler = false;
            this.IsSequenceFinishedEventHandler = false;
            this.IsSequenceStartingEventHandlerCount = 0;
            this.IsSequenceStartedEventHandlerCount = 0;
            this.IsSequenceStartingEventHandlerCount = 0;
            ComPortAccessSequenceRunner Runner =
                new ComPortAccessSequenceRunner(new ComPort("COM41", "Device"));

            Runner.SequenceStartedEvent += this.OnSequenceStartedEventHandler;
            Runner.SequenceStartingEvent += this.OnSequenceStartingEventHandler;
            Runner.SequenceFinishedEvent += this.OnSequenceFinishedEventHandler;
            Runner.DataSendReceiveEvent += this.OnDataSendRecvEventHandler;
            Runner.ChangeAndStartSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);

            while (!Runner.CurTask.Status.Equals(TaskStatus.RanToCompletion)) ;

            Runner.ChangeAndStartSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_SEND_AND_RECV);

            Thread.Sleep(3000);
            Assert.IsTrue(this.IsSequenceStartedEventHandler);
            Assert.IsTrue(this.IsSequenceStartingEventHandler);
            Assert.IsTrue(this.IsSequenceFinishedEventHandler);

            Runner.ChangeAndStartSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);

            while (!Runner.CurTask.Status.Equals(TaskStatus.RanToCompletion)) ;
            Assert.IsTrue(this.IsSequenceStartedEventHandler);
            Assert.IsTrue(this.IsSequenceStartingEventHandler);
            Assert.IsTrue(this.IsSequenceFinishedEventHandler);
            Assert.IsTrue(this.IsDataSendRecvEventHandler);
            Assert.AreEqual(this.IsSequenceStartingEventHandlerCount, 3);
            Assert.AreEqual(this.IsSequenceStartedEventHandlerCount, 3);
            Assert.AreEqual(this.IsSequenceFinishedEventHandlerCount, 3);

            Runner.SequenceStartedEvent -= this.OnSequenceStartedEventHandler;
            Runner.SequenceStartingEvent -= this.OnSequenceStartingEventHandler;
            Runner.SequenceFinishedEvent -= this.OnSequenceFinishedEventHandler;
            Runner.DataSendReceiveEvent -= this.OnDataSendRecvEventHandler;
        }

        protected bool IsSequenceStartingEventHandler;
        protected int IsSequenceStartingEventHandlerCount;
        public void OnSequenceStartingEventHandler(object sender, EventArgs e)
        {
            IsSequenceStartingEventHandler = true;
            IsSequenceStartingEventHandlerCount++;
        }
        protected bool IsSequenceStartedEventHandler;
        protected int IsSequenceStartedEventHandlerCount;
        public void OnSequenceStartedEventHandler(object sender, EventArgs e)
        {
            IsSequenceStartedEventHandler = true;
            IsSequenceStartedEventHandlerCount++;
        }
        protected bool IsSequenceFinishedEventHandler;
        protected int IsSequenceFinishedEventHandlerCount;
        public void OnSequenceFinishedEventHandler(object sender, EventArgs e)
        {
            IsSequenceFinishedEventHandler = true;
            IsSequenceFinishedEventHandlerCount++;
        }
        protected bool IsDataSendRecvEventHandler;
        protected int DataSendRecvEventHandlerCount;
        public void OnDataSendRecvEventHandler(object sender, EventArgs e)
        {
            IsDataSendRecvEventHandler = true;
            DataSendRecvEventHandlerCount++;

            if (e is NotifySendReceiveDataEventArgs)
            {
                var EventArg = e as NotifySendReceiveDataEventArgs;

                Console.WriteLine(@"Send:");
                foreach (byte ByteData in EventArg.SendData)
                {
                    Console.Write(string.Format("0x{0:x2} ", ByteData));
                }
                Console.WriteLine(@"");

                Console.WriteLine(@"Recv:");
                foreach (byte ByteData in EventArg.RecvData)
                {
                    Console.Write(string.Format("0x{0:x2} ", ByteData));
                }
                Console.WriteLine(@"");
            }
        }

        #region Unit test of SequenceFactory static method.

        [TestMethod()]
        [TestCategory("ComPortAccessSequenceRunner")]
        [TestCategory("ComPortAccessSequenceRunner_SequenceFactory")]
        public void SequenceFactoryTest_001()
        {
            var Sequence =
                ComPortAccessSequenceRunner.SequenceFactory(
                    ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);

            Assert.IsInstanceOfType(Sequence, typeof(ComPortConnectSequence));
        }
        [TestMethod()]
        [TestCategory("ComPortAccessSequenceRunner")]
        [TestCategory("ComPortAccessSequenceRunner_SequenceFactory")]
        public void SequenceFactoryTest_002()
        {
            var Sequence =
                ComPortAccessSequenceRunner.SequenceFactory(
                    ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);

            Assert.IsInstanceOfType(Sequence, typeof(ComPortDisconnectSequence));
        }
        [TestMethod()]
        [TestCategory("ComPortAccessSequenceRunner")]
        [TestCategory("ComPortAccessSequenceRunner_SequenceFactory")]
        public void SequenceFactoryTest_003()
        {
            var Sequence =
                ComPortAccessSequenceRunner.SequenceFactory(
                    ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_SEND_AND_RECV);

            Assert.IsInstanceOfType(Sequence, typeof(EchoBackComPortSendRecvSequence));
        }
        [TestMethod()]
        [TestCategory("ComPortAccessSequenceRunner")]
        [TestCategory("ComPortAccessSequenceRunner_SequenceFactory")]
        public void SequenceFactoryTest_004()
        {
            var Sequence =
                ComPortAccessSequenceRunner.SequenceFactory(
                    ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_UNKNOWN);

            Assert.IsNull(Sequence);
        }
        [TestMethod()]
        [TestCategory("ComPortAccessSequenceRunner")]
        [TestCategory("ComPortAccessSequenceRunner_SequenceFactory")]
        public void SequenceFactoryTest_005()
        {
            var Sequence =
                ComPortAccessSequenceRunner.SequenceFactory(
                    ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_MAX);

            Assert.IsNull(Sequence);
        }
        #endregion

        #region Unit test of SetComPort method
        [TestMethod()]
        [TestCategory("ComPortAccessSequenceRunner")]
        [TestCategory("ComPortAccessSequenceRunner_SetComPort")]
        public void SetComPortTest_001()
        {
            var Runner = new ComPortAccessSequenceRunner();
            Runner.SetComPort(new ComPort("COM41", "Device"));

            Assert.AreEqual("COM41", Runner.ComPort.Name);
            Assert.AreEqual("Device", Runner.ComPort.Device);
            Assert.AreEqual("COM41", Runner.ComPortAcc.ComPort.Name);
            Assert.AreEqual("Device", Runner.ComPortAcc.ComPort.Device);
            Assert.AreEqual(null, Runner.CurTask);
        }
        #endregion
    }
}