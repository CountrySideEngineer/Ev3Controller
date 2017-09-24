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
        public void ComPortAccessSequenceRunnerTest()
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
            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);

            while (!Runner.CurTask.Status.Equals(TaskStatus.RanToCompletion)) ;

            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);

            while (!Runner.CurTask.Status.Equals(TaskStatus.RanToCompletion)) ;
            Assert.IsTrue(this.IsSequenceStartedEventHandler);
            Assert.IsTrue(this.IsSequenceStartingEventHandler);
            Assert.IsTrue(this.IsSequenceFinishedEventHandler);
            Assert.AreEqual(this.IsSequenceStartingEventHandlerCount, 2);
            Assert.AreEqual(this.IsSequenceStartedEventHandlerCount, 2);
            Assert.AreEqual(this.IsSequenceFinishedEventHandlerCount, 2);

            Runner.SequenceStartedEvent -= this.OnSequenceStartedEventHandler;
            Runner.SequenceStartingEvent -= this.OnSequenceStartingEventHandler;
            Runner.SequenceFinishedEvent -= this.OnSequenceFinishedEventHandler;
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
    }
}