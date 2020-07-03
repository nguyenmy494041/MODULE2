using System;
namespace HelloWorld
{
    public class hienThi
    {
        public static void hienthi()
        {
            Console.WriteLine("Enter your name: ");

            string yourName = Console.ReadLine();

            Console.WriteLine("Hello: " + yourName);
        }
    }
}