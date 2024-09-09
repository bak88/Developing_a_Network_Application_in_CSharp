using System.Net.Sockets;
using System.Net;
using System.Text;

namespace dz_1._1
{
    internal class Program
    {
        static void Server(string name)
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("UDP Сервер ожидает сообщений...");

            while (true)
            {
                byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                string receivedData = Encoding.UTF8.GetString(receiveBytes);
                try
                {
                    var message = Message.FromJson(receivedData);

                    Console.WriteLine($"Получено сообщение от {message?.FromName} ({message?.Date}):");
                    Console.WriteLine(message?.Text);

                    Console.Write("Введите ответ и нажмите Enter: ");
                    string? replyMessage = Console.ReadLine();
                    var replyMessageJson = new Message()
                    {
                        FromName = name,
                        Date = DateTime.Now,
                        Text = replyMessage
                    }.ToJson();

                    byte[] replyBytes = Encoding.UTF8.GetBytes(replyMessageJson);
                    udpClient.Send(replyBytes, replyBytes.Length, remoteEndPoint);
                    Console.WriteLine("Ответ отправлен.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при обработке сообщения: " + ex.Message);
                }
            }
        }

        static void Client(string name, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            while (true)
            {
                try
                {
                    Console.WriteLine("UDP Клиент ожидает ввода сообщения");
                    Console.Write("Введите сообщение и нажмите Enter: ");
                    string? message = Console.ReadLine();
                    var messageJson = new Message()
                    {
                        FromName = name,
                        Date = DateTime.Now,
                        Text = message
                    }.ToJson();

                    byte[] replyBytes = Encoding.UTF8.GetBytes(messageJson);
                    udpClient.Send(replyBytes, replyBytes.Length, remoteEndPoint);
                    Console.WriteLine("Сообщение отправлено.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при обработке сообщения: " + ex.Message);
                }

                byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                string receivedData = Encoding.UTF8.GetString(receiveBytes);
                var messageReceived = Message.FromJson(receivedData);

                Console.WriteLine($"Получено сообщение от {messageReceived?.FromName} ({messageReceived?.Date}):");
                Console.WriteLine(messageReceived?.Text);
            }
        }


        static void Main(string[] args)
        {
            var msg = new Message()
            {
                Date = DateTime.Now,
                FromName ="Федор",
                Text = "Привет"
            };
            var str = msg.ToJson();
            Console.WriteLine(str);
            var msgFromJson = Message.FromJson(str);

            if (args.Length == 1)
            {
                Server(args[0]);
            }
            else if (args.Length == 2)
            {
                Client(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("Для запуска Udp-сервера введите ник-нейм как параметр запуска приложения");
                Console.WriteLine("Для запуска Udp-клиента введите ник-нейм и IP сервера как параметры запуска приложения");
            }
        }
    }
}
