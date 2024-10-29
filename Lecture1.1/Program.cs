using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lecture1._1_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            //{
            //    var localEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 1488);
            //    //var localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 0);

            //    listener.Blocking = false;

            //    Console.WriteLine($"listener is bound = {listener.IsBound}");

            //    listener.Bind(localEndPoint);

            //    Console.WriteLine($"listener is bound = {listener.IsBound}, port = {(listener.LocalEndPoint as IPEndPoint)?.Port}");

            //    listener.Listen(100);

            //    Console.WriteLine($"Waiting for connection, dual mode = {listener.DualMode}");

            //    while(!listener.Poll(100, SelectMode.SelectRead))
            //    {
            //        Console.Write(".");
            //        Thread.Sleep(500);
            //    }

            //    Socket socket = listener.Accept();

            //    Console.WriteLine("Connected"); 
            //    Console.WriteLine("localEndPoint = " + socket.LocalEndPoint);
            //    Console.WriteLine("remoteEndPoint = " + socket.RemoteEndPoint);

            //    byte[] buffer = new byte[byte.MaxValue];

            //    //while (socket.Available == 0) ;

            //    //Console.WriteLine("Available " + socket.Available + " bytes for read");

            //    socket.ReceiveTimeout = 5000;

            //    Console.WriteLine("We receive a message");

            //    int count = socket.Receive(buffer);

            //    if (count > 0)
            //    {
            //        string message = Encoding.UTF8.GetString(buffer);
            //        Console.WriteLine(message + $" (length {count})");
            //    }
            //    else
            //    {
            //        Console.WriteLine("The message not receive");
            //    }
            //}







            //var listener = new TcpListener(IPAddress.Any, 1488);

            //listener.Start();

            //using (var socket = listener.AcceptSocket())
            //{
            //    listener.Stop();

            //    Console.WriteLine("Connected");
            //    Console.WriteLine("localEndPoint =" + socket.LocalEndPoint);
            //    Console.WriteLine("remoteEndPoint =" + socket.RemoteEndPoint);

            //    byte[] buffer = new byte[255];

            //    Console.WriteLine("We receive a message");

            //    int count = socket.Receive(buffer);

            //    if (count > 0)
            //    {
            //        string message = Encoding.UTF8.GetString(buffer);
            //        Console.WriteLine(message + $" (length {count})");
            //    }
            //    else
            //    {
            //        Console.WriteLine("The message not receive");
            //    }






            //var listener = new TcpListener(IPAddress.Any, 1488);

            //listener.Start();

            //using (var client = listener.AcceptTcpClient())
            //{
            //    listener.Stop();

            //    Console.WriteLine("Connected");
            //    Console.WriteLine("localEndPoint =" + client.Client.LocalEndPoint);
            //    Console.WriteLine("remoteEndPoint =" + client.Client.RemoteEndPoint);

            //    using (var stream = client.GetStream())
            //    {
            //        byte[] buffer = new byte[255];

            //        int count = stream.Read(buffer, 0, buffer.Length);

            //        if (count > 0)
            //        {
            //            string message = Encoding.UTF8.GetString(buffer);
            //            Console.WriteLine(message + $" (length {count})");
            //        }
            //        else
            //        {
            //            Console.WriteLine("The message not receive");
            //        }
            //    }
            //}





            //var listener = new TcpListener(IPAddress.Any, 1488);

            //listener.Start();

            //using(TcpClient client = listener.AcceptTcpClient())
            //{
            //    Console.WriteLine("Connected");

            //    using (var reader = new StreamReader(client.GetStream()))
            //    {
            //        Console.WriteLine(reader.ReadLine());
            //    }
            //}








            var listener = new TcpListener(IPAddress.Any, 1488);

            listener.Start();

            using(TcpClient client= listener.AcceptTcpClient())
            {
                Console.WriteLine("Connected");

                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());

                var s = reader.ReadLine();
                Console.WriteLine(s);

                var r = new String(s.Reverse().ToArray());
                writer.WriteLine(r);

                writer.Flush();
            }






        }
    }
}

