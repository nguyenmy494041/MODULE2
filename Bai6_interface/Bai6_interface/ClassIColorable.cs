using System;
using System.Collections.Generic;
using System.Text;

namespace Bai6_interface
{
    class ClassIColorable
    {
        public static void Main()
        {
            Shape[] shapes = new Shape[3];
            shapes[0] = new Shape();
            shapes[2] = new Circle("yellow", false, 3.5);
            shapes[1] = new Rectangle("blue", false, 4.5, 8.2);
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
                if (shape is Rectangle)
                {
                    IColorable temp = (Rectangle)shape;
                    temp.HowColor();

                }
            }

        }
    }
    public interface IColorable
    {
        public void HowColor();
    }
   


}
