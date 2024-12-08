using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dz3._1
{
    internal class Server
    {
        public static async Task AcceptMessage()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(5051);
            Console.WriteLine("The server waiting for a message");

            while (!ct.IsCancellationRequested)
            {
                byte[] buffer = udpClient.Receive(ref ep); // Получить                
                string data = Encoding.UTF8.GetString(buffer);
                Message msg = Message.FromJson(data);

                await Task.Run(async () =>
                {
                    Message msg = Message.FromJson(data);
                    Console.WriteLine(msg.ToString());
                    Message responseMsg = new Message("Server", " Message accept on server");
                    string responseMsgJs = responseMsg.ToJson();
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                    await udpClient.SendAsync(responseData, ep);

                }, ct);
                cts.Cancel();
                Console.WriteLine();
            }
            Console.WriteLine("Server stopped");
        }
    }
}
