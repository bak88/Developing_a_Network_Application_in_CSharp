﻿using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lecture1._4_UdpClient
{
    internal class Program
    {
        private static IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

        static void UdpReceiver()
        {
            using (var client = new UdpClient(1234))
            {
                var lp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

                int lastPacketNum = -1;

                while (lastPacketNum < 255)
                {
                    var recv = client.Receive(ref lp);

                    var curPacketNum = recv[0];

                    if (curPacketNum > lastPacketNum)
                    {
                        lastPacketNum = curPacketNum;

                        var bs = new byte[recv.Length - 1];

                        Array.Copy(recv, 1, bs, 0, recv.Length - 1);

                        var s = Encoding.ASCII.GetString(bs);

                        Console.WriteLine(s);
                    }
                    else
                    {
                        Console.WriteLine("Packet dropped");
                    }
                }

                Console.WriteLine("End");
            }
        }

        static void UdpSender()
        {
            using (var client = new UdpClient())
            {
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));

                for (int i = 0; i < 256; i++)
                {
                    var data = $"Line#{i}";

                    var bdata = Encoding.ASCII.GetBytes(data);

                    var packet = new byte[bdata.Length + 1];

                    packet[0] = (byte)i;

                    Array.Copy(bdata, 0, packet, 1, bdata.Length);

                    client.Send(packet);
                }
            }
        }


        static void Main(string[] args)
        {
            new Thread(() => UdpReceiver()).Start();

            new Thread(() => UdpSender()).Start();
        }
    }
}
