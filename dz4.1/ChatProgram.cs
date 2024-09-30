using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dz4._1
{
    internal class ChatProgram
    {
        private static bool IsReliebleInput(string input)
        {
            return !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);
        }

        private static string GetInput()
        {
            string result = Console.ReadLine();
            while (!IsReliebleInput(result))
            {
                Console.WriteLine("Input is not valid. Try again.");
                result = Console.ReadLine();
            }
            return result;
        }
        public static UdpClient udpClientClient = new();

        public static void ClientReciever(string name, string ip)
        {

            IPEndPoint remoteEndPoint = new(IPAddress.Parse(ip), 12345);

            while (true)
            {
                try
                {

                    // Получение данных из сокета
                    byte[] receiveBytes = udpClientClient.Receive(ref remoteEndPoint);
                    string receivedData = Encoding.UTF8.GetString(receiveBytes);

                    var messageReceived = Message.FromJson(receivedData);
                    PrototypePattern text = new PrototypePattern(messageReceived);
                    var messageWithConstantText = (Message)text.Clone();
                    // Вывод полученного сообщения на консоль
                    Console.WriteLine($"Got message from {messageWithConstantText.FromName} ({messageWithConstantText.dateTime}):");
                    Console.WriteLine(messageWithConstantText.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error receiving message: " + ex.Message);
                }
            }
        }

        // Метод для отправки сообщений серверу
        public static void ClientSender(string name, string ip)
        {
            IPEndPoint remoteEndPoint = new(IPAddress.Parse(ip), 12345);
            while (true)
            {
                try
                {
                    // Ввод сообщения с консоли


                    Console.Write("Enter the username you want to send messages to and press Enter: ");
                    var toName = GetInput();

                    Console.Write("Enter the message you want to send and press Enter: ");
                    var text = GetInput();


                    // Формирование сообщения в формате JSON


                    Message message = new Message() { dateTime = DateTime.Now, FromName = name, ToName = toName, Text = text };
                    PrototypePattern t = new PrototypePattern(message);
                    var messageWithConstantText = (Message)t.Clone();
                    var messageJson = messageWithConstantText.ToJson();

                    // Преобразование сообщения в байтовый массив и отправка его по сокету
                    byte[] replyBytes = Encoding.UTF8.GetBytes(messageJson);
                    udpClientClient.Send(replyBytes, replyBytes.Length, remoteEndPoint);
                    Console.WriteLine("Message sent");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending message: " + ex.Message);
                }
            }
        }
        public static void Server(string userName)
        {
            UdpClient udpClient = new(12345); // Сокет для прослушивания входящих соединений
            IPEndPoint ep = new(IPAddress.Any, 0);


            Console.WriteLine("Server started and waiting for connections...");

            Dictionary<String, IPEndPoint> clients = [];



            while (true)
            {


                var data = udpClient.Receive(ref ep);
                string message = System.Text.Encoding.UTF8.GetString(data); // Преобразование байтового массива в строку
                try
                {
                    Message message1 = Message.FromJson(message);
                    PrototypePattern text = new PrototypePattern(message1);      // Prototype pattern
                    var messageWithConstantText = (Message)text.Clone();


                    Console.WriteLine(messageWithConstantText.ToString());
                    Console.WriteLine(messageWithConstantText.Text);

                    string replyMessage = "";

                    if (messageWithConstantText.ToName.ToLower() == "server")
                    {
                        if (message1.Text.ToLower() == "register")
                        {
                            clients.Add(message1.FromName, new IPEndPoint(ep.Address, ep.Port));
                            replyMessage = "Registered";
                            Console.WriteLine("Client registered: " + message1.FromName);
                        }
                        if (message1.Text.ToLower() == "delete")
                        {
                            clients.Remove(message1.FromName);
                            replyMessage = "Deleted";
                            Console.WriteLine("Client deleted: " + message1.FromName);
                        }
                        if (message1.Text.ToLower() == "list")
                        {
                            replyMessage = String.Join(", ", clients.Keys);
                            Console.WriteLine("Client list: " + replyMessage);
                        }
                        else
                        {
                            replyMessage = "Unknown command";
                        }

                    }
                    else
                    {
                        if (clients.TryGetValue(message1.ToName, out IPEndPoint client))
                        {
                            var forwardMessage = new Message(message1.FromName, message1.ToName, messageWithConstantText.Text).ToJson();
                            byte[] forvardBytes = System.Text.Encoding.UTF8.GetBytes(forwardMessage);
                            udpClient.Send(forvardBytes, forvardBytes.Length, ep);
                            Console.WriteLine("Message forwarded to " + message1.ToName);
                            replyMessage = "sent";

                        }
                        else
                        {
                            replyMessage = "Client not found";
                        }
                    }


                    Message messageToReply = new Message(userName, message1.FromName, replyMessage);
                    PrototypePattern t = new PrototypePattern(messageToReply);   // Prototype pattern
                    var messageWithConstantTextToReply = (Message)t.Clone();

                    var replyMessageJson = messageWithConstantTextToReply.ToJson();

                    var replyBytes = System.Text.Encoding.UTF8.GetBytes(replyMessageJson);
                    udpClient.Send(replyBytes, replyBytes.Length, ep);
                    Console.WriteLine("Answer sent");



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
    }
}
