using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4._1
{
    internal class PrototypePattern : ICloneable
    {
        public string ConstantText = "With best regards";
        public Message Message { get; set; }

        public PrototypePattern(Message message)
        {

            Message = message;
        }

        public object Clone()
        {
            Message.Text += ConstantText;
            return Message as object;

        }
    }
}
