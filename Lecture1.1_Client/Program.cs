using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lecture1._1_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var remoteEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 1488);
                //var localEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 8841);
                var localEndPoint = new IPEndPoint(IPAddress.Any, 8841);
                Console.WriteLine("Connecting...");
                
                try
                {
                    client.Bind(localEndPoint);
                    client.Connect(remoteEndPoint);
                }
                catch
                {

                }

                if (client.Connected)
                {
                    Console.WriteLine("Connected");
                    Console.WriteLine("localEndPoint =" + client.LocalEndPoint);
                    Console.WriteLine("remoteEndPoint =" + client.RemoteEndPoint);
                }
                else
                {
                    Console.WriteLine("Connection problem");
                    return;
                }

                byte[] messageBytes = Encoding.UTF8.GetBytes("Hello Im is client ");

                //Console.WriteLine("For sending message click \"Enter\"");
                //Console.ReadLine();
                
                int count = client.Send(messageBytes);
                
                if (count == messageBytes.Length) 
                    Console.WriteLine("The Message sending " + $"({messageBytes.Length} bytes)");
                else 
                    Console.WriteLine("Error");
            }
        }
    }
}
