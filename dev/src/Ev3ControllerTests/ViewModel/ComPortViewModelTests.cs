using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.ViewModel.Tests
{
    using Ev3Controller.Model;
    [TestClass()]
    public class ComPortViewModelTests
    {
        public ComPortViewModel ViewModel;
        #region Initialize test
        [TestInitialize()]
        public void InitTest()
        {
            this.ViewModel = new ComPortViewModel(new ComPort("Name", "Device"));
        }
        #endregion

        #region Unit test Of Constructor.
        [TestMethod()]
        [TestCategory("ComPortViewModel_Constructor")]
        public void ComPortViewModelTest_001()
        {
            ComPort Port = new ComPort("Name", "Device");
            Assert.IsTrue(this.ViewModel.ComPort.Equals(Port));
            Assert.AreEqual(this.ViewModel.PortName, "Name");
        }
        #endregion

        #region Unit test of Create, static method.
        [TestMethod()]
        [TestCategory("ComPortViewModel_Create(string name, string device)")]
        public void CreateTest_001()
        {
            ComPortViewModel VM = ComPortViewModel.Create("Name", "Device");
            ComPort Port = new ComPort("Name", "Device");
            Assert.IsTrue(VM.ComPort.Equals(Port));
            Assert.AreEqual(VM.PortName, "Name");
        }
        #endregion

        #region Unit test of Equals method.
        [TestMethod()]
        [TestCategory("ComPortViewModel_Equals")]
        public void EqualsTest_001()
        {
            Assert.IsTrue(this.ViewModel.Equals(
                new ComPortViewModel(new ComPort("Name", "Device"))));
        }
        [TestMethod()]
        [TestCategory("ComPortViewModel_Equals")]
        public void EqualsTest_002()
        {
            Assert.IsFalse(this.ViewModel.Equals(
                new ComPortViewModel(new ComPort("_Name", "Device"))));
        }
        [TestMethod()]
        [TestCategory("ComPortViewModel_Equals")]
        public void EqualsTest_003()
        {
            Assert.IsFalse(this.ViewModel.Equals(
                new ComPortViewModel(new ComPort("Name", "_Device"))));
        }
        [TestMethod()]
        [TestCategory("ComPortViewModel_Equals")]
        public void EqualsTest_004()
        {
            Assert.IsFalse(this.ViewModel.Equals(
                new ComPortViewModel(new ComPort("_Name", "_Device"))));
        }
        [TestMethod()]
        [TestCategory("ComPortViewModel_Equals")]
        public void EqualsTest_005()
        {
            Assert.IsFalse(this.ViewModel.Equals(null));
        }
        #endregion
    }
}