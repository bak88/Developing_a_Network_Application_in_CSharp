using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Seminar3._3
{
    internal class Message
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Message()
        {
            
        }
        public Message(string nikName, string message)
        {
            this.Name = nikName;
            this.Text = message;
            this.DateTime = DateTime.Now;
        }
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message? FromJson(string message)
        {
            return JsonSerializer.Deserialize<Message>( message);
        }

        public override string ToString()
        {
            return $"Name = {Name}, \nText = {Text}, \nDateTime = {DateTime}";
        }
    }
}
