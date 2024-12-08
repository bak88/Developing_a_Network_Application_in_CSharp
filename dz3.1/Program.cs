namespace dz3._1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                await Server.AcceptMessage();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {                  
                       await Client.SendMessage($"{args[0]} {i}");           
                }
            }
        }
    }
}
