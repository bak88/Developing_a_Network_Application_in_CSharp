using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6._1_xUnit
{
    public class Fibonacci
    {
        public int Calculate(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("number can't be less then 1");

            if (number > 46)
                throw new ArgumentOutOfRangeException("exceed max int value");

            int first = 1;
            int second = 1;

            for (int i = 2; i <= number; i++)
            {
                int temp = first;
                first = second;
                second = temp + first;
            }
            return first;
        }
    }
}
