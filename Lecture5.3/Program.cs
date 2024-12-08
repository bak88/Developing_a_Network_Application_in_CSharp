using Lecture5._3.Model;
using Microsoft.EntityFrameworkCore;

namespace Lecture5._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Получение всех сообщений
            

            using (TestContext ctx = new TestContext())
            {
                List<User> users = ctx.Users.ToList();

                foreach (User user in users)
                {
                    Console.WriteLine($"Name {user.Name}");
                    Console.WriteLine("______Message:");

                    ICollection<Message> messages = user.Messages;
                    foreach (var message in messages)
                    {
                        Console.WriteLine($"______:{message.Message1}");
                    }
                }
            }
        }
    }
}
