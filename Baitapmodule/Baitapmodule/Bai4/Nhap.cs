using System;
using System.Collections.Generic;
using System.Text;

namespace Baitapmodule.Bai4
{
    class Nhap
    {
        static void Main()
        {
           int number = CreateInteger("number",10,35);
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(i);
            }
        }
        static int CreateInteger(string str, int? min = null, int? max = null)
        {
            int num; bool result;
            Console.WriteLine($"Enter {str}: ");
            result = int.TryParse(Console.ReadLine(), out num);
            if (min.HasValue)
            {
                if (max.HasValue)
                {
                    while (!result || num < min.Value || num > max.Value)
                    {
                        Console.WriteLine($"Enter again new {str} from {min.Value} to {max.Value}: ");
                        result = int.TryParse(Console.ReadLine(), out num);
                    }
                }
                else
                {
                    while (!result || num < min.Value)
                    {
                        Console.WriteLine($"Enter again new {str} greater than or equal to {min.Value}: ");
                        result = int.TryParse(Console.ReadLine(), out num);
                    }
                }
            }           
            else
            {
                while (!result)
                {
                    Console.WriteLine($"Enter again new  {str}: ");
                    result = int.TryParse(Console.ReadLine(), out num);
                }
            }
            return num;
        }
    }
}
