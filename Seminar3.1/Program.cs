namespace Seminar3._1
{
    //Напишите приложение для одновременного выполнения двух задач в потоках
    //созданных с помощью Task.Нужно подсчитать сумму элементов каждого из
    //массивов а потом сложить эти суммы полученные после выполнения каждого
    //из потоков и вывести результат на экран.

    internal class Program
    {
        static int[] arr1 = Enumerable.Range(1, 10000).Select(x => Random.Shared.Next(0, 9)).ToArray();
        static int[] arr2 = Enumerable.Range(1, 10000).Select(x => Random.Shared.Next(0, 9)).ToArray();

        static async Task<int> Sum(int[] arr)
        {
            await Task.CompletedTask;
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            return sum;

        }
        static async Task Main(string[] args)
        {
            Task<int> sum1 = Sum(arr1);
            Task<int> sum2 = Sum(arr2);
            await sum1;
            await sum2;
            

            Console.WriteLine($"{sum1.Result + sum2.Result} ");
        }
    }
}
