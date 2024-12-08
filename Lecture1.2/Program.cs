using System.Net;
using System.Net.Sockets;

namespace Lecture1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var addresses = Dns.GetHostAddresses("google.com");

            //Console.WriteLine("IP address");

            //foreach ( var address in addresses)
            //{
            //    Console.WriteLine(address.ToString());
            //}

            //var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //s.Connect(addresses, 80);

            //Console.WriteLine("Connect with IP-address");
            //Console.WriteLine((s.RemoteEndPoint as IPEndPoint)?.Address);






            //var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //s.Connect("google.com", 80);

            //Console.WriteLine((s.RemoteEndPoint as IPEndPoint)?.Address);





            var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Connect("77.88.44.88", 80);

            Console.WriteLine("Соединение установлено: ");
            Console.WriteLine((s.RemoteEndPoint as IPEndPoint)?.Address);

            s.Disconnect(true);

            Task task = s.ConnectAsync("google.com", 80);

            task.Wait();

            Console.WriteLine("Соединение установлено: ");
            Console.WriteLine((s.RemoteEndPoint as IPEndPoint)?.Address);


        }
    }
}
