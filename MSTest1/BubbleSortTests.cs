using Lecture6._1_xUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6_xUnitMSTest
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void TestNull()
        {
            BubbleSort sort = new BubbleSort();

            sort.Sort(null);
        }

        [TestMethod]
        public void TestEmpty()
        {
            BubbleSort sort = new BubbleSort();

            sort.Sort(new int[] { });
        }

        [TestMethod]
        public void TestSort()
        {
            int[] arr = Enumerable.Range(1, 10).Select((_) => new Random().Next(1, 10)).ToArray();

            BubbleSort sort = new BubbleSort();

            sort.Sort(arr);

            for (int i = 1; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] >= arr[i - 1]);
            }

        }
    }
}
