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
            ComPortAccessSequenceRunner Runner =
                new ComPortAccessSequenceRunner(new ComPort("COM41", "Device"));

            Runner.SequenceStartedEvent += this.OnSequenceStartedEventHandler;
            Runner.SequenceStartingEvent += this.OnSequenceStartingEventHandler;
            Runner.SequenceFinishedEvent += this.OnSequenceFinishedEventHandler;
            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);

            Thread.Sleep(10000);

            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);

            while (!this.IsSequenceFinishedEventHandler) { }

            Assert.IsTrue(this.IsSequenceStartedEventHandler);
            Assert.IsTrue(this.IsSequenceStartingEventHandler);
            Assert.IsTrue(this.IsSequenceFinishedEventHandler);

            Runner.SequenceStartedEvent -= this.OnSequenceStartedEventHandler;
            Runner.SequenceStartingEvent -= this.OnSequenceStartingEventHandler;
            Runner.SequenceFinishedEvent -= this.OnSequenceFinishedEventHandler;
        }

        protected bool IsSequenceStartingEventHandler;
        public void OnSequenceStartingEventHandler(object sender, EventArgs e)
        {
            IsSequenceStartingEventHandler = true;
        }
        protected bool IsSequenceStartedEventHandler;
        public void OnSequenceStartedEventHandler(object sender, EventArgs e)
        {
            IsSequenceStartedEventHandler = true;
        }
        protected bool IsSequenceFinishedEventHandler;
        public void OnSequenceFinishedEventHandler(object sender, EventArgs e)
        {
            IsSequenceFinishedEventHandler = true;
        }
    }
}