using System;
using System.Collections.Generic;
using System.Text;

namespace Bai6_interface
{
    class ClassResizeable
    { public static void Main()
        {
            RezizeCircle[] circles = new RezizeCircle[3];
            circles[0] = new RezizeCircle(5.4);
            circles[1] = new RezizeCircle();
            circles[2] = new RezizeCircle("indigo", false, 5.5);
            Random rnd = new Random();
            var percent = rnd.Next(1, 100);
            Console.WriteLine("Pre-sorted:");
            foreach (RezizeCircle circle in circles)
            {
                Console.WriteLine(circle);
            }
            foreach (RezizeCircle circle in circles)
            {
                circle.Resize(percent);
            }
            Console.WriteLine("percent: " + percent);
            Console.WriteLine("After-sorted:");
            foreach (RezizeCircle circle in circles)
            {
                Console.WriteLine(circle);
            }

        }
    }
    public interface IResizeable
    {
        public void Resize(double percent);
    }
      class RezizeCircle : Circle, IResizeable
    {

        public RezizeCircle() { }
        public RezizeCircle(double radius) : base(radius) { }
        public RezizeCircle(string color, bool filled, double radius) : base(color, filled, radius) { }

        public void Resize(double percent)
        {
            Radius = Radius + Radius * percent / 100;
        }
    }
}
