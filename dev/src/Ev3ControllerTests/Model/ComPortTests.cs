using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Ev3Controller.Model.Tests
{
    [TestClass()]
    public class ComPortTests
    {
        public ComPort ComPortTest;

        [TestInitialize]
        public void InitTest()
        {
            this.ComPortTest = new ComPort("", "");
        }

        #region Unit test of constructor.
        [TestMethod()]
        [TestCategory("Constructor")]
        public void ComPortTest_001()
        {
            Assert.AreEqual(this.ComPortTest.Name, "");
            Assert.AreEqual(this.ComPortTest.Device, "");
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate9600);
            Assert.AreEqual(this.ComPortTest.Parity, Parity.None);
            Assert.AreEqual(this.ComPortTest.StopBits, StopBits.One);
            Assert.AreEqual(this.ComPortTest.DataBit, 8);
        }
        [TestMethod()]
        [TestCategory("Constructor")]
        public void ComPortTest_002()
        {
            this.ComPortTest = new ComPort("Name", "Device");
            Assert.AreEqual(this.ComPortTest.Name, "Name");
            Assert.AreEqual(this.ComPortTest.Device, "Device");
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate9600);
            Assert.AreEqual(this.ComPortTest.Parity, Parity.None);
            Assert.AreEqual(this.ComPortTest.StopBits, StopBits.One);
            Assert.AreEqual(this.ComPortTest.DataBit, 8);
        }
        #endregion

        #region Unit test of Baudrate
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_001()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate110;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate110);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 110);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_002()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate300;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate300);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 300);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_003()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate600;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate600);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 600);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_004()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate1200;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate1200);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 1200);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_005()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate2400;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate2400);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 2400);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_006()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate4800;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate4800);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 4800);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_007()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate9600;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate9600);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 9600);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_008()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate14400;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate14400);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 14400);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_009()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate19200;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate19200);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 19200);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_010()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate38400;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate38400);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 38400);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_011()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate57600;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate57600);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 57600);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_012()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate115200;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate115200);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 115200);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_013()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate230400;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate230400);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 230400);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_014()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate230400;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate230400);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 230400);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_015()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate460600;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate460600);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 460600);
        }
        [TestMethod()]
        [TestCategory("Baudrate")]
        public void BaudrateTest_016()
        {
            this.ComPortTest.Baudrate = Baudrate.Baudrate921600;
            Assert.AreEqual(this.ComPortTest.Baudrate, Baudrate.Baudrate921600);
            Assert.AreEqual(this.ComPortTest.BaudrateValue, 921600);
        }
        #endregion
    }
}