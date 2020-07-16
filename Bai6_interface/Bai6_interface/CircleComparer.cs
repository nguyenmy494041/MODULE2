using System;
using System.Collections.Generic;
using System.Text;

namespace Bai6_interface
{
    class CircleComparer
    {  public static void Main()
        {
            ComperableCircle[] circles = new ComperableCircle[3];
            circles[0] = new ComperableCircle(5.4);
            circles[1] = new ComperableCircle();
            circles[2] = new ComperableCircle( "indigo", false, 5.5);

            Console.WriteLine("Pre-sorted:");
            foreach (ComperableCircle circle in circles)
            {
                Console.WriteLine(circle);
            }

            //for (var i = 0; i < circles.Length; i++)
            //{
            //    for (var j = 1 + i; j < circles.Length; j++)
            //    {
            //        if(circles[i].CompareTo(circles[j]) > 0)
            //            {
            //            var temp = circles[i];
            //            circles[i] = circles[j];
            //            circles[j] = temp;
            //        }
            //    }
            //}

            Array.Sort(circles);

            Console.WriteLine("After-sorted:");
            foreach (ComperableCircle circle in circles)
            {
                Console.WriteLine(circle);
            }

        }
    }
     class ComperableCircle : Circle, IComparable<ComperableCircle>
    {

        public ComperableCircle() { }
        public ComperableCircle(double radius) : base(radius) { }
        public ComperableCircle(string color, bool filled, double radius) : base( color, filled, radius) { }

        public int CompareTo(ComperableCircle o)
        {
            if (Radius > o.Radius) return 1;
            else if (Radius < o.Radius) return -1;
            else return 0;
        }
    }
    
}
