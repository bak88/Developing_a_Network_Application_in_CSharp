namespace Lecture5._4_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Добаить пользователя
            //using(TestContext ctx = new TestContext())
            //{
            //    User uswe1 = new User()
            //    { 
            //        Name = "Foo",
            //        GenderId = GenderId.Male                
            //    };

            //    User uswe2 = new User()
            //    {
            //        Name = "Moo",
            //        GenderId = GenderId.Femaly
            //    };

            //    ctx.Users.Add(uswe1);
            //    ctx.Users.Add(uswe2);

            //    ctx.SaveChanges();
            //}






            //ТРанзакция
            using (TestContext ctx = new TestContext())
            {
                using(var txn = ctx.Database.BeginTransaction())
                {
                    User user = new User() { Name = "Bim", GenderId = GenderId.Male};

                    ctx.Users.Add(user);

                    ctx.SaveChanges();

                    if (user.Id % 2 == 0)
                        user.Messages.Add( new Message { Message1 = "Четное" } );
                    else
                        user.Messages.Add(new Message { Message1 = "Нечетное" });
                    

                    ctx.SaveChanges();
                    txn.Commit();
                }
            }






            //// Получение всех сообщений
            //using (TestContext ctx = new TestContext())
            //{
            //    List<User> users = ctx.Users.ToList();

            //    foreach (User user in users)
            //    {
            //        Console.WriteLine($"Name {user.Name}, Gender {user.GenderId}");
            //        Console.WriteLine("______Message:");

            //        ICollection<Message> messages = user.Messages;
            //        foreach (var message in messages)
            //        {
            //            Console.WriteLine($"______:{message.Message1}");
            //        }
            //    }
            //}
        }
    }
}
