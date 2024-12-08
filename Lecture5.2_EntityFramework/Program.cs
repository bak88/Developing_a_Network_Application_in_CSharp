using Lecture5._2_EntityFramework.Db.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Lecture5._2_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //// Получение всех сообщений
            //var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>()
            //                     .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Test")
            //                     .UseLazyLoadingProxies();

            //using (TestDbContext ctx = new TestDbContext(optionsBuilder.Options))
            //{
            //    List<User> users = ctx.Users.ToList();

            //    foreach (User user in users)
            //    {
            //        Console.WriteLine($"Name {user.Name}");
            //        Console.WriteLine("______Message:");

            //        ICollection<Message> messages = user.Messages;
            //        foreach (var message in messages)
            //        {
            //            Console.WriteLine($"______:{message.MessageContent}");
            //        }
            //    }
            //}



            //// Добавление пользователя
            //var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>()
            //                     .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Test")
            //                     .UseLazyLoadingProxies();

            //using (TestDbContext ctx = new TestDbContext(optionsBuilder.Options))
            //{
            //    User user = new User()
            //    {
            //        Name = "Jim",
            //        Messages = new HashSet<Message>()
            //    };

            //    user.Messages.Add(new Message() { MessageContent = "Hello" });
            //    user.Messages.Add(new Message() { MessageContent = "I'm Jim" });

            //    ctx.Add(user);
            //    int changes = ctx.SaveChanges();

            //    Console.WriteLine($"Count = {changes}");
            //}




            // Изминение Имени
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>()
                                 .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Test")
                                 .UseLazyLoadingProxies();

            using (TestDbContext context = new TestDbContext(optionsBuilder.Options))
            {
                User? user = context.Users.FirstOrDefault(x => x.Name == "Jim");

                if (user != null)
                {
                    user.Name = "Jimmy";
                    user.Messages.Clear();
                    user.Messages.Add(new Message() { MessageContent = "It's me - JIMMy!" });

                }
                context.SaveChanges();
            }






        }
    }
}
