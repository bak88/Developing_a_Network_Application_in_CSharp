using Lecture6._1_xUnit;
using Moq;

namespace Lecture6_NUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd()
        {
            Mock<ICalculateService> mock = new Mock<ICalculateService>();

            mock.Setup(x => x.Add(2, 3)).Returns(5);

            Calculator calc = new Calculator(mock.Object);

            int res = calc.Add(2, 3);

            Assert.That( res, Is.EqualTo(5));
        }

        [Test]
        public void TestSubtract()
        {
            Mock<ICalculateService> mock = new Mock<ICalculateService>();

            mock.Setup(x => x.Subtract(2, 3)).Returns(-1);

            Calculator calc = new Calculator(mock.Object);

            int res = calc.Subtract(2, 3);

            Assert.That(res, Is.EqualTo(-1));
        }
    }
}
