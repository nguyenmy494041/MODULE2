using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace Bai6_interface
{
    class SoSanhLopHinhHoc
    {
        public static void Main()
        {
            Circle[] circles = new Circle[4];
            circles[0] = new Circle(3.6);
            circles[1] = new Circle();
            circles[2] = new Circle("red", true, 4.5);
            circles[3] = new Circle("blue", true, 8.5);

            Console.WriteLine("Pre-sorted:");
            foreach (Circle circle in circles)
            {
                Console.WriteLine(circle);
            }

            IComparer<Circle> circleComparator = new ClassIComparer();
            Array.Sort(circles, circleComparator);

            Console.WriteLine("After-sorted:");
            foreach (Circle circle in circles)
            {
                Console.WriteLine(circle);
            }
        }
    }
    class ClassIComparer : IComparer<Circle>
    {  

        public int Compare( Circle c1 ,  Circle c2)
        {
            if (c1.Radius> c2.Radius) return 1;
            else if (c1.Radius < c2.Radius) return -1;
            else return 0;
        }
    }
    
}
