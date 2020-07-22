using System;
using System.Collections.Generic;
using System.Text;

namespace BAi14_XuLyNgoaiLe
{
    class Format
    {
        static void Main()
        {
            checked
            {
                try
                {
                    decimal price = 169.32m;
                    Console.WriteLine("The cost is {1}.", price);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType());
                }
            }
        }
    }
}
