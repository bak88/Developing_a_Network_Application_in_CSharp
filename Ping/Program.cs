namespace Lecture1._5_Ping;

using System.Net.NetworkInformation;

internal class Program
{
    static void Main(string[] args)
    {
        var ping = new Ping();

        for (int i = 0; i <= 10; i++)
        {
            PingReply reply = ping.Send("google.com", 1000, new byte[64], new PingOptions { Ttl = 52, DontFragment = true });

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine($"{reply.Buffer.Length} bytes from {reply.Address}: icmp_seq = {i} ttl = {reply?.Options?.Ttl} time = {reply?.RoundtripTime}");
            }
        }
    }
}
