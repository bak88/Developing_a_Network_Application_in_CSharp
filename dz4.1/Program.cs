namespace dz4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                ChatProgram.Server(args[0]); // if user wants to start server must enter his name
            }
            if (args.Length == 2)
            {
                ChatProgram.ClientSender(args[0], args[1]); // if user wants to start client must enter his name and ip of the server 127.0.0.1
                ChatProgram.ClientReciever(args[0], args[1]); // if user wants to start client must enter his name and ip of the server 127.0.0.1
            }
            else
            {
                Console.WriteLine("Invalid inputs count must be 1(username) for server and 2 for client(username and ip(127.0.0.1)). Try again. ");
            }
            // This part is for use only with Prototype Pattern realization



            // And this part is for use only with Command Pattern realization but it is not working

            /* ChatServer chatServer = new ChatServer();

             chatServer.AddCommand(new ReceiveMessageCommand(new IPEndPoint(IPAddress.Any, 0)));

             chatServer.AddCommand(new SendMessageCommand(" Hello, I am a client.", new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345), DateTime.Now, "Tata"));

             chatServer.ProcessCommands();*/
        }
    }
}
