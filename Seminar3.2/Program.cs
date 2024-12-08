using System.Net;
using System.Net.NetworkInformation;

namespace Seminar3._2
{
    //Напишите многопоточное приложение, которое определяет все IP-адреса
    //интернет-ресурса и определяет до которого из них лучше Ping.Приложение
    //должно работать с помощью Task.

    
    internal class Program
    {
        static async Task<long> GetPing(IPAddress iPAddress)
        {
            Ping ping = new Ping();
            PingReply pingReply= await ping.SendPingAsync(iPAddress);
            return pingReply.RoundtripTime;
        }
        static async Task Main(string[] args)
        {
            string url = "yandex.ru";

            IPAddress[] addresses = await Dns.GetHostAddressesAsync(url);

            foreach (var item in addresses)
            {
                await Console.Out.WriteLineAsync(item.ToString());
            }

            var pings = new Dictionary<IPAddress, long>();

            foreach (var item in addresses)
            {
                var value = await GetPing(item);
                pings[item] = value;

            }

            foreach (KeyValuePair<IPAddress, long> pair in pings)
            {
                Console.WriteLine(pair);
            }

        }
    }
}
