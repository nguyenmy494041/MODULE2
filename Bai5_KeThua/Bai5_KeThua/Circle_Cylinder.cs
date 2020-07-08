using System;

namespace Bai5_KeThua
{
    class Circle_Cylinder
    {
        static void Main(string[] args)
        {
            Cylinder tru = new Cylinder("yellow", true, 4.5, 6);
            Console.WriteLine(tru.GetVolume());
            Console.WriteLine(tru.ToString());
        }
    }
    class Cylinder : Circle
    {
        private double height = 5.0;
        public double Height
        {
            get => height;
            set => height = value;
        }
        public Cylinder()
        {

        }
        public Cylinder(double height)
        {
            this.height = height;
        }
        public Cylinder(string _color, bool _filled, double _radius, double _height) : base(_color, _filled, _radius)
        {
            this.height = _height;
        }
        public double GetVolume()
        {
            return Math.Round(height * GetArea(),5);
        }
        public override string ToString()
        {
            return $"Volume: {GetVolume()}, {base.ToString()}";
        }

    }
}
