using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Model;

namespace Ev3Controller.ViewModel.Tests
{
    [TestClass()]
    public class Ev3PortViewModelTests
    {
        public Ev3PortViewModel TestVM;

        [TestInitialize()]
        public void InitTest()
        {
            this.TestVM = new Ev3PortViewModel();
        }

        [TestMethod()]
        [TestCategory("Constructor")]
        public void Ev3PortViewModelTest_001()
        {
            Ev3PortViewModel PortViewModel = new Ev3PortViewModel();
            Assert.AreEqual(this.TestVM.ActionName, "接続");
            Assert.AreEqual(this.TestVM.StateLabel, "未接続");
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Disconnected);
        }

        #region Unit test of ActionNameTest
        [TestMethod()]
        [TestCategory("ActionNameTest")]
        public void ActionNameTest_001()
        {
            this.TestVM.ActionName = "a";
            Assert.AreEqual(this.TestVM.ActionName, "a");
        }

        [TestMethod()]
        [TestCategory("ActionNameTest")]
        public void ActionNameTest_002()
        {
            this.TestVM.ActionName = "";
            Assert.AreEqual(this.TestVM.ActionName, "");
        }
        #endregion
        #region Unit test of StateLabel.
        [TestMethod()]
        [TestCategory("StateLabel")]
        public void StateLabel_001()
        {
            this.TestVM.StateLabel = "a";
            Assert.AreEqual(this.TestVM.StateLabel, "a");
        }
        [TestMethod()]
        [TestCategory("StateLabel")]
        public void StateLabel_002()
        {
            this.TestVM.StateLabel = "";
            Assert.AreEqual(this.TestVM.StateLabel, "");
        }
        #endregion
        #region Unit test of CanChangePort.
        [TestMethod()]
        [TestCategory("CanChangePort")]
        public void CanChangePort_001()
        {
            this.TestVM.CanChangePort = true;
            Assert.IsTrue(this.TestVM.CanChangePort);
        }
        [TestMethod()]
        [TestCategory("CanChangePort")]
        public void CanChangePort_002()
        {
            this.TestVM.CanChangePort = false;
            Assert.IsFalse(this.TestVM.CanChangePort);
        }
        #endregion
        #region Unit test of ConnectedStateChangedCallbackTest
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_001()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Disconnected)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Disconnected);
            Assert.IsTrue(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "接続");
            Assert.AreEqual(this.TestVM.StateLabel, "未接続");
        }
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_002()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Disconnecting)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Disconnecting);
            Assert.IsFalse(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "接続");
            Assert.AreEqual(this.TestVM.StateLabel, "切断中");
        }
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_003()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Connecting)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Connecting);
            Assert.IsFalse(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "接続");
            Assert.AreEqual(this.TestVM.StateLabel, "接続中");
        }
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_004()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Connected)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Connected);
            Assert.IsTrue(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "切断");
            Assert.AreEqual(this.TestVM.StateLabel, "接続済み");
        }
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_005()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Sending)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Sending);
            Assert.IsFalse(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "切断");
            Assert.AreEqual(this.TestVM.StateLabel, "送信中");
        }
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_006()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Receiving)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Receiving);
            Assert.IsFalse(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "切断");
            Assert.AreEqual(this.TestVM.StateLabel, "受信中");
        }
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_007()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Unknown)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Unknown);
            Assert.IsTrue(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "不明");
            Assert.AreEqual(this.TestVM.StateLabel, "不明");
        }
        #endregion
    }
}