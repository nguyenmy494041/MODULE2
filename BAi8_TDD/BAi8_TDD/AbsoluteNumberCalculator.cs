using System;
using System.Collections.Generic;
using System.Text;

namespace BAi8_TDD
{
    public class AbsoluteNumberCalculator
    {
        public int FindAbsolute(int number)
        {
            if (number >= 0) return number;
            else return -number;
            //return Math.Abs(number);
        }
    }
}
