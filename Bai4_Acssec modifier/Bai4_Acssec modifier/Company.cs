using System;
using System.Collections.Generic;
using System.Text;

namespace Bai4_Acssec_modifier
{
    public class AccessModifier
    {
        public static void Main()
        {
            
           Console.WriteLine(Company.Sum(-3, 4));
        }
    }

    class Company
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
