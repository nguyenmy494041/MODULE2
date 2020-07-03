using System;
namespace HelloWorld
{
    public class hienThiHinh
    {
        public static void taoHinh()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Print the rectangle");
            Console.WriteLine("2. Print the square triangle");
            Console.WriteLine("3. Print isosceles triangle");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter the choice: ");
            Byte choise = Byte.Parse(Console.ReadLine());

            switch (choise)
            {

                case 1:
                    for (byte i = 0; i < 4; i++)
                    {
                        for (byte j = 0; j < 8; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine("");
                    }
                    break;
                case 2:
                    for (byte i = 0; i < 5; i++)
                    {
                        for (byte j = 0; j < i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine("");
                    }
                    break;

            }

        }
    }
}