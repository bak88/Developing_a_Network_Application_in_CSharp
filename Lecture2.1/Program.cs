using System.Globalization;

namespace Lecture2._1
{
    internal class Program
    {
        static void PrintThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - One");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - Two");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - Three");
                Thread.Sleep(100);
            }
        }
        static int Fib(int i)
        {
            if (i <= 0) return 0;
            if (i == 1) return 1;

            return Fib(i - 1) + Fib(i - 2);
        }

        static bool isActive = true;
        static void ThreadProc()
        {
            long c = 0;
            while (isActive)
            {
                c++;
            }

            Thread t = Thread.CurrentThread;
            Console.WriteLine($"Thread {t.Name} with priority {t.Priority} made {c} iterations");
        }
        static void ThreadProc1()
        {
            Console.WriteLine($"Состояние потока(вызов из ThreadProc) - {Thread.CurrentThread.ThreadState}");
            Thread.Sleep(400);
        }

        static LocalDataStoreSlot localSlot = Thread.AllocateDataSlot();
        static void ThreadProc3(int x)
        {
            for (int i = 0; i < 10; i++)
            {
                var data = ((int?)Thread.GetData(localSlot)) ?? 0;
                Thread.SetData(localSlot, data + x);
            }
            Console.WriteLine("Total=" + Thread.GetData(localSlot));
        }

        [ThreadStatic] static int l = 0;
        static void ThreadProc4(int x)
        {
            for (int i = 0; i < 10; i++)
            {
                l += x;
            }
            Console.WriteLine("Total=" + l);
        }
        static void ThreadProc5(int x)
        {
            LocalDataStoreSlot ds = Thread.GetNamedDataSlot("Counter");

            for (int i = 0; i < 10; i++)
            {
                int c = (int?)Thread.GetData(ds) ?? 0;
                Thread.SetData(ds, c + x);
            }
            Console.WriteLine("Total=" + Thread.GetData(ds));
        }

        static bool isActive2 = true;
        static void ThreadProc6()
        {
            long c = 0;
            while (isActive2)
            {
                Console.WriteLine($"Processor id for thread {Thread.CurrentThread.Name} = {Thread.GetCurrentProcessorId()} ");
                c++;
                Thread.Sleep(1000);
            }
        }
        static void ThreadProc7()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("Method ThreadProc7 finished");
        }

        static void Main(string[] args)
        {

            //for (int i = 0; i < 10; i++)
            //{
            //    var t = new Thread(PrintThread);
            //    t.Start();
            //}






            //ThreadStart method = () =>
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - One");
            //        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - Two");
            //        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - Three");
            //        Thread.Sleep(100);
            //    }
            //};

            //for (int i = 0; i < 5; i++)
            //{
            //    Thread thread = new Thread(method);
            //    thread.Start();
            //}






            //ParameterizedThreadStart method = (object x) =>
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine(x + " one");
            //        Console.WriteLine(x + " two");
            //        Console.WriteLine(x + " three");
            //        Thread.Sleep(100);
            //    }
            //};
            //for (int i = 0; i < 5; i++)
            //{
            //    var t = new Thread(method);
            //    t.Start(i);
            //}




            //var t = new Thread(() =>
            //{
            //    int x = 1;
            //    Console.WriteLine(Fib(x));
            //}, 1);

            //t.Start();






            //// CurrentCulture
            //var t = new Thread(() =>
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.CurrentCulture}");
            //    Console.WriteLine(DateTime.Now.ToString());

            //    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //    Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            //    Console.WriteLine(DateTime.Now.ToString());
            //});
            //t.Start();





            //// CurrentThread 
            //Console.WriteLine($"MainThread.CurrentThread.GetHashCode()= {Thread.CurrentThread.GetHashCode()}");
            //var t = new Thread(() =>
            //{
            //    Console.WriteLine($"MainThread.CurrentThread.GetHashCode()= {Thread.CurrentThread.GetHashCode()}");
            //});
            //Console.WriteLine($"t.GHC={t.GetHashCode()}");
            //t.Start();





            //// IsAlive
            //var t = new Thread(() =>
            //{
            //    Console.WriteLine("2 = " + Thread.CurrentThread.IsAlive);
            //});

            //Console.WriteLine("1 = " + t.IsAlive);
            //t.Start();






            //// IsBackground 
            //var t = new Thread(() =>
            //{
            //    for (global::System.Int32 i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine(Thread.CurrentThread.IsBackground);
            //        Thread.Sleep(1000);
            //    }
            //});
            ////t.IsBackground = true;
            //t.Start();
            //Thread.Sleep(5000);
            //Console.WriteLine("Main finished");






            //// Priority
            //var t1 = new Thread(ThreadProc);
            //t1.Priority = ThreadPriority.Lowest;
            //t1.Name = "t1";

            //var t2 = new Thread(ThreadProc);
            //t2.Priority = ThreadPriority.Normal;
            //t2.Name = "t2";

            //var t3 = new Thread(ThreadProc);
            //t3.Priority = ThreadPriority.Highest;
            //t3.Name = "t3";

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //Thread.Sleep(5000);

            //isActive = false;







            //// ThreadState
            //var thread = new Thread(ThreadProc1);
            //Console.WriteLine($"Состояние потока(до старта) - {thread.ThreadState}");
            //thread.Start();
            //Console.WriteLine($"Состояние потока(после старта) - {thread.ThreadState}");
            //Thread.Sleep(200);
            //Console.WriteLine($"Состояние потока(в момент паузы) - {thread.ThreadState}");
            //Thread.Sleep(200);
            //Console.WriteLine($"Состояние потока(после завершения) - {thread.ThreadState}");




            //// LocalDataStoreSlot
            //var thread1 = new Thread(() => { ThreadProc3(1); });
            //var thread2 = new Thread(() => { ThreadProc3(-1); });
            //var thread3 = new Thread(() => { ThreadProc3(10); });

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();




            //// [ThreadStatic] 
            //var thread1 = new Thread(() => { ThreadProc4(1); });
            //var thread2 = new Thread(() => { ThreadProc4(-1); });
            //var thread3 = new Thread(() => { ThreadProc4(10); });

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();




            //// AllocateNamedDataSlot(String)
            //// GetNamedDataSlot(String)
            //// FreeNamedDataSlot(String) 
            //Thread.AllocateNamedDataSlot("Counter");

            //Thread thread1 = new Thread(() => { ThreadProc5(1); });
            //Thread thread2 = new Thread(() => { ThreadProc5(-1); });
            //Thread thread3 = new Thread(() => { ThreadProc5(10); });

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

            //Thread.Sleep(3000);

            //Thread.FreeNamedDataSlot("Counter");





            //// GetCurrentProcessorId()
            //Thread thread1 = new Thread(() => { ThreadProc6(); });
            //thread1.Name = "Thread1";
            //thread1.Start();

            //Thread thread2 = new Thread(() => {ThreadProc6(); });
            //thread2.Name = "Thread2";
            //thread2.Start();

            //Thread.Sleep(10000);

            //isActive2 = false;





            //// Join()
            //Thread t = new Thread(() => { ThreadProc7(); });
            //t.Start();
            //t.Join();
            //Console.WriteLine("Method Main Finished");




            // Join(int), Join(TimeSpan)
            Thread t = new Thread(() => { ThreadProc7(); });
            t.Start();
            bool success = t.Join(100);

            if (success)
                Console.WriteLine("Метод Main завершился после выполнения потока t");
            else
                Console.WriteLine("Метод Main завершился до выполнения потока t");











        }
    }
}
