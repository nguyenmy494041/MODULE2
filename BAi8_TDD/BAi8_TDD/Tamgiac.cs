using System;
using System.Collections.Generic;
using System.Text;

namespace BAi8_TDD
{
   public class Tamgiac
    {
        public string Kiemtratamgiac(int a, int b, int c)
        {
            if (a + b > c && c > 0 && a + c > b && b > 0 && b + c > a && a > 0)
            {
                if (a == b && b == c) return "tam giac deu";
                else if (a == b || b == c || a == c) return "tam giac can";
                else return "tam giac thuong";
            }
            return "Khong phai tam giac";
        }
    }
}
