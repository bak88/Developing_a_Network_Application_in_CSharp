using Lecture6._1_xUnit;

namespace MSTest1
{
    [TestClass]
    public sealed class FibonacciTests
    {
        [TestMethod]
        [Ignore]
        public void TestMethod1()
        {
            throw new Exception();
        }

        [TestMethod]
        public void TestMethod2()
        {
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException")]
        public void TestNonValidValueNegativ()
        {
            new Fibonacci().Calculate(-1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException")]
        public void TestNonValidValueAbove46()
        {
            new Fibonacci().Calculate(47);
        }

        [TestMethod]
        [Ignore]
        public void TestMaxInt()
        {
            Fibonacci fib = new Fibonacci();
            int prev = 1;

            for (int i = 3; i < int.MaxValue; i++)
            {
                int cur = fib.Calculate(i);

                Assert.IsTrue(prev <  cur, $"Current = {cur}, previous = {prev}, i ={i}");

                prev = cur;
            }
            
        }

        [TestMethod]
        public void TestCorrectness()
        {
            Fibonacci fib = new Fibonacci();

            Assert.AreEqual(1, fib.Calculate(1));
            Assert.AreEqual(1, fib.Calculate(2));
            Assert.AreEqual(2, fib.Calculate(3));
            Assert.AreEqual(3, fib.Calculate(4));
            Assert.AreEqual(5, fib.Calculate(5));
        }
    }
}
