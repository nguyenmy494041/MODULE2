using System;
using System.Collections.Generic;
using System.Text;

namespace Bai4_Acssec_modifier
{
    public class Car
    {
        public static void Main()
        {
            ClassCar car1 = new ClassCar("Mazda 3", "Skyactiv 3");
            Console.WriteLine(ClassCar.numberOfCars);
            ClassCar car2 = new ClassCar("Mazda 6", "Skyactiv 6");
            Console.WriteLine(ClassCar.numberOfCars);
            Console.ReadLine();

        }
    }
    public class ClassCar
    {
        private string name;
        private string engine;
        public static int numberOfCars;
        public ClassCar(string name, string engine)
        {
            this.name = name;
            this.engine = engine;
            numberOfCars++;
        }

    }
}
