using System;
using System.Collections.Generic;
using System.Text;

namespace Bai6_interface
{
    class Classkhoihinhhoc
    {
    }
    class Shape
    {
        private string color = "green";
        private bool filled = true;
        public string Color
        {
            get => color;
            set => color = value;
        }
        public bool Filled
        {
            get => filled;
            set => filled = value;
        }
        public Shape()
        {

        }
        public Shape(string _color, bool _filled)
        {
            this.color = _color;
            this.filled = _filled;
        }
        public override string ToString()
        {
            return $"A Shape with color of {color} and {(filled ? "filled" : "not filled")} ";
        }
        public virtual double GetArea()
        {
            return 0;
        }

    }
    class Circle : Shape
    {
        private double radius = 1.0;
        public Circle()
        {

        }
        public Circle(string _color, bool _filled, double _radius) : base(_color, _filled)
        {
            this.radius = _radius;
        }
        public Circle(double _radius)
        {
            this.radius = _radius;
        }
        public double Radius
        {
            get => radius;
            set => radius = value;
        }
        public override double GetArea()
        {
            return Math.Round(radius * radius * Math.PI, 5);
        }
        public double GetPerimeter()
        {
            return Math.Round(2 * radius * Math.PI, 5);
        }
        public override string ToString()
        {
            return $"A Circle with radius= {radius}, which is a subclass of {(base.ToString())}";
        }
    }
    class Rectangle : Shape, IColorable
    {
        private double width = 2.0;
        private double length = 2.0;
        public double Width
        {
            get => width;
            set => width = value;
        }
        public double Length
        {
            get => length;
            set => length = value;
        }
        public Rectangle()
        {

        }
        public Rectangle(double width, double length)
        {
            this.width = width;
            this.length = length;
        }
        public Rectangle(string _color, bool _filled, double width, double length) : base(_color, _filled)
        {
            this.width = width;
            this.length = length;
        }
        public override double GetArea()
        {
            return Math.Round(length * width, 5);
        }
        public double GetPerimeter()
        {
            return Math.Round((length + width) * 2, 5);
        }
        public override string ToString()
        {
            return $"A Rectangle with width= {width} and length= {length}, which is a subclass of {base.ToString()}";
        }

        public void HowColor()
        {
            Console.WriteLine(" Color all four sides. ");
        }
    }

}
