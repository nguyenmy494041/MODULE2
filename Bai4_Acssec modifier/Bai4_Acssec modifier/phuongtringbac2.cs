using System;
using System.Collections.Generic;
using System.Text;

namespace Bai4_Acssec_modifier
{
    class phuongtringbac2
    { public static void Main()
        {
            Console.WriteLine("Enter a: ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter b: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter c: ");
            double c = double.Parse(Console.ReadLine());
            QuadraticEquation pt1 = new QuadraticEquation(a, b, c);
            pt1.quadraticEquation();
        }
    }
    class QuadraticEquation
    {
        private double a;
        private double b;
        private double c;
        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double GetA()
        {
            return a;
        }
        public double GetC()
        {
            return c;
        }
        public double GetB()
        {
            return b;
        }
        public double Deta()
        {
            return b * b - 4 * a * c;
        }
        public void Giai(double a, double b)
        {
            if (a == 0 && b == 0) Console.WriteLine( "The equation has all roots");
            if (a == 0 && b != 0) Console.WriteLine("The equation has no roots");
            if (a != 0) Console.WriteLine($"The equation has one roots: x = {Math.Round((-b / a),3)}");
        }
        public double GetRoot1()
        {
            return Math.Round((-b + Math.Sqrt(Deta())) / (2 * a),3);
        }
        public double GetRoot2()
        {
            return Math.Round((-b - Math.Sqrt(Deta())) / (2 * a),3);
        }
        public  void quadraticEquation()
        {
            if (a == 0) { Giai(b, c); } else
            {
                if (Deta() > 0)
                {
                    Console.WriteLine($"The equation has two roots: x_1 = {GetRoot1()}, x_2 = {GetRoot2()} ");
                } else if(Deta() == 0)
                {
                    Console.WriteLine($"The equation has one roots: x = {GetRoot1()}");
                } else Console.WriteLine("The equation has no roots");
            }
        }
    } 

}
