using System;
using System.Collections.Generic;
using System.Text;

namespace KiemtraMODULE.Bai3
{
    public interface IPost
    {
        public string Display();
        public float CalculatorRate();
    }
    class Post : IPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public float AverageRate => CalculatorRate();
        public int[] Rates = new int[4];
        public float CalculatorRate()
        {
            float sum = 0;
            foreach (var item in Rates)
            {
                sum += item;
            }
            return sum / Rates.Length;

        }

        public string Display()
        {
            return $"{Id}\t{Title}\t{Content}\t{Author}\t{AverageRate}";
        }
    }

}
