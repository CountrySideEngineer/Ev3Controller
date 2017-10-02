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
    public class NotifyCommandExceptionTests
    {
        [TestMethod()]
        [TestCategory("NotifyCommandException")]
        [TestCategory("NotifyCommandException_Constructor")]
        public void NotifyCommandExceptionTest()
        {
            var CmdExcept = new NotifyCommandException(new CommandException());

            Assert.IsTrue(CmdExcept.Except is CommandException);
        }
    }
}