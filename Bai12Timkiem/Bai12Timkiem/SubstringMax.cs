using System;
using System.Collections.Generic;

namespace Bai12Timkiem
{
    class SubstringMax
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input string");
            string str = Console.ReadLine();
            string kq = find(str);
            Console.WriteLine();
            Console.WriteLine(kq);
        }
        static string find(string str)
        {
            string str1;
            List<int> indexs = new List<int>();
            int index = 1;
            for (int i = 0; i < str.Length - 1; i++)
            {

                if (((int)str[i]) < ((int)str[i + 1]))
                {
                    index++;
                    if (i == str.Length - 2)
                    {
                        indexs.Add(index);
                    }
                }
                else
                {
                    indexs.Add(index);
                    index = 1;
                }
            }
            int max = indexs[0], k = 0;
            for (int i = 1; i < indexs.Count; i++)
            {
                if (max < indexs[i])
                {
                    max = indexs[i];
                    k = i;
                }
            }
            if (k != 0)
            {
                int sumindex = 0;
                for (int i = 0; i < k; i++)
                {
                    sumindex += indexs[i];
                }
                return str1 = str.Substring(sumindex, indexs[k]);
            }
            else
            {
                return str1 = str.Substring(0, indexs[0]);
            }
        }
    }
}
