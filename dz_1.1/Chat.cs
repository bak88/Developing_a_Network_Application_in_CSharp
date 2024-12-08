using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Seminar1._1
{
    internal class Chat
    {     
        public static void Server()
        {
            IPEndPoint endPoint = new(IPAddress.Any, 0);
            UdpClient ucl = new UdpClient(12345);
            Console.WriteLine("Сервер ожидает сообщения от клиента");

            while (true)
            {
                try
                {
                    byte[] buffer = ucl.Receive(ref endPoint);
                    string str = Encoding.UTF8.GetString(buffer);

                    Message? message = Message.FromJson(str);

                    if (message != null )
                    {
                        Console.WriteLine(message.ToString());

                        Message newMes = new Message("server", "The message receive");
                        var toJson = newMes.ToJson();
                        byte[] bytes = Encoding.UTF8.GetBytes(toJson);
                        ucl.Send(bytes, endPoint);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void Client(string nkiName)
        {
            var localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            var ucl = new UdpClient();
            
            while (true)
            {
                Console.WriteLine("Введите сообщение");
                string text = Console.ReadLine()!;

                if(String.IsNullOrEmpty(text))
                    break;

                Message message = new Message(nkiName, text);
                var toJson = message.ToJson();
                byte[] bytes = Encoding.UTF8.GetBytes(toJson);
                ucl.Send(bytes, localEP);

                byte[] buffer = ucl.Receive(ref localEP);
                string str = Encoding.UTF8.GetString(buffer);
                Message? fromJson = Message.FromJson(str);
                Console.WriteLine(fromJson);
            }
        }


    }
}
