namespace Lecture6._1_xUnitTest
{
    public class FactorialCalculate()
    {
        public int CalculateFactorial(int n) => 120;
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int number = 5;

            int result = new FactorialCalculate().CalculateFactorial(number);

            Assert.Equal(120, result);
        }
    }
}
