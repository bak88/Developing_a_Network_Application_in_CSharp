using dz5._1.Model;
using System;
using dz5._1;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace dz5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static async Task Main(string[] args) //было без  async Task - void
            {
                if (args.Length == 0)
                {
                    var s = new Server();
                    s.Work();
                    //тестовые данные 
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
                //Тестовое сообщение для регистрации
                var registerMessage = new MessageUDP
                {
                    Command = Command.Register,
                    FromName = "User1"
                };
                //Отправляем тестовое сообщение на сервер для регистрации
                s.ProcessMessage(registerMessage, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));
                Console.WriteLine("Отправляем тестовое сообщение на сервер для регистрации");
            }
            static void TestConfirmationMessage(Server s)
            {
                //Тестовое сообщение подтверждения
                var confirmationMessage = new MessageUDP
                {
                    Command = Command.Confirmation,
                    Id = 1 //идентификатор 1-го сообщения который нужо подтвердить
                };
                //отправляем тестовое сообщение на сервер для подтверждения
                s.ProcessMessage(confirmationMessage, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));
            }
            static void TestRelayMessage(Server s)
            {
                //тестовое сообщение для пересылки
                var relayMessage = new MessageUDP
                {
                    Command = Command.Message,
                    FromName = "User1",
                    ToName = "User2",
                    Text = "Пробное сообщение 1."
                };
                //Отправляем тестовое сообщение на сревер для пересылки
                s.ProcessMessage(relayMessage, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));

            }
            static void TestGetUnreadMessages(Server s)
            {
                //Тестовое сообщение для получения непрочитанных сообщений
                var getUnreadMessages = new MessageUDP
                {
                    Command = Command.GetUnreadMessages,
                    FromName = "User2"
                };
                //Отправляем тестовое сообщение для получения непрочитанных сообщений
                s.ProcessMessage(getUnreadMessages, new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5430));
            }
        }
    }
}
