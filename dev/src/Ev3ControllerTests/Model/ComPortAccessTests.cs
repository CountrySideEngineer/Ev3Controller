using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Ev3Controller.ViewModel;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class ComPortAccessTests
    {
        public ComPortAccess TestTarget;

        [TestInitialize()]
        public void InitTest()
        {
            this.TestTarget = new ComPortAccess(new ComPort("COM44", "Device"));
        }

        [TestCleanup()]
        public void FinalizeTest()
        {
            this.TestTarget.Disconnect();
        }

        #region Unit test of Connect method.
        [TestMethod()]
        [TestCategory("ComPortAccess_Connect")]
        public void ConnectTest_001()
        {
            Assert.IsTrue(this.TestTarget.Connect());
            Assert.IsTrue(this.TestTarget.Port.IsOpen);
        }
        [TestMethod()]
        [TestCategory("ComPortAccess_Connect")]
        public void ConnectTest_002()
        {
            this.TestTarget = new ComPortAccess(new ComPort("COM100", "Device"));
            Assert.IsFalse(this.TestTarget.Connect());
            Assert.IsFalse(this.TestTarget.Port.IsOpen);
        }
        [TestMethod()]
        [TestCategory("ComPortAccess_Connect")]
        public void ConnectTest_003()
        {
            this.TestTarget = new ComPortAccess(new ComPort("COM10", "Device"));
            Assert.IsFalse(this.TestTarget.Connect());
            Assert.IsFalse(this.TestTarget.Port.IsOpen);
        }
        [TestMethod()]
        [TestCategory("ComPortAccess_Connect")]
        public void ConnectTest_004()
        {
            Assert.IsTrue(this.TestTarget.Connect(new ComPort("COM45", "Device2")));
            Assert.IsTrue(this.TestTarget.Port.IsOpen);
        }
        [TestMethod()]
        [TestCategory("ComPortAccess_Connect")]
        public void ConnectTest_005()
        {
            Assert.IsTrue(this.TestTarget.Connect());
            Assert.IsFalse(this.TestTarget.Connect());
            Assert.IsTrue(this.TestTarget.Port.IsOpen);
        }
        #endregion

        #region Unit test of Disconnect method.
        [TestMethod()]
        [TestCategory("ComPortAccess_Disconnect")]
        public void DisconnectTest_001()
        {
            this.TestTarget.Connect();
            this.TestTarget.Disconnect();
            Assert.IsNull(this.TestTarget.Port);
        }
        [TestMethod()]
        [TestCategory("ComPortAccess_Disconnect")]
        public void DisconnectTest_002()
        {
            this.TestTarget.Connect();
            this.TestTarget.Disconnect();
            this.TestTarget.Disconnect();
        }
        #endregion

        #region Unit test of SendData method.
        [TestMethod()]
        [TestCategory("ComPortAccess_SendData")]
        public void SendDataTest_001()
        {
            byte[] Data = new byte[18];
            for (int i = 0; i < 18; i++)
            {
                Data[i] = (byte)(97 + i);//97 means 'a' in ASCII code.
            }

            this.TestTarget.Connect();
            this.TestTarget.SendData(Data);
            this.TestTarget.Disconnect();
        }
        #endregion

        [TestMethod()]
        [TestCategory("ComPortAccess_Init")]
        public void InitTest1()
        {
            this.TestTarget.Connect();
            this.TestTarget.Init();

            Assert.AreEqual(this.TestTarget.Port.BytesToRead, 0);
            Assert.AreEqual(this.TestTarget.Port.BytesToWrite, 0);
        }
    }
}