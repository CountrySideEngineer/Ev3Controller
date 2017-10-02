using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Ev3Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev3Controller.Ev3Command.Tests
{
    [TestClass()]
    public class CommandExceptionTests
    {
        [TestMethod()]
        [TestCategory("CommandException")]
        [TestCategory("CommandException_Constructor")]
        public void CommandExceptionTest_001()
        {
            var Except = new CommandException("Message", 0x00, 0x01, "Name");

            Assert.AreEqual(Except.Message, "Message");
            Assert.AreEqual(Except.Cmd, 0x00);
            Assert.AreEqual(Except.SubCmd, 0x01);
            Assert.AreEqual(Except.Name, "Name");
        }
    }
}