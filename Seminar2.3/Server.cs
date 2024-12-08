using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2._3
{
    internal class Server
    {
        public static void AcceptMessage()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(5051);
            Console.WriteLine("The server waiting for a message");

            while (true)
            {
                byte[] buffer = udpClient.Receive(ref ep); // Получить
                string data = Encoding.UTF8.GetString(buffer);
                Message msg = Message.FromJson(data);
                Console.WriteLine(msg.ToString());

                Thread thread = new Thread(() =>
                {
                    Message msg = Message.FromJson(data);
                    Console.WriteLine(msg.ToString());
                    Message responseMsg = new Message("Server", " Message accept on server");
                    string responseMsgJs = responseMsg.ToJson();
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                    udpClient.Send(responseData, ep);
                    

                } );
                thread.Start();
            }
        }
    }
}
