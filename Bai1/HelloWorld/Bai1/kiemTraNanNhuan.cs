using System;

namespace HelloWorld
{
    public class Bai4
    {
        public static void IsLeapYear()
        {
            int Year;
            Console.Write("Enter is Year: ");
            Year = Convert.ToInt32(Console.ReadLine());
            bool check = false;
            if ((Year % 4 == 0 && Year % 100 != 0) || Year % 400 == 0)
            {
                check = true;
            }
            if (check)
            {
                Console.WriteLine(Year + " is LeapYear");
            }
            else
            {
                Console.WriteLine(Year + " not is LeapYear");
            }
        }
    }
}