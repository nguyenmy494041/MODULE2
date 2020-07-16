using System;

namespace BAi8_TDD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

      
    }
    public class CalculatorService
    {
        public int Add(int number1, int number2)
        {

            return number1 + number2;
        }

        public int Sub(int number1, int number2)
        {

            return number1 - number2;
        }
    }
}