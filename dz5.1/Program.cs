using dz5._1.Models;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace dz5._1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                var s = new Server();
                s.Work();                 
                TestRegisterMessage(s);
                TestConfirmationMessage(s);
                TestRelayMessage(s);
                TestGetUnreadMessages(s);
                Console.WriteLine("Запущен сервер!");
            }
            else
            {
                await Client.SendMsg(args[0]);
            }
        }
        static void TestRegisterMessage(Server s)
        {            
            var registerMessage = new MessageUDP
            {
                Command = Command.Register,
                FromName = "User1"
            };            
            s.ProcessMessage(registerMessage, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));
            Console.WriteLine("Отправляем тестовое сообщение на сервер для регистрации");
        }
        static void TestConfirmationMessage(Server s)
        {            
            var confirmationMessage = new MessageUDP
            {
                Command = Command.Confirmation,
                Id = 1
            };            
            s.ProcessMessage(confirmationMessage, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));
        }
        static void TestRelayMessage(Server s)
        {            
            var relayMessage = new MessageUDP
            {
                Command = Command.Message,
                FromName = "User1",
                ToName = "User2",
                Text = "Пробное сообщение 1."
            };            
            s.ProcessMessage(relayMessage, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));

        }
        static void TestGetUnreadMessages(Server s)
        {            
            var getUnreadMessages = new MessageUDP
            {
                Command = Command.GetUnreadMessages,
                FromName = "User2"
            };            
            s.ProcessMessage(getUnreadMessages, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));
        }
    }
}