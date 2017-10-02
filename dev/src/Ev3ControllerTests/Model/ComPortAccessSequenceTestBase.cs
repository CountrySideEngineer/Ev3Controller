using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ev3Controller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ev3ControllerTests.Model.Tests
{
    [TestClass()]
    public class ComPortAccessSequenceTestBase
    {

        public virtual void Init()
        {
            this.IsSequenceStartedEventHandler = false;
            this.IsSequenceStartingEventHandler = false;
            this.IsSequenceFinishedEventHandler = false;
            this.IsSequenceStartingEventHandlerCount = 0;
            this.IsSequenceStartedEventHandlerCount = 0;
            this.IsSequenceFinishedEventHandlerCount = 0;
        }

        [TestInitialize()]
        public virtual void Initialize()
        {
            this.Init();

            this.Runner.SequenceStartingEvent += this.OnSequenceStartingEventHandler;
            this.Runner.SequenceStartedEvent += this.OnSequenceStartedEventHandler;
            this.Runner.SequenceFinishedEvent += this.OnSequenceFinishedEventHandler;
        }

        [TestCleanup()]
        public virtual void Fin()
        {
            this.Runner.SequenceStartingEvent -= this.OnSequenceStartingEventHandler;
            this.Runner.SequenceStartedEvent -= this.OnSequenceStartedEventHandler;
            this.Runner.SequenceFinishedEvent -= this.OnSequenceFinishedEventHandler;
        }

        #region Public Properties
        protected ComPortAccessSequenceRunner _Runner;
        public ComPortAccessSequenceRunner Runner
        {
            get
            {
                if (this._Runner == null)
                {
                    this._Runner =
                        new ComPortAccessSequenceRunner(new ComPort("COM41", "BTDevice"));
                }
                return this._Runner;
            }
        }
        #endregion

        #region Other methods and private properties in calling order
        protected bool IsSequenceStartingEventHandler;
        protected int IsSequenceStartingEventHandlerCount;

        protected bool IsSequenceStartedEventHandler;
        protected int IsSequenceStartedEventHandlerCount;

        protected bool IsSequenceFinishedEventHandler;
        protected int IsSequenceFinishedEventHandlerCount;

        public void OnSequenceStartingEventHandler(object sender, EventArgs e)
        {
            IsSequenceStartingEventHandler = true;
            IsSequenceStartingEventHandlerCount++;
        }
        public void OnSequenceStartedEventHandler(object sender, EventArgs e)
        {
            IsSequenceStartedEventHandler = true;
            IsSequenceStartedEventHandlerCount++;
        }
        public void OnSequenceFinishedEventHandler(object sender, EventArgs e)
        {
            IsSequenceFinishedEventHandler = true;
            IsSequenceFinishedEventHandlerCount++;
        }
        #endregion
    }
}
