using System.Net.Sockets;
using System.Net;

namespace Lecture1._3_Server_Udp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

                socket.Bind(localEndPoint);

                byte[] buffer = new byte[1];

                int count = 0;

                while (count < 200)
                {
                    int c = socket.Receive(buffer);

                    if (c == 1)
                        Console.Write(buffer[0]);
                    count += c;
                }
                Console.WriteLine("\nReading 200 byte");
            }
        }
    }
}
