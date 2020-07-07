using System;
namespace Bai3
{

    public class PanPan
    {
        public static void Main()
        {
            Pan pan1 = new Pan();
            pan1.Speed = 3;
            pan1.Color = "yellow ";
            pan1.Radius = 10;
            pan1.On = true;
            Pan pan2 = new Pan();
            pan2.Speed = 2;
            Console.WriteLine("PAn1: " + pan1.ToString());
            Console.WriteLine("PAN2: " + pan2.ToString());



        }
    }

    public class Pan
    {
        const int SLOW = 1;
        const int MEDIUM = 2;
        const int FAST = 3;
        private bool on = false;
        private double radius = 5;
        private string color = "blue";

        private int speed = SLOW;
        public int Speed
        {
            get => speed;
            set => speed = value;
        }
        public double Radius
        {
            get => radius;
            set => radius = value;
        }
        public bool On
        {
            get => on;
            set => on = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
        public Pan()
        {

        }
        public string sspeed(int x)
        {
            if (x == 1) return "Slow";
            else if (x == 2) return "MEDIUM";
            else return "FAST";
        }
        public override string ToString()
        {
            if (on)
            {
                return $" speed: {sspeed(speed)}, color: {color}, radius: {radius}, fan is on";
            }
            else { return $"color: {color}, radius: {radius}, fan is off"; }
        }



    }
}