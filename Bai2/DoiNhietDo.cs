using System;
namespace Bai2
{
    public class DoiNhietDo
    {
        public static void Main()
        {
            double fahrenheit;
            double celsius;
            int choice;

            do
            {
                Console.WriteLine("Menu.");
                Console.WriteLine("1. Fahrenheit to Celsius");
                Console.WriteLine("2. Celsius to Fahrenheit");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice: ");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Fahrenheit:");
                        fahrenheit = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{fahrenheit} fahrenheit to {FahrenheitToCelsius(fahrenheit)} Celsius ");
                        break;
                    case 2:
                        Console.Write("Enter Celsius:");
                        celsius = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{celsius} celsius to {CelsiusToFahrenheit(celsius)} fahrenheit ");
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            } while (choice != 0);

        }
        public static double CelsiusToFahrenheit(double celsius)
        {
            double fahrenheit = (9.0 / 5) * celsius + 32;
            return fahrenheit;
        }
        public static double FahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (5.0 / 9) * (fahrenheit - 32);
            return celsius;
        }
    }
}