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
        [TestCategory("ComPortConnectSequence_Sequence")]
        public void SequenceTest_001()
        {
            ComPortConnectSequence ConnectSequence = new ComPortConnectSequence();
            //object res = ConnectSequence.StartSequence(new ComPort("COM41", "Device"));
        }
    }
}