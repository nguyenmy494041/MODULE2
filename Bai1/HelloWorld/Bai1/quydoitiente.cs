using System;
namespace HelloWorld
{
    public class doiTiente
    {
        public static void doitien()
        {
            Console.WriteLine("Enter USD");
            int USD = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter rate:");
            float rate = float.Parse(Console.ReadLine());
            Console.WriteLine($"{USD}$ can be exchanged {USD * rate}VND");

        }
    }
}