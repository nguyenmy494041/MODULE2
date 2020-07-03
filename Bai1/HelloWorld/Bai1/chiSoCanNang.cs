using System;
namespace HelloWorld
{
    public class chiSoCanNang
    {
        public static void tinhChiSo()
        {
            Console.WriteLine("Enter weight:");
            float weight = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter height:");
            float height = float.Parse(Console.ReadLine());

            double bmi = Math.Round(weight / Math.Pow(height, 2), 1);

            Console.WriteLine("BMI: " + bmi);

            if (bmi < 18)
                Console.WriteLine(" Underweight");
            else if (bmi < 25.0)
                Console.WriteLine(" Normal");
            else if (bmi < 30.0)
                Console.WriteLine(" Overweight");
            else
                Console.WriteLine(" Obese");

        }
    }
}