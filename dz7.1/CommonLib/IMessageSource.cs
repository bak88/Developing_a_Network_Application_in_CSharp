using dz7._1.ChatCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz7._1.CommonLib
{
    internal interface IMessageSource
    {
        void Send(MessageUdp message, string clientId);
        MessageUdp Receive(ref string? clientId);
    }
}
