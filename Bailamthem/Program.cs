using System;

namespace Bailamthem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            int number;
            do
            {
                System.Console.WriteLine(" enter numbre: "); ;
                // string str = Console.ReadLine();
                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result|| number <0|| number >5);
            Console.WriteLine("number: " + number);


        }
    }
}
