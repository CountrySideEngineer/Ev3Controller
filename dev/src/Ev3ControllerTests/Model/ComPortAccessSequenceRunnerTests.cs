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
            ComPortAccessSequenceRunner Runner =
                new ComPortAccessSequenceRunner(new ComPort("COM41", "Device"));
            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_CONNECT);

            Thread.Sleep(10000);

            Runner.ChangeSequence(ComPortAccessSequenceRunner.SequenceName.SEQUENCE_NAME_DISCONNECT);

            Thread.Sleep(5000);
        }
    }
}