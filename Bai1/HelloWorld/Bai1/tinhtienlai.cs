using System;
namespace HelloWorld
{
    public class Bai6
    {
        public static void tinhTienLai()
        {
            byte month;
            double money;
            double intersetRate;
            Console.WriteLine(" Enter is month:");
            month = Byte.Parse(Console.ReadLine());
            Console.WriteLine("Enter is money:");
            money = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter is intersetRate:");
            intersetRate = Double.Parse(Console.ReadLine());

            Console.WriteLine("totalInterset is: " + money * (intersetRate / 100) / 12 * month);

        }
    }
}