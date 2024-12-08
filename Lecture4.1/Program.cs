namespace Lecture4._1
{
    public class Singleton
    {
        private static Singleton instance;

        private static readonly object lockObj = new object();
        private Singleton() { }

        public static Singleton Instance
        { 
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        public void DoSomeWork()
        {
            Console.WriteLine("Work");
        }
    }
    public class Singleton1
    {
        private static readonly Lazy<Singleton1> lazyInstance = new Lazy<Singleton1>(() => new Singleton1());
        private Singleton1() { }

        public static Singleton1 Instance => lazyInstance.Value;

        public void DoSomeWork1()
        {
            Console.WriteLine("hi I'm Singelton1");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton1.Instance.ToString();
        }
    }
}
