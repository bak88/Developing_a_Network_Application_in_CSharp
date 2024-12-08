using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Seminar2._2
{
    internal class Program
    {
        //Напишите многопоточное приложение, которое определяет все IP-адреса
        //интернет-ресурса и определяет до которого из них лучше Ping.

        static void Main(string[] args)
        {
            string recourses = "Yandex.ru";
            IPAddress[] IpAddresses = Dns.GetHostAddresses(recourses, AddressFamily.InterNetwork);

            foreach (IPAddress ip in IpAddresses)
            {
                Console.WriteLine(ip);
            }

            var pings = new Dictionary<IPAddress, long>();
            var listThreads = new List<Thread>();

            foreach (var ip in IpAddresses)
            {
                Thread thread = new Thread(() =>
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(ip);

                    pings.Add(ip, pingReply.RoundtripTime);
                });

                listThreads.Add(thread);
                thread.Start();
            }

            foreach( Thread threads in listThreads )
            {
                threads.Join();
            }

            long min = int.MaxValue;
            foreach( var ping  in pings)
            {
                if (ping.Value < min) min = ping.Value;
                Console.WriteLine($"IP: {ping.Key}, Ping: {ping.Value}");
            }
            Console.WriteLine($"Min ping: {min}");


        }
    }
}
