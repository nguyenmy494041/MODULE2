using System;
using System.Collections.Generic;
using System.Text;

namespace BookMagagementSystem
{
    public class Book:IBooks
    {
        private int id;
        private string name;
        private string publishDate;
        private string author;
        private string language;
        private float averagePrice;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string PublishDate { get => publishDate; set => publishDate = value; }
        public string Author { get => author; set => author = value; }
        public string Language { get => language; set => language = value; }
        public float AveragePrice { get => averagePrice;}

        public void Display()
        {
            Console.WriteLine($"{id}\t{name}\t\t{publishDate}\t\t{author}\t\t{language}\t\t{averagePrice}.");
        }
        public int[] PriceList = new int[5];
        public void Calculate()
        {
            float total = 0;
            foreach(var item in PriceList)
            {
                total += item;
            }
            averagePrice = total / PriceList.Length;
        }
    }
}
