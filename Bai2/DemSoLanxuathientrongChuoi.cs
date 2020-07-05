using System;
namespace Bai2
{
    public static class Demkytu
    {
        public static void Main()
        {
            Console.WriteLine("Enter string: ");
            string str = Console.ReadLine();
            int count = 0;
            Console.WriteLine("Enter chart: ");
            char chart = char.Parse(Console.ReadLine());
            for (byte i = 0; i < str.Length; i++)
            {
                if (str[i] == chart)
                {
                    count++;
                }
            }
            Console.WriteLine($"'{chart}' appears {count} times.");

        }
    }
}