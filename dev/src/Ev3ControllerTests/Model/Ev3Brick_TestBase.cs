using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;

namespace Ev3Controller.Model.Tests
{
    [TestClass]
    public class Ev3Brick_TestBase
    {
        [TestMethod]
        [TestInitialize]
        public virtual void Init()
        {
            Ev3Brick.ResetInstance();
        }
    }
}
