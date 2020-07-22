using System;
using System.Collections.Generic;
using System.Text;

namespace BAi14_XuLyNgoaiLe
{
    class DivideByZero
    {
        static void Main()
        {
            try
            {
                int number1 = 1254;
                int number2 = 0;
                int result = number1 / number2;

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("chia cho 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.GetType());
            }
        }
    }
}
