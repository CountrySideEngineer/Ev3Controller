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
    public class NotifySendReceiveDataEventArgsTests
    {
        [TestMethod()]
        [TestCategory("NotifySendReceiveDataEventArgs")]
        [TestCategory("NotifySendReceiveDataEventArgs_Constructor")]
        public void NotifySendReceiveDataEventArgsTest()
        {
            byte[] SendData = new byte[1];
            byte[] RecvData = new byte[1];

            SendData[0] = 0x01;
            RecvData[0] = 0x02;

            var EventArg = new NotifySendReceiveDataEventArgs(SendData, RecvData);
            Assert.IsNotNull(EventArg.SendData);
            Assert.IsNotNull(EventArg.RecvData);
            Assert.AreEqual(EventArg.SendData.Length, 1);
            Assert.AreEqual(EventArg.RecvData.Length, 1);
            Assert.AreEqual(EventArg.SendData[0], 1);
            Assert.AreEqual(EventArg.RecvData[0], 2);
        }
    }
}