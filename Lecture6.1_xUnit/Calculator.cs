using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6._1_xUnit
{
    public class Calculator 
    {
        private readonly ICalculateService _calculateService;

        public Calculator(ICalculateService calculateService)
        {
            _calculateService=calculateService;
        }

        public int Add(int a , int b)
        {
            return _calculateService.Add(a , b);
        }

        public int Subtract(int a , int b)
        {
            return _calculateService.Subtract(a , b);
        }
    }
}
