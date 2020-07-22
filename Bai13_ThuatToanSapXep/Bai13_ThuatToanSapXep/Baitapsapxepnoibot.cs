using System;
using System.Collections.Generic;
using System.Text;

namespace Bai13_ThuatToanSapXep
{
    class Baitapsapxepnoibot
    {
        static int[] remove(int[] array, int index)
        {
            for (int j = index; j < array.Length - 1; j++)
            {
                array[index] = array[index + 1];
            }
            Array.Resize(ref array, array.Length - 1);
            return array;
        }
        static void Main()
        {
            Random rnd = new Random();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 5);
                Console.Write(array[i]+"  ");
            }
            Console.WriteLine();
            array =  remove(array, 8);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 5);
                Console.Write(array[i] + "  ");
            }
            //for (int i = 0; i < array.Length; i++)
            //{
            //    bool check = true;
            //    for (int j = 0; j < i; j++)
            //    {

            //        if (array [j] == array[i])
            //        {
            //            check = false;

            //        }

            //    }
            //    if (check)
            //    {
            //        int count = 1;
            //        for (int k = i + 1; k < array.Length; k++)
            //        {
            //            if (array[k] == array[i])
            //            {
            //                count++;
            //            }
            //        }
            //        Console.WriteLine($"{array[i]}: {count} lan.");
            //    }
            //}
            while (array.Length >= 1)
            {
                int count = 1;bool check = true;
                while (check)
                {
                  
                    check = false;
                    for (int i = 1; i < array.Length; i++)
                    {

                        if (array[i] == array[0])
                        {
                            count++;
                            remove(array, i);
                            check = true;
                        }

                    }
                }
              
                Console.WriteLine($"{array[0]}: {count} lan.");
                int temp = array[0];
                array[0] = array[array.Length - 1];
                array[array.Length - 1] = temp;
                Array.Resize(ref array, array.Length - 1);
            }
                
        }
    }

    
}
