namespace Lecture2._2
{
    internal class Program
    {
        static object lockObj = new object();
        static void Print()
        {
            lock (lockObj)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {i}");
                }
            }
        }

        static Mutex mtx = new Mutex();
        static Mutex mutex;
        static void Print1()
        {
            try
            {
                mtx.WaitOne();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {i}");
                }
            }
            finally
            {
                mtx.ReleaseMutex();
            }
        }

        static bool isStarted = true;
        static AutoResetEvent autoResetEvent = new AutoResetEvent( false );
        static void ThreadProc1()
        {
            while (isStarted)
            {
                Console.Write("Who");
                Thread.Sleep(500);
                Console.WriteLine(" are we?");
                Thread.Sleep(500);                
                autoResetEvent.Set();
                autoResetEvent.WaitOne();
            }
        }

        static void ThreadProc2() 
        {
            while (isStarted)
            {
                autoResetEvent.WaitOne();
                Console.WriteLine("Programmers");
                autoResetEvent.Set();
            }

        }


        static void Main(string[] args)
        {

            //// lock
            //for (int i = 0; i < 5; i++)
            //{
            //    Thread t = new Thread(Print);
            //    t.Name = $"Thread {i}";
            //    t.Start();
            //}




            //// Mutex()
            //for (int i = 0; i < 5; i++)
            //{
            //    Thread thread = new Thread(Print1);
            //    thread.Name = $"Thread {i}";
            //    thread.Start();
            //}




            //// Mutex(boolean)
            //mutex = new Mutex(true);
            //Console.WriteLine("Мьютекс создан и контроль над ним получен.");
            //for (int i = 0; i < 5; i++)
            //{
            //    Thread thread = new Thread(Print1);
            //    thread.Name = $"Thread {i}";
            //    thread.Start();
            //}
            //Thread.Sleep(1000);
            //mutex.ReleaseMutex();
            //Console.WriteLine("После 1 секунды ожидания, освобожден мьютекс");




            //// Mutex(boolean, string)
            //using (Mutex mutex = new Mutex(true, "Global\\MyMutex")) 
            //{
            //    mutex.WaitOne();
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine($"{i}");
            //        Thread.Sleep(100);
            //    }
            //    mutex.ReleaseMutex();
            //    mutex.ReleaseMutex();
            //}






            //// Mutex(bool, string, bool)
            //using (Mutex mutex = new Mutex(true, "Global\\MyMutex", out bool createdNew))
            //{
            //    if (!createdNew)
            //    {
            //        Console.WriteLine("Повторный запуск. Закрываем приложение.");
            //        return;
            //    }
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine($"{i}");
            //        Thread.Sleep(100);
            //    }
            //    mutex.ReleaseMutex();
            //}



            // AutoResetEvent
            new Thread(ThreadProc1).Start();
            new Thread(ThreadProc2).Start();
            new Thread(ThreadProc2).Start();
            new Thread(ThreadProc2).Start();

            Thread.Sleep(5000);

            isStarted = false;













        }
    }
}
