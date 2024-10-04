using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dz5._1
{
    
    public class MessageUDP
    {
        public Command Command { get; set; } 
        public int? Id { get; set; }   
        public string FromName { get; set; } 
        public string ToName { get; set; } 
        public string Text { get; set; } 
        public List<string> UnreadMessages { get; set; } 
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }       
        public static MessageUDP FromJson(string json)
        {
            return JsonSerializer.Deserialize<MessageUDP>(json)!;
        }
        public MessageUDP()
        {

        }
    }
}
