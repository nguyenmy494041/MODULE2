using System;
using System.Collections.Generic;
using System.Text;

namespace Bai13_ThuatToanSapXep
{
    class SelectionSortAlgorithm
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
            SelectionSort(array);
            FoamSortAlgorithm.PrintArray(array);

        }
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n; i++)
            {
                int min_index = i;
                for (int j = i; j < n; j++)
                {
                    if (arr[min_index]> arr[j])
                    {
                        min_index = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[min_index];
                arr[min_index] = temp;
            }
        }

    }



}
