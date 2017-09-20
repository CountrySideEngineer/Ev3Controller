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
    public class ComPortAccessSequenceTests
    {
        public ComPortAccessSequence TestTarget;
        public ComPortAccess Result;
        #region Setup test.
        [TestInitialize()]
        public void Initialize()
        {
            TestTarget = new ComPortAccessSequence();
            Result = null;
        }
        #endregion

        #region Clean up, finalize test.
        [TestCleanup()]
        public void Fin()
        {
            if ((this.Result != null) && (this.Result.Port.IsOpen))
            {
                this.Result.Disconnect();
            }
        }
        #endregion

        #region Unit test of ConnectSequenceTaskTest method.
        [TestMethod()]
        [TestCategory("ComPortAccessSequence_ConnectSequenceTask")]
        public void ConnectSequenceTaskTest_001()
        {
            var Sequence = new ComPortAccessSequence();
            this.Result = Sequence.ConnectSequenceTask(new ComPort("COM44", "DEVICE"));

            Assert.AreEqual(this.Result.ComPort.Name, "COM44");
            Assert.IsTrue(this.Result.Port.IsOpen);
        }
        [TestMethod()]
        [TestCategory("ComPortAccessSequence_ConnectSequenceTask")]
        public void ConnectSequenceTaskTest_002()
        {
            var Sequence = new ComPortAccessSequence();
            var ComPort = new ComPort("COM44", "DEVICE");
            var ComPortAccess = new ComPortAccess();
            ComPortAccess.Connect(ComPort);
            this.Result = Sequence.ConnectSequenceTask(new ComPort("COM44", "DEVICE"));

            Assert.IsNull(this.Result);

            ComPortAccess.Disconnect();
        }
        #endregion

        #region Unit test of DisconnectSequenceTask
        [TestMethod()]
        [TestCategory("ComPortAccessSequence_DisconnectSequenceTask")]
        public void DisconnectSequenceTaskTest_001()
        {
            var ComPortAccess = new ComPortAccess();
            ComPortAccess.Connect(new ComPort("COM44", "DEVICE"));

            this.TestTarget.DisconnectSequenceTask(ComPortAccess);

            Assert.IsNull(ComPortAccess.Port);
        }
        #endregion
    }
}