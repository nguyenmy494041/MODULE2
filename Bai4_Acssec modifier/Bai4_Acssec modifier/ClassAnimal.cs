using System;
using System.Collections.Generic;
using System.Text;

namespace Bai4_Acssec_modifier
{
    public class ClassAnimal
    { public static void Main()
        {
            CatMuop cat = new CatMuop("20kg", "1.5", "kitty","den do");
            
            cat.PrintInfo();
            //Animal dog = new Animal("30kg", "3.1");
        }
    }
    public abstract class Animal
    {
        protected string Weight { get; set; }
        protected string Height { get; set; }

        public Animal(string weight, string height)
        {
            this.Weight = weight;
            this.Height = height;
        }
        public abstract void PrintInfo();
    }
    abstract class Cat : Animal
    {
        private string Name { get; set; }
        public Cat(string weight, string height, string name)
        : base(weight, height)
        {
            this.Name = name;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Weight : {this.Weight}  \t Height: {this.Height}  \t  Name: {this.Name}");
        }

        public abstract void SayHello();
    }

    class CatMuop : Cat
    {
        private String MauVan;
        public CatMuop(string weight, string height, string name, string mauVan) : base (weight, height, name)
        {
            MauVan = mauVan;
        }

        public override void SayHello() {
            Console.WriteLine("Hello world");
        }
            
    }
}
