using System;
using System.Collections.Generic;
using System.Text;

namespace Bai5_KeThua
{
    class ClassTriangle
    {
        public static void Main()
        {
            Triangle triangle = new Triangle(7, 4, 15);

            Console.WriteLine(triangle.ToString());


        }
    }
    class Triangle : Shape
    {

        private double size1 = 1.0;
        private double size2 = 1.0;
        private double size3 = 1.0;
        public double Size1
        {
            get => size1;
            set => size1 = value;
        }
        public double Size2
        {
            get => size2;
            set => size2 = value;
        }
        public double Size3
        {
            get => size3;
            set => size3 = value;
        }
        public Triangle()
        {

        }
        public Triangle(double _size1, double _size2, double _size3)
        {
            size1 = _size1;
            size2 = _size2;
            size3 = _size3;
        }
        public bool IsTriangle()
        {
            if (size1 + size2 > size3 && size2 + size3 > size1 && size1 + size3 > size2
                && size1 > 0 && size2 > 0 && size3 > 0)
            { return true; }

            return false;
        }
        public string GetArea()
        {
            if (IsTriangle())
            {
                double p = (size3 + size2 + size1) / 2;
                double S = Math.Sqrt(p * (p - size1) * (p - size2) * (p - size3));
                return $" {S} dvdt";
            }
            else return $"not exit triangle";
        }
        public string GetPerimeter()
        {
            if (IsTriangle())
            {
                double p = (size3 + size2 + size1);

                return $" {p}dv";
            }
            else return $"not exit triangle";
        }


        public string ClassificationTriangles()
        {
            if (IsTriangle())
            {
                if (size1 == size2 && size2 == size3)
                {
                    return "tam giac deu";
                }
                if (size1 == size2 || size2 == size3 || size3 == size1)
                {
                    return "tam giac can";
                }
                if (size1 * size1 == size2 * size2 + size3 * size3 ||
                    size3 * size3 == size2 * size2 + size1 * size1 ||
                    size2 * size2 == size1 * size1 + size3 * size3)
                {
                    return "tam giac vuong";
                }
                return "tam giac thuong";

            }
            else return "not exit triangle";
        }
        public override string ToString()
        {
            if (IsTriangle()) return $" IsTriangle, is {ClassificationTriangles()}, Area: {GetArea()}, Perimeter: {GetPerimeter()}";
            return "not exit triangle";
        }
    }
}
