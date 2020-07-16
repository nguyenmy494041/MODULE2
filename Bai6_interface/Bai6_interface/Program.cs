using System;

namespace Bai6_interface
{
    class Program
    {
        static void Main(string[] args)
        {
            AAnimal[] animals = new AAnimal[2];
            animals[1] = new Tiger();
            animals[0] = new Chicken();
            foreach(AAnimal animal in animals)
            {
                Console.WriteLine(animal.MakeSound());
                if (animal is Chicken)
                {
                    IEdible edibler = (Chicken)animal;
                    Console.WriteLine($"\t {edibler.AHowToEat()}");
                }
            }
            AFruit[] fruits = new AFruit[2];
            fruits[0] = new Orange();
            fruits[1] = new Apple();
            foreach(AFruit fruit in fruits)
            {
                Console.WriteLine(fruit.AHowToEat());
            }


        }
    }
    public interface IEdible
    {
        public string AHowToEat();
    }

    public abstract class AAnimal
    {
        public abstract string MakeSound();
    }

    public abstract class AFruit : IEdible
    {
        public abstract string AHowToEat();
    }

    public class Chicken : AAnimal, IEdible
    {
        public string AHowToEat()
        {
            return "could be fried";
        }
        public override string MakeSound()
        {
            return "Chicken: cluck-cluck-cluck!";
        }

    }
    public class Tiger: AAnimal
    {
        public override string MakeSound()
        {
            return "Tiger: meo-meo-meo!";
        }

    }
    public class Orange: AFruit
    {
        public override string AHowToEat()
        {
            return "Orange could be juiced";
        }
    }
    public class Apple : AFruit
    {
        public override string AHowToEat()
        {
            return "Apple could be slided";
        }
    }

}
