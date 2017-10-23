using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ev3Controller.Ev3Command;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class NotifySendReceiveDataEventArgsTests
    {
        #region Unit test of NotifySendReceiveDataEventArgs, and its SendData and RecvData Getter.
        [TestMethod()]
        [TestCategory("NotifySendReceiveDataEventArgs")]
        [TestCategory("NotifySendReceiveDataEventArgs_Constructor")]
        public void NotifySendReceiveDataEventArgs_Constructor_Test_001()
        {
            byte[] SendData = new byte[1];
            byte[] RecvData = new byte[1];

            SendData[0] = 0x01;
            RecvData[0] = 0x02;

            var EventArg = new NotifySendReceiveDataEventArgs(SendData, RecvData);
            Assert.IsNull(EventArg.Command);
            Assert.IsNotNull(EventArg.SendData);
            Assert.IsNotNull(EventArg.RecvData);
            Assert.AreEqual(EventArg.SendData.Length, 1);
            Assert.AreEqual(EventArg.RecvData.Length, 1);
            Assert.AreEqual(EventArg.SendData[0], 1);
            Assert.AreEqual(EventArg.RecvData[0], 2);
        }
        [TestMethod()]
        [TestCategory("NotifySendReceiveDataEventArgs")]
        [TestCategory("NotifySendReceiveDataEventArgs_Constructor")]
        public void NotifySendReceiveDataEventArgs_Constructor_Test_002()
        {
            var Command = new Command_00_00();
            Command.ResData = new byte[10];
            Command.ResData[0] = 0x01;
            Command.ResData[1] = 0x00;
            Command.ResData[2] = 0x00;
            Command.ResData[3] = 0x06;
            Command.ResData[4] = 0x00;
            Command.ResData[5] = 0x01;
            Command.ResData[6] = 0x02;
            Command.ResData[7] = 0x03;
            Command.ResData[8] = 0x04;
            Command.ResData[9] = 0x05;

            var EventArg = new NotifySendReceiveDataEventArgs(Command);
            Assert.IsNotNull(EventArg.SendData);
            Assert.IsNotNull(EventArg.RecvData);
            Assert.IsNotNull(EventArg.Command);
            Assert.AreEqual(EventArg.SendData.Length, 32);
            Assert.AreEqual(EventArg.RecvData.Length, 10);
            Assert.AreEqual(EventArg.SendData[0], 0x00);
            Assert.AreEqual(EventArg.SendData[1], 0x00);
            Assert.AreEqual(EventArg.SendData[2], 0x06);
            Assert.AreEqual(EventArg.SendData[3], 0x00);
            Assert.AreEqual(EventArg.SendData[4], 0x01);
            Assert.AreEqual(EventArg.SendData[5], 0x02);
            Assert.AreEqual(EventArg.SendData[6], 0x03);
            Assert.AreEqual(EventArg.SendData[7], 0x04);
            Assert.AreEqual(EventArg.SendData[8], 0x05);

            Assert.AreEqual(EventArg.RecvData[0], 0x01);
            Assert.AreEqual(EventArg.RecvData[1], 0x00);
            Assert.AreEqual(EventArg.RecvData[2], 0x00);
            Assert.AreEqual(EventArg.RecvData[3], 0x06);
            Assert.AreEqual(EventArg.RecvData[4], 0x00);
            Assert.AreEqual(EventArg.RecvData[5], 0x01);
            Assert.AreEqual(EventArg.RecvData[6], 0x02);
            Assert.AreEqual(EventArg.RecvData[7], 0x03);
            Assert.AreEqual(EventArg.RecvData[8], 0x04);
            Assert.AreEqual(EventArg.RecvData[9], 0x05);
        }
        #endregion
    }
}