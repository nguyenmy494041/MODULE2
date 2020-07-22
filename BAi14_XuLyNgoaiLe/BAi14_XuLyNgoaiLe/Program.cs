using System;

namespace BAi14_XuLyNgoaiLe
{
    // Mang sap xep so chan so le.
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = CreateArray(25);
            PrinArray(array);
            Console.WriteLine();
            Sort(array);
            PrinArray(array);
            Console.WriteLine();
            SortOddEven(array);
            PrinArray(array);

        }
        static int[] CreateArray(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 30);
            }
            return array;
        }
        static void Sort(int[] arr)
        {
            int i, j, temp;
            int n = arr.Length;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                       
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }                
                if (swapped == false)
                    break;
            }
        }
        static void PrinArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
                
            }
            Console.WriteLine();
        }
        static int[] swappedElement(int[] array, int index)
        {
            int temp = array[index];
            for (int i = index; i < array.Length -1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = temp;
            return array;
        }
        static int[] SortOddEven(int[] array)
        {
            for (int i  = array.Length -1 ; i >= 0; i--)
            {
                if(array[i]%2 == 1)
                {
                    swappedElement(array, i);
                }
            }
            return array;
        }



    }
}
