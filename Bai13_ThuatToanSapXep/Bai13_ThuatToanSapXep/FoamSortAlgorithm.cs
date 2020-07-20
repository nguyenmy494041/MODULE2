using System;

namespace Bai13_ThuatToanSapXep
{
   public class FoamSortAlgorithm
    {
        static void Main(string[] args)
        {
            bool result;
            int number;
            do
            {
                System.Console.WriteLine(" enter Size: "); ;
               
                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result || number < 1 || number > 25);
            int[] array = CreateIntArray(number);
            Console.WriteLine("Array before: ");
            PrintArray(array);
            
            Console.WriteLine("Array after: ");
            PrintArray(BubbleSort(array));
        }

        static int[] BubbleSort(int[] arr)
        {
            int N = arr.Length;
            for (int i = 0; i < N - 1 ; i++)
            {
                bool check = false;
                for (int j = 0; j < N -1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        
                       int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        check = true;
                    }
                }
                if (check == false)
                    break;
            }
            return arr;
        }
       public static void PrintArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] +"  ");
            }
            Console.WriteLine();
        }
       public static int[] CreateIntArray(int size)
        {
            Random rnd = new Random();
            int[] arr = new int[size];
            for (int i =0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-20, 30);
            }
            return arr;
        }
    }
}
