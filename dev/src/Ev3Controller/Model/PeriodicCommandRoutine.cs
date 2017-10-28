using Ev3Controller.Ev3Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ev3Controller.Model
{
    public class PeriodicCommandRoutine : CommandRoutine
    {
        /// <summary>
        /// Constructor.
        /// Setup command to send in the routine.
        /// </summary>
        public PeriodicCommandRoutine()
        {
            this.CommandQueue = new Queue<ACommand>();
            this.CommandQueue.Enqueue(new Command_20_00());
            this.CommandQueue.Enqueue(new Command_20_01());
            this.CommandQueue.Enqueue(new Command_30_00());
            this.CommandQueue.Enqueue(new Command_30_01());
            this.CommandQueue.Enqueue(new Command_40_00());
            this.CommandQueue.Enqueue(new Command_50_00());
            this.CommandQueue.Enqueue(new Command_50_01());
        }

        /// <summary>
        /// Method to run periodic command routine.
        /// </summary>
        /// <param name="ComPortAcc">ComPortAccess class contains COM port abstract object.</param>
        /// <param name="Sequence">Sequence class to run routine.</param>
        /// <param name="TimerCount">Passed time.</param>
        /// <returns></returns>
        public override bool Routine(
            ComPortAccess ComPortAcc,
            ComPortSendRecvSequence Sequence,
            int TimerCount = 0)
        {
            foreach (ACommand Command in this.CommandQueue)
            {
                Thread.Sleep(1);
                Sequence.SendAndRecvRoutine(ComPortAcc, Command);
            }

            return false;
        }

        public Queue<ACommand> CommandQueue { get; protected set; }
    }
}
