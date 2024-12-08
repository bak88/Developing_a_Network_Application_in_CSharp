using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dz4._1
{
    internal class ChatServer
    {
        private Queue<ICommand> _commandQueue = new Queue<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commandQueue.Enqueue(command);
        }

        public void ProcessCommands()
        {
            while (_commandQueue.Count > 0)
            {
                var command = _commandQueue.Dequeue();
                command.Execute();
            }
        }
    }
}
