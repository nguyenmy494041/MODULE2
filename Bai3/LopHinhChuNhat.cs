using System;
namespace Bai3
{
    public class LopRectangle
    {
        public static void Main()
        {
            Rectangle rectangle = new Rectangle(30, 20);

            Console.WriteLine("Your Rectangle \n" + rectangle.Display());
            Console.WriteLine("Perimeter of the Rectangle: " + rectangle.GetPerimeter());
        }
    }

    public class Rectangle
    {
        double width, height;

        public Rectangle()
        {
        }

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double GetArea()
        {
            return this.width * this.height;
        }

        public double GetPerimeter()
        {
            return (this.width + this.height) * 2;
        }

        public string Display()
        {
            return "Rectangle{" + "width=" + width + ", height=" + height + "}";
        }

    }

}