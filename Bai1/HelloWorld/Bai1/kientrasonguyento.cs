using System;

namespace HelloWorld
{
    public class Bai1
    {
        public static void Isprime()
        {
            int number;
            Console.WriteLine("Enter a number: ");
            number = Convert.ToInt32(Console.ReadLine());

            if (number < 2)
            {
                Console.WriteLine(number + " is not prime");
            }
            else
            {

                bool check = true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine(number + " is prime");
                }
                else
                {
                    Console.WriteLine(number + " is not prime");
                }


            }

        }
    }
}