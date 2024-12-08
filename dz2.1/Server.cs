using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace dz2._1
{
    internal class Server
    {
        public static void AcceptMessage()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpServer = new UdpClient(5051);
            bool running = true;
            Console.WriteLine("The server waiting for a message");

            while (running)
            {
                byte[] buffer = udpServer.Receive(ref ep); // Получить
                string data = Encoding.UTF8.GetString(buffer);

                Message? msg = Message.FromJson(data);
                if (msg.Text.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exit");
                    running = false;
                    continue;
                }

                Thread thread = new Thread(() =>
                {
                    Console.WriteLine(msg.ToString());
                    Message responseMsg = new Message("Server", " Message accept on server");
                    string responseMsgJs = responseMsg.ToJson();
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                    udpServer.Send(responseData, ep);
                });
                thread.Start();
            }
            udpServer.Close();
        }
    }
}
