using System;
using System.Collections.Generic;
using System.Text;

namespace Bai5_KeThua
{
    class ClassMoveablePoint
    {
        public static void Main()
        {
            MoveablePoint diem1 = new MoveablePoint(2, 3);
            diem1.SetX(0);
            diem1.SetY(0);
            diem1.Move().Move().Move();
            Console.WriteLine(diem1.GetXY()[0]);
            Console.WriteLine(diem1.GetY());

        }
    }
    class MoveablePoint : Point2D
    {
        private float xSpeed = 0.0f;
        private float ySpeed = 0.0f;
        public MoveablePoint()
        {

        }
        public MoveablePoint(float xSpeed, float ySpeed)
        {
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
        }
        public float GetxSpeep()
        {
            return xSpeed;
        }
        public void SetxSpeed(float _xSpeed)
        {
            xSpeed = _xSpeed;
        }
        public float GetySpeed()
        {
            return ySpeed;
        }
        public void SetySpeed(float _ySpeed)
        {
            ySpeed = _ySpeed;
        }
        public float[] GetSpeed()
        {
            float[] arr = { xSpeed, ySpeed };
            return arr;
        }
        
        public override string ToString()
        {
            return $"(x, y) = ({GetX()}, {GetY()}); (xSpeed, ySpeed) = ({GetxSpeep()}, {GetySpeed()})";
        }
        public MoveablePoint Move()
        {
            SetX( GetX() + xSpeed) ;
            SetY(GetY() + ySpeed);

            return this;
        }


    }

}
