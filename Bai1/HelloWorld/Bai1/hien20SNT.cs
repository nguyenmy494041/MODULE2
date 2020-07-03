using System;
namespace HelloWorld
{
    public class soNguyenTo
    {
        public static void hienthi()
        {
            byte count = 0;
            int N = 0;
            while (count < 20)
            {
                if (IsPrime(N))
                {
                    Console.Write($"{N}; ");
                    count++;
                }
                N++;
            }
        }
        public static bool IsPrime(int number)
        {
            bool check = true;
            if (number < 2)
            {
                check = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }
    }
}