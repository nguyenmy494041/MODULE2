using System;

namespace BAi7_CleanCode
{
    class ClassRefactoring
    {
         public static void Main(string[] args)
        {
           
           
            int N = 1;
            while (N <= 100)
            {
                Console.Write(FizzBuzzDemo.FizzBuzz(N)+",   ");
                N++;
            }
        }
    }
    class FizzBuzzDemo
    {
        public static  string FizzBuzz(int number)
        {
            bool IsFizz = number % 3 == 0;
            bool IsBuzz = number % 5 == 0;
            if (IsBuzz && IsFizz)
                return "FizzBuzz";

            if (IsFizz)
                return "Fizz";

            if (IsBuzz )
                return "Buzz";

            return $"{number}";
        }
    }
}
