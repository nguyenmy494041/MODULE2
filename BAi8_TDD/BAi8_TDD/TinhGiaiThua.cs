using System;
using System.Collections.Generic;
using System.Text;

namespace BAi8_TDD
{
    public class TinhGiaiThua
    {
        public int Calc(int val)
        {
            //if(val > 1)
            //{
            //   return val*Calc(val - 1);
            //} else
            //{
            //    return 1;
            //}
            //if(val == 0)
            //{
            //    return 1;
            //} else if (val < 0)
            //{
            //    return -1;
            //} else
            //{
            //    int giaiThua = 1;
            //    for (int i = 1; i <= val; i++)
            //    {
            //        giaiThua *= i;
            //    }
            //    return giaiThua;
            //}

            int giaiThua = 1;
            for (int i = 1; i <= val; i++)
            {
                giaiThua *= i;
            }
            return giaiThua;
        }
    }
}
