using System;
namespace HelloWorld
{
    public class UCLN
    {
        public static void UocChungLonNhat()
        {
            Console.WriteLine(" Enter a = ");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine(" Enter b = ");
            int b = Int32.Parse(Console.ReadLine());
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0 || b == 0)
            {
                Console.WriteLine("No greatest common factor");
            }
            else
            {
                while (a != b)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }
                Console.WriteLine("Greatest common factor: " + a);
            }

        }
    }
}