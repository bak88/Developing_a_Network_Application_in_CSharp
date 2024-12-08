
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Seminar5._1.Udp
{
    public enum Command
    {
        Register,
        Message,
        Confirmator
    }
    public class MessageUdp
    {
        public Command Command { get; set; }
        public int? Id { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Text { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static MessageUdp? FromJson(string message)
        {
            return JsonSerializer.Deserialize<MessageUdp>(message);
        }
    }
}
