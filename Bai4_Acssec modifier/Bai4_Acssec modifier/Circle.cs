using System;
using System.Collections.Generic;
using System.Text;

namespace Bai4_Acssec_modifier
{    public class ClassCircle
    {
        public static void Main()
        {
            Circle circle = new Circle();
            Console.WriteLine("Enter radius: ");
            circle.GetRadius = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter color: ");
            circle.GetColor = Console.ReadLine();
           
            Console.WriteLine(circle.ToString());

        }
    }
    class Circle
    {
        private double radius = 1;
        private string color = "red";
        public Circle()
        {

        }
        public Circle( double _radius)
        {
            this.radius = _radius;
            
        }
        public  double GetRadius
        {
            get => radius;
            set => radius = value;
        }
        public string GetColor
        {
            get => color;
            set => color = value;
        }
        public double GetArea()
        {
            return Math.Round(radius * radius * Math.PI,4);
        }
        public override string ToString()
        {
            return $" Circle has radius: {radius}, color: {color}, Area: { GetArea()}dvdt.";
        }

    }
}
