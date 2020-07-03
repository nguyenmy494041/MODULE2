using System;
namespace HelloWorld
{
    public class giaiPTB1
    {
        public static void giai()
        {
            Console.WriteLine("Linear Equation Resolver");
            Console.WriteLine("Given a equation as 'a * x + b = 0', please enter constants:");
            Console.Write("a: ");
            double a = Double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            if (a != 0)
            {
                Console.WriteLine($"{a}x + {b} <=> x = {-b / a}");
            }
            else
            {
                if (b == 0)
                {
                    Console.WriteLine($"{a}x + {b}  The solution is all x !");
                }
                else
                {
                    Console.WriteLine($" {a}x + {b} Nod solution!");
                }
            }
        }
    }
}