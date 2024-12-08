using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lecture1._1_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            //{
            //    var remoteEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 1488);
            //    //var localEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 8841);
            //    var localEndPoint = new IPEndPoint(IPAddress.Any, 8841);
            //    Console.WriteLine("Connecting...");

            //    try
            //    {
            //        client.Bind(localEndPoint);
            //        client.Connect(remoteEndPoint);
            //    }
            //    catch
            //    {

            //    }

            //    if (client.Connected)
            //    {
            //        Console.WriteLine("Connected");
            //        Console.WriteLine("localEndPoint =" + client.LocalEndPoint);
            //        Console.WriteLine("remoteEndPoint =" + client.RemoteEndPoint);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Connection problem");
            //        return;
            //    }

            //    byte[] messageBytes = Encoding.UTF8.GetBytes("Hello Im is client ");

            //    client.SendTimeout = 5000;

            //    if (client.Poll(100, SelectMode.SelectWrite) && !client.Poll(100, SelectMode.SelectError))
            //    {
            //        int count = client.Send(messageBytes);

            //        if (count == messageBytes.Length)
            //            Console.WriteLine("The Message sending " + $"({messageBytes.Length} bytes)");
            //        else
            //            Console.WriteLine("Error");
            //    }

            //}







            //using (TcpClient client = new TcpClient())
            //{
            //    Console.WriteLine("Connecting...");

            //    try
            //    {
            //        client.Connect(IPAddress.Parse("127.0.0.1"), 1488);
            //    }
            //    catch
            //    {

            //    }

            //    if (client.Connected)
            //    {
            //        Console.WriteLine("Connected");                    
            //    }
            //    else
            //    {
            //        Console.WriteLine("Connection problem");
            //        return;
            //    }

            //    using(var stream = client.GetStream())
            //    {
            //        byte[] messageBytes = Encoding.UTF8.GetBytes("Hello Im is client ");

            //        try
            //        {
            //            stream.Write(messageBytes);
            //            Console.WriteLine("The Message sending ");
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine("Error");
            //        }
            //    }
            //}




            //using (TcpClient client = new TcpClient())
            //{
            //    Console.WriteLine("Connecting...");

            //    client.Connect(IPAddress.Parse("127.0.0.1"), 1488);

            //    using (var write = new StreamWriter(client.GetStream()))
            //    {
            //        write.WriteLine("Hello");
            //    }
            //}





            using (TcpClient client = new TcpClient())
            {
                Console.WriteLine("Connecting...");

                client.Connect(IPAddress.Parse("127.0.0.1"), 1488);

                Console.WriteLine("Connected");

                var writer = new StreamWriter(client.GetStream());
                var reader = new StreamReader(client.GetStream());

                writer.WriteLine("Hello");
                writer.Flush();

                var s = reader.ReadLine();
                Console.WriteLine(s);
            }







        }
    }
}
