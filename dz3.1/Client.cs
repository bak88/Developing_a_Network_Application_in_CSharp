using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dz3._1
{
    internal class Client
    {
        public static async Task SendMessage(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5051);
            UdpClient udpClient = new UdpClient();

            string text = Console.ReadLine()!;

            Message msg = new Message(name, text);
            string responseMsgJs = msg.ToJson();
            byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
            await udpClient.SendAsync(responseData, ep);

            byte[] answerData = udpClient.Receive(ref ep);
            string answerMsgJs = Encoding.UTF8.GetString(answerData);
            Message answerMSg = Message.FromJson(answerMsgJs);
            Console.WriteLine(answerMSg.ToString());


        }
    }
}
