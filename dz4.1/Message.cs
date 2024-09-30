using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace dz4._1
{
    internal class Message
    {
        [JsonIgnore]
        public static Dictionary<string, IPEndPoint> Clients { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Text { get; set; }

        public DateTime dateTime { get; set; }

        public Message() { }

        public Message(string userName, string toUserName, string text)
        {
            FromName = userName;
            ToName = toUserName;
            Text = text;
        }
        public string ToJson()
        {
            try
            {
                return JsonSerializer.Serialize(this);
            }
            catch
            {

                Console.WriteLine("Can't parse JSON");
                return String.Empty;
            }
        }
        public static Message FromJson(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<Message>(json);
            }
            catch
            {
                Console.WriteLine("Can't parse from JSON");
                return new Message();
            }
        }
        public override string ToString()
        {
            return $"From:{FromName} - To:{ToName} - ({dateTime}): {Text}";
        }
    }
}
