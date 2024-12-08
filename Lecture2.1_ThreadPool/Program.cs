namespace Lecture2._1_ThreadPool
{
    internal class Program
    {
        static void ThreadProc(Object? stateInfo)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"This is {stateInfo} " + i);
                Thread.Sleep(100);
            }
        }
        static void PrintPoolCounters()
        {
            ThreadPool.GetAvailableThreads(out int workerThreads, out int completionPortThreads);
            ThreadPool.GetMaxThreads(out int workerThreadsMax, out int completionPortThreadsMax);
            ThreadPool.GetMinThreads(out int workerThreadsMin, out int completionPortThreadsMin);

            Console.WriteLine($"Worker threads = {workerThreads}, completion = {completionPortThreads}");
            Console.WriteLine($"Worker threads max = {workerThreadsMax}, completion max = {completionPortThreadsMax}");
            Console.WriteLine($"Worker threads min = {workerThreadsMin}, completion min = {completionPortThreadsMin}");
        }
        static void ThreadProc1(string name)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"This is {name} " + i);
                Thread.Sleep(100);
            }
        }
        static void ThreadProc2(object? msg, bool timeout)
        {
            Console.WriteLine($"Message = {msg}, timeout = {timeout}");
        }

        static RegisteredWaitHandle? registerWaitHandle = null;
        static int counter = 0;
        static void ThreadProc3(object? msg, bool timeout)
        {
            counter++;
            Console.WriteLine($"Message = {msg}, timeout = {timeout}, counter = {counter}");

            if (counter == 10)
            {
                registerWaitHandle?.Unregister(null);
            }
        }


        static void Main(string[] args)
        {

            //// ThreadPool
            //ThreadPool.QueueUserWorkItem(ThreadProc);
            //Thread.Sleep(1000);




            //// CompletedWorkItemCount
            //Console.WriteLine($"Complete: {ThreadPool.CompletedWorkItemCount}");
            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread1");
            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread2");

            //Thread.Sleep(1800);

            //Console.WriteLine($"Complete: {ThreadPool.CompletedWorkItemCount}");



            //// ThreadCount 
            //Console.WriteLine($"Thread in pool: {ThreadPool.ThreadCount}");
            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread1");
            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread2");

            //Thread.Sleep(100);
            //Console.WriteLine($"Thread in pool: {ThreadPool.ThreadCount}");

            //Thread.Sleep(2000);           
            //Console.WriteLine($"Thread in pool: {ThreadPool.ThreadCount}");




            //// PendingWorkItemCount
            //Console.WriteLine($"Tasks is pending: {ThreadPool.PendingWorkItemCount}");
            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread1");
            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread2");

            //Console.WriteLine($"Tasks is pending: {ThreadPool.PendingWorkItemCount}");         

            //Thread.Sleep(2000);
            //Console.WriteLine($"Tasks is pending: {ThreadPool.PendingWorkItemCount}");





            //// GetAvailableThreads(out int threads, out int completionPortThreads)
            //// GetMaxThreads(out int worker, out int io)
            //// GetMinThreads(out int worker, out int io)
            //PrintPoolCounters();

            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread1");
            //ThreadPool.QueueUserWorkItem(ThreadProc, "Thread2");
            //Thread.Sleep(200);

            //PrintPoolCounters();

            //Thread.Sleep(2000);
            //Console.WriteLine($"Tasks is pending: {ThreadPool.PendingWorkItemCount}");




            //// QueueUserWorkItem<T>(Action<T>, T, boolean)
            //ThreadPool.QueueUserWorkItem(ThreadProc1, "Thread1", false);
            //ThreadPool.QueueUserWorkItem(ThreadProc1, "Thread2", false);
            //Thread.Sleep(2000);




            //// RegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, object, int, boolean)
            //AutoResetEvent waitHandle = new AutoResetEvent(false);
            //ThreadPool.RegisterWaitForSingleObject(waitHandle, ThreadProc2, "TimerExecuted", 1000, false);

            //Console.ReadLine();

            //waitHandle.Set();

            //Thread.Sleep(100);




            AutoResetEvent waitHandler = new AutoResetEvent(false);
            registerWaitHandle = ThreadPool.UnsafeRegisterWaitForSingleObject(waitHandler, ThreadProc3, "TimerExecuted", 100, false);
            Console.ReadLine();















        }
    }
}
