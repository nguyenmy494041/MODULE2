using System;
using System.Collections.Generic;
using System.Text;

namespace Bai12Timkiem
{
    class StringIncreased
    {
        static void Main()
        {
            Console.WriteLine("Enter string: ");
            string str = Console.ReadLine();
            string result = findStringIncreate(str);
            Console.WriteLine();
            Console.Write("Ascending string has the largest length: ");
            Console.WriteLine(result);
        }

        static string findStringIncreate(string str)
        {

            List<char> substring = new List<char>();
            List<string> sub = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                substring.Add(str[i]);
                for (int j = i+1; j < str.Length; j++)
                {
                    if (((int)str[i]) < ((int)str[j]))
                    {
                        substring.Add(str[j]);
                        i = j;
                    }
                }
                string str1 = "";
                for (int k = 0; k < substring.Count; k++)
                {
                    str1 += substring[k];
                }
                sub.Add(str1);                
                substring.Clear();
            }
           
            string result = sub[0];
            foreach (string item in sub)
            { 
                if (result.Length < item.Length)
                {
                    result = item;
                }
            }
            return result;
        }
    }
}
