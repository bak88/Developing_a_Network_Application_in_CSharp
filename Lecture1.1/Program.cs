using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lecture1._1_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                //var localEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 1488);
                var localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 0);
                
                listener.Blocking = false;

                Console.WriteLine($"listener is bound = {listener.IsBound}");

                listener.Bind(localEndPoint);

                Console.WriteLine($"listener is bound = {listener.IsBound}, port = {(listener.LocalEndPoint as IPEndPoint)?.Port}");

                listener.Listen(100);
               
                Console.WriteLine($"Waiting for connection, dual mode = {listener.DualMode}");
                
                var task = listener.AcceptAsync();

                while(!task.IsCompleted)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }

                Socket socket = task.Result;

                Console.WriteLine("Connected"); 
                Console.WriteLine("localEndPoint = " + socket.LocalEndPoint);
                Console.WriteLine("remoteEndPoint = " + socket.RemoteEndPoint);

                byte[] buffer = new byte[byte.MaxValue];

                //while (socket.Available == 0) ;

                //Console.WriteLine("Available " + socket.Available + " bytes for read");

                socket.ReceiveTimeout = 5000;

                Console.WriteLine("We receive a message");

                int count = socket.Receive(buffer);

                if (count > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(message + $" (length {count})");
                }
                else
                {
                    Console.WriteLine("The message not receive");
                }
            }
        }
    }
}
