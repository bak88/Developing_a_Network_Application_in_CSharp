namespace dz2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool isWork = true;
            string stopWord = "Exit".ToLower();
            string message;

            while (isWork)
            {
                Console.WriteLine("Enter message: ");
                message = Console.ReadLine()!;

                if (message.ToLower() == stopWord)
                {
                    isWork = false;
                }
            }

        }
    }

}
