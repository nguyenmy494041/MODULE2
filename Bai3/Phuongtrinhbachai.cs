using System;
namespace Bai3
{
    public class PtB2
    {
        public static void Main()
        {
            QuadraticEquation pt1 = new QuadraticEquation(1, 3, -4);
            pt1.quadraticEquation();
            Console.WriteLine(pt1.GetA());
        }
    }
    class QuadraticEquation
    {
        private double a;
        private double b;
        private double c;

        public double GetA()
        {
            return this.a;
        }
        public double GetB()
        {
            return this.b;
        }
        public double GetC()
        {
            return this.c;
        }

        // private double coefficient
        // {
        //     get => coefficient;
        //     set => coefficient = value;
        // }
        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double GetDiscriminant()
        {
            return b * b - 4 * a * c;
        }
        public double GetRoot1()
        {
            return (-b + Math.Sqrt(GetDiscriminant())) / (2 * a);
        }
        public double GetRoot2()
        {
            return (-b - Math.Sqrt(GetDiscriminant())) / (2 * a);
        }
        public void quadraticEquation()
        {
            if (this.GetDiscriminant() > 0)
            {
                Console.WriteLine($"The equation has two roots {GetRoot1()} and {GetRoot2()}");
            }
            else if (this.GetDiscriminant() == 0)
            {
                Console.WriteLine($"The equation has two roots {GetRoot1()}");
            }
            else
            {
                Console.WriteLine("The equation has no real roots");
            }
        }
    }

}
