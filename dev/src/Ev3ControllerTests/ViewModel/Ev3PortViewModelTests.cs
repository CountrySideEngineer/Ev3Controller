using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Model;
using System.Threading;
using Ev3Controller.Ev3Command;

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
            Ev3Brick.ResetInstance();
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
            Assert.IsFalse(this.TestVM.IsConnected);
            Assert.IsTrue(this.TestVM.CanComPortAccessCommand);
        }
        [TestMethod()]
        [TestCategory("ConnectedStateChangedCallback")]
        public void ConnectedStateChangedCallbackTest_002()
        {
            this.TestVM.ConnectedStateChangedCallback(this, new ConnectStateChangedEventArgs(
                new ConnectState(ConnectionState.Disconnecting)));
            Assert.AreEqual(this.TestVM.ConnectState.State, ConnectionState.Disconnecting);
            Assert.IsFalse(this.TestVM.CanChangePort);
            Assert.AreEqual(this.TestVM.ActionName, "切断");
            Assert.AreEqual(this.TestVM.StateLabel, "切断中");
            Assert.IsTrue(this.TestVM.IsConnected);
            Assert.IsFalse(this.TestVM.CanComPortAccessCommand);
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
            Assert.IsFalse(this.TestVM.IsConnected);
            Assert.IsFalse(this.TestVM.CanComPortAccessCommand);
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
            Assert.IsTrue(this.TestVM.IsConnected);
            Assert.IsTrue(this.TestVM.CanComPortAccessCommand);
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
            Assert.IsTrue(this.TestVM.IsConnected);
            Assert.IsTrue(this.TestVM.CanComPortAccessCommand);
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
            Assert.IsTrue(this.TestVM.IsConnected);
            Assert.IsTrue(this.TestVM.CanComPortAccessCommand);
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
            Assert.IsFalse(this.TestVM.IsConnected);
            Assert.IsFalse(this.TestVM.CanComPortAccessCommand);
        }
        #endregion

        #region Unit test of PortConnectExecute method in Ev3PortViewModel class.
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_PortConnectExecute")]
        public void Ev3PortViewModel_PortConnectExecuteTest_001()
        {
            var ViewModel = new Ev3PortViewModel();
            ViewModel.SelectedComPort = ComPortViewModel.Create("COM41", "Device");

            ViewModel.PortConnectExecute();
            Assert.IsFalse(ViewModel.CanChangePort);
            Assert.AreEqual("接続", ViewModel.ActionName);
            Assert.AreEqual("接続中", ViewModel.StateLabel);
            Assert.AreEqual(ConnectionState.Connecting, ViewModel.ConnectState.State);
            Thread.Sleep(4000);
            Assert.IsTrue(ViewModel.CanChangePort);
            Assert.AreEqual("切断", ViewModel.ActionName);
            Assert.AreEqual("接続済み", ViewModel.StateLabel);
            Assert.AreEqual(ConnectionState.Connected, ViewModel.ConnectState.State);

            ViewModel.PortDisconnectExecute();
            Assert.IsFalse(ViewModel.CanChangePort);
            Assert.AreEqual("切断", ViewModel.ActionName);
            Assert.AreEqual("切断中", ViewModel.StateLabel);
            Assert.AreEqual(ConnectionState.Disconnecting, ViewModel.ConnectState.State);
            Thread.Sleep(3000);
            Assert.IsTrue(ViewModel.CanChangePort);
            Assert.AreEqual("接続", ViewModel.ActionName);
            Assert.AreEqual("未接続", ViewModel.StateLabel);
            Assert.AreEqual(ConnectionState.Disconnected, ViewModel.ConnectState.State);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_PortConnectExecute")]
        public void Ev3PortViewModel_PortConnectExecuteTest_002()
        {
            var ViewModel = new Ev3PortViewModel();
            ViewModel.SelectedComPort = ComPortViewModel.Create("COM41", "Device");

            ViewModel.PortConnectExecute();
            Assert.AreEqual(ConnectionState.Connecting, ViewModel.ConnectState.State);
            Thread.Sleep(4000);
            Assert.AreEqual(ConnectionState.Connected, ViewModel.ConnectState.State);

            ViewModel.PortDisconnectExecute();
            Assert.AreEqual(ConnectionState.Disconnecting, ViewModel.ConnectState.State);
            Thread.Sleep(3000);
            Assert.AreEqual(ConnectionState.Disconnected, ViewModel.ConnectState.State);

            Thread.Sleep(1000);
            ViewModel.PortConnectExecute();
            Assert.AreEqual(ConnectionState.Connecting, ViewModel.ConnectState.State);
            Thread.Sleep(4000);
            Assert.AreEqual(ConnectionState.Connected, ViewModel.ConnectState.State);

            ViewModel.PortDisconnectExecute();
            Assert.AreEqual(ConnectionState.Disconnecting, ViewModel.ConnectState.State);
            Thread.Sleep(3000);
            Assert.AreEqual(ConnectionState.Disconnected, ViewModel.ConnectState.State);
        }
        #endregion

        #region Unit test of DataSendAndReceivedFinishedCallback of Ev3PortViewModel.
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_001()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[3];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0xFF;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_002()
        {
            var Command = new Command_02_00();
            Command.ResData = new byte[6];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x02;
            Command.ResData[4] = 0x11;
            Command.ResData[5] = 0x33;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.AreEqual(0x11, Ev3Brick.GetInstance().Version.Major);
            Assert.AreEqual(0x33, Ev3Brick.GetInstance().Version.Minor);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_003()
        {
            var Command = new Command_04_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x11;
            Command.ResData[5] = 0x22;
            Command.ResData[6] = 0x33;
            Command.ResData[7] = 0x44;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.AreEqual(0x2211, Ev3Brick.GetInstance().Battery.Voltage);
            Assert.AreEqual(0x4433, Ev3Brick.GetInstance().Battery.Current);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_004()
        {
            var Command = new Command_06_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x00;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.AreEqual((SafeState.SAFE_STATE)0x00, Ev3Brick.GetInstance().State.State);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_005()
        {
            var Command = new Command_0C_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x03;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.AreEqual((Ev3MotorDevice.DEVICE_TYPE)0x00,
                Ev3Brick.GetInstance().MotorDevice(0).DeviceType);
            Assert.AreEqual((Ev3MotorDevice.DEVICE_TYPE)0x01,
                Ev3Brick.GetInstance().MotorDevice(1).DeviceType);
            Assert.AreEqual((Ev3MotorDevice.DEVICE_TYPE)0x02,
                Ev3Brick.GetInstance().MotorDevice(2).DeviceType);
            Assert.AreEqual((Ev3MotorDevice.DEVICE_TYPE)0x03,
                Ev3Brick.GetInstance().MotorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_006()
        {
            var Command = new Command_0E_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x03;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.AreEqual((Ev3SensorDevice.DEVICE_TYPE)0x00,
                Ev3Brick.GetInstance().SensorDevice(0).DeviceType);
            Assert.AreEqual((Ev3SensorDevice.DEVICE_TYPE)0x01,
                Ev3Brick.GetInstance().SensorDevice(1).DeviceType);
            Assert.AreEqual((Ev3SensorDevice.DEVICE_TYPE)0x02,
                Ev3Brick.GetInstance().SensorDevice(2).DeviceType);
            Assert.AreEqual((Ev3SensorDevice.DEVICE_TYPE)0x03,
                Ev3Brick.GetInstance().SensorDevice(3).DeviceType);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_007()
        {
            var Command = new Command_10_00();
            Command.ResData = new byte[12];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x08;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x10;
            Command.ResData[6] = 0x00;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x00;
            Command.ResData[9] = 0x01;
            Command.ResData[10] = 0x01;
            Command.ResData[11] = 0x20;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsTrue(Ev3Brick.GetInstance().MotorDevice(0).IsConnected);
            Assert.AreEqual(0x10, Ev3Brick.GetInstance().MotorDevice(0).Power);
            Assert.IsFalse(Ev3Brick.GetInstance().MotorDevice(1).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().MotorDevice(2).IsConnected);
            Assert.IsTrue(Ev3Brick.GetInstance().MotorDevice(3).IsConnected);
            Assert.AreEqual(0x20, Ev3Brick.GetInstance().MotorDevice(3).Power);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_008()
        {
            var Command = new Command_20_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x11;
            Command.ResData[7] = 0x02;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(0).IsConnected);
            Assert.IsTrue(Ev3Brick.GetInstance().SensorDevice(1).IsConnected);
            Assert.AreEqual(0x0211, Ev3Brick.GetInstance().SensorDevice(1).Value1);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(2).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_009()
        {
            var Command = new Command_20_01();
            Command.ResData = new byte[7];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x01;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(0).IsConnected);
            Assert.IsTrue(Ev3Brick.GetInstance().SensorDevice(1).IsConnected);
            Assert.AreEqual(0x01, Ev3Brick.GetInstance().SensorDevice(1).Value2);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(2).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_010()
        {
            var Command = new Command_30_00();
            Command.ResData = new byte[7];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x01;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(0).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(1).IsConnected);
            Assert.IsTrue(Ev3Brick.GetInstance().SensorDevice(2).IsConnected);
            Assert.AreEqual(0x01, Ev3Brick.GetInstance().SensorDevice(2).Value1);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_011()
        {
            var Command = new Command_30_01();
            Command.ResData = new byte[7];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x02;
            Command.ResData[6] = 0x43;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(0).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(1).IsConnected);
            Assert.IsTrue(Ev3Brick.GetInstance().SensorDevice(2).IsConnected);
            Assert.AreEqual(0x43, Ev3Brick.GetInstance().SensorDevice(2).Value2);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_012()
        {
            var Command = new Command_40_00();
            Command.ResData = new byte[7];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x03;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x03;
            Command.ResData[6] = 0x01;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(0).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(1).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(2).IsConnected);
            Assert.IsTrue(Ev3Brick.GetInstance().SensorDevice(3).IsConnected);
            Assert.AreEqual(0x01, Ev3Brick.GetInstance().SensorDevice(3).Value1);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_013()
        {
            var Command = new Command_50_00();
            Command.ResData = new byte[8];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x01;
            Command.ResData[7] = 0x02;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsTrue(Ev3Brick.GetInstance().SensorDevice(0).IsConnected);
            Assert.AreEqual(0x0201, Ev3Brick.GetInstance().SensorDevice(0).Value1);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(1).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(2).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_014()
        {
            var Command = new Command_50_01();
            Command.ResData = new byte[8];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x04;
            Command.ResData[4] = 0x01;
            Command.ResData[5] = 0x00;
            Command.ResData[6] = 0x03;
            Command.ResData[7] = 0x04;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.IsTrue(Ev3Brick.GetInstance().SensorDevice(0).IsConnected);
            Assert.AreEqual(0x0403, Ev3Brick.GetInstance().SensorDevice(0).Value2);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(1).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(2).IsConnected);
            Assert.IsFalse(Ev3Brick.GetInstance().SensorDevice(3).IsConnected);
        }
        [TestMethod()]
        [TestCategory("Ev3PortViewModel")]
        [TestCategory("Ev3PortViewModel_DataSendAndReceivedFinishedCallback")]
        public void Ev3PortViewModel_DataSendAndReceivedFinishedCallback_Test_015()
        {
            var Command = new Command_A0_00();
            Command.ResData = new byte[5];
            Command.ResData[0] = Command.Res;
            Command.ResData[1] = Command.SubRes;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x01;
            Command.ResData[4] = 0x03;

            var Args = new NotifySendReceiveDataEventArgs(Command);
            this.TestVM.DataSendAndReceivedFinishedCallback(this, Args);

            Assert.AreEqual((SafeState.SAFE_STATE)0x03, Ev3Brick.GetInstance().State.State);
        }
        #endregion
    }
}