using System;
using System.Collections.Generic;
using System.Text;

namespace BAi7_CleanCode
{
    class ClassTachmanguon
    {
        static void Main(string[] args)
        {
            double result = CylinderDemo.TotalArea(2, 4);
            Console.WriteLine(result);
        }
    }
    class CylinderDemo
    {

        public static double GetVolume(int radius, int height)
        {
            double baseArea = Math.PI * radius * radius;
            double perimeter = 2 * Math.PI * radius;
            double volume = perimeter * height + 2 * baseArea;
            return volume;
        }
        public static double BottomArea(double radius)
        {
            return Math.PI * radius * radius;
        }
        public static double AroundArea(double radius, double height)
        {
            return radius * height;
        }
        public static double TotalArea(double radius, double height)
        {
            return BottomArea(radius) * 2 + AroundArea(radius, height);
        }
    }
}