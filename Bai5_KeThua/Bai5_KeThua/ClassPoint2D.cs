using System;
using System.Collections.Generic;
using System.Text;

namespace Bai5_KeThua
{
    class ClassPoint2D
    { public static void Main()
        {
            Point3D A = new Point3D(2.5f, 6.5f);
            A.SetZ(2.5f);
           Console.WriteLine( A.ToString());
            Console.WriteLine(A.GetXYZ().ToString());
        }
    }
    class Point2D
    {
        private float x = 0.0f;
        private float y = 0.0f;
        public Point2D()
        {

        }
        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public float GetX()
        {
            return x;
        }
        public void SetX(float _x)
        {
            x = _x;
        }
        public float GetY()
        {
            return y;
        }
        public void SetY(float _y)
        {
            y = _y;
        }
        public float[] GetXY()
        {
            float[] arr = { x, y };
            return arr;
        }
        public void SetXY(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
    class Point3D : Point2D
    {
        private float z = 0.0f;
        public float GetZ()
        {
            return z;
        }
        public void SetZ(float _z)
        {
            z = _z;
        }
        public Point3D(float x, float y) : base(x, y)
        {

        }
        public Point3D()
        {

        }
        public float[] GetXYZ()
        {
            float[] arr = { GetX(), GetY(), z };
            return arr;
        }

        public void SetXYZ(float _x, float _y, float _z)
        {
            SetXY(_x, _y);
            z = _z;
        }
        public override string ToString()
        {
            return $"({ GetX()}, { GetY()}, {z})" ;
        }
    }
}
