namespace Seminar2._1
{
    internal class Program
    {

        //Напишите приложение для одновременного выполнения двух задач в потоках.
        //Нужно подсчитать сумму элементов каждого из массивов а потом сложить эти
        //суммы полученные после выполнения каждого из потоков и вывести результат
        //на экран

        static int[] arr1 = { 1, 2, 3 };
        static int[] arr2 = { 4, 5, 6 };

        static int sum1;
        static int sum2;

        static public void Sum1()
        {
            sum1 = 0;
            foreach (int i in arr1)
            {
                sum1 += i;
            }
            Console.WriteLine(sum1);
        }

        static public void Sum2()
        {
            sum2 = 0;
            foreach (int i in arr2)
            {
                sum2 += i;
            }
            Console.WriteLine(sum2);
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Sum1);
            Thread thread2 = new Thread(Sum2);

            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();

            Console.WriteLine(sum1 + sum2);

        }
    }
}
