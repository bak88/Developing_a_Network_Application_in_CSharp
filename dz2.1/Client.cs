using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dz2._1
{
    internal class Client
    {
        public static void SendMessage(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5051);
            UdpClient udpClient = new UdpClient();

            while (true)
            {
                string text = Console.ReadLine()!;
                if (text.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Message msg = new Message(name, text);
                string responseMsgJs = msg.ToJson();
                byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                udpClient.SendAsync(responseData, ep);

                byte[] answerData = udpClient.Receive(ref ep);
                string answerMsgJs = Encoding.UTF8.GetString(answerData);
                Message answerMSg = Message.FromJson(answerMsgJs);
                Console.WriteLine(answerMSg.ToString());
            }
        }
    }
}
