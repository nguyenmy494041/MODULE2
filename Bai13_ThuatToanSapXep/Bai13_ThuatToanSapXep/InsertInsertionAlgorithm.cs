using System;
using System.Collections.Generic;
using System.Text;

namespace Bai13_ThuatToanSapXep
{
    class InsertInsertionAlgorithm
    {
        static void Main()
        {
            bool result;
            int number;
            do
            {
                System.Console.WriteLine(" enter Size: "); ;

                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result || number < 1 || number > 25);
            int[] array = FoamSortAlgorithm.CreateIntArray(number);
            FoamSortAlgorithm.PrintArray(array);
            Console.WriteLine();
            InsertionSort(array);
            FoamSortAlgorithm.PrintArray(array);
        }
        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            //for (int i = 1; i < n; ++i)
            //{
            //    int key = arr[i];
            //    int j = i - 1;

            //    while (j >= 0 && arr[j] > key)
            //    {
            //        arr[j + 1] = arr[j];
            //        j = j - 1;
            //    }
            //    arr[j + 1] = key;
            //}
            for ( int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }
    }


}
