using System;
using System.Collections.Generic;
using System.Text;

namespace Baitapcuoituan
{
   public class Post : IPost
    {
        private int id;
        private string title;
        private string content;
        private string author;
        private float averegeRate;
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string Author { get => author; set => author = value; }
        public float AveregeRate { get => averegeRate;  }
        public List<int> rate = new List<int>();

        public void CalculatorRate()
        {
            if (rate.Count > 0)
            {
                float total = 0.0f;
                foreach (int item in rate)
                {
                    total += item;
                }
                averegeRate = total / rate.Count;
            }
            else averegeRate = 0.0f;
        }

        public void DisPlay()
        {
            Console.WriteLine($"{id}\t\t{title}\t\t{content}\t\t{author}\t\t{rate.Count}\t\t {averegeRate}");
        }
    }
}
