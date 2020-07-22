using System;
using System.Collections.Generic;
using System.Text;

namespace BAi14_XuLyNgoaiLe
{
    class Overflow
    {
        static void Main()
        {
            //checked
            //{
            //    int number1 = 2236222, number2 = 1224344685;
            //    try
            //    {
            //        int result = number1 * number2;
            //        Console.WriteLine(result);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.GetType());
            //    }
            //    finally
            //    {
            //        Console.WriteLine(number1);
            //    }
            //}
            Console.WriteLine("Vi du minh hoa Exception trong C#");
            Console.WriteLine("---------------------------------");

            TestCsharp d = new TestCsharp();
            d.phepChia(25, 10);
            Console.ReadKey();
        }
    }
    public class TestCsharp
    {
        int result;
       public  TestCsharp()
        {
            result = 0;
        }
        public void phepChia(int num1, int num2)
        {
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Bat Exception: {0}", e);
            }
            finally
            {
                Console.WriteLine("Ket qua: {0}", result);
            }
        }
    }
}