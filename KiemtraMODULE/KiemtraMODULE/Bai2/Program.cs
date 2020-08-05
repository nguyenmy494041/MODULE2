using System;
using System.Collections.Generic;
using System.Text;

namespace KiemtraMODULE.Bai2
{
    class Program
    {
        private static int[] array;
        static void Main(string[] args)
        {
            int choise = -1;
            while (choise != 5)
            {
                Console.WriteLine("Please input an option:");
                Console.WriteLine("1. Create array. ");
                Console.WriteLine("2. Check for symmetric arrays.");
                Console.WriteLine("3. Array sort."); ;
                Console.WriteLine("4. Find.");
                Console.WriteLine("5. Exit.");
                choise = CreateChoise();
                while(array == null && choise != 1)
                {
                    choise = CreateChoise();
                }
                Console.Clear();
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("\n - - Create new array - - \n");
                        array = CreateArray();
                        Console.WriteLine("Print array: \n");
                        PrintArray(array);
                        break;
                    case 2:
                        Console.WriteLine($"\nArray is symmetry: {IsSymmetryArray(array)}");
                        break;
                    case 3:
                        Console.WriteLine("Array after sort:\n");
                        BubbleSort(array);
                        PrintArray(array);
                        break;
                    case 4:
                        if (IsSortArray(array))
                        {
                            Console.WriteLine("Find out where the value is in the array. \n");
                            int value = CreateInterger("value");
                            Console.WriteLine();
                            Find(value, array);
                        }
                        else { Console.WriteLine(" Array is not a rising array, select 3 to sort the array"); }
                        break;
                    case 5:
                        Console.WriteLine(" \n- - - - EXIT - - - - ");
                        break;
                }
                Console.WriteLine();
            }
        }
        static int CreateChoise()
        {
            int num;
            Console.Write($"Enter choise : ");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out num);
            while (!result || num < 1 || num > 5)
            {
                Console.Write($"Enter again choise: ");
                str = Console.ReadLine();
                result = int.TryParse(str, out num);
            }
            return num;
        }

        static int CreateInterger(string st)
        {
            int num;
            Console.Write($"Enter number {st} : ");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out num);
            while (!result || num < 2)
            {
                Console.Write($"Enter again number {st}: ");
                str = Console.ReadLine();
                result = int.TryParse(str, out num);
            }
            return num;
        }
        static int[] CreateArray()
        {
            int size = CreateInterger("size");
            Random rnd = new Random();
            int[] result = new int[size];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = rnd.Next(10, 99);
            }
            return result;
        }
        static bool IsSymmetryArray(int[] array)
        {
            bool result = true;
            int fist = 0, last = array.Length - 1;
            while (fist < last)
            {
                if (array[fist] != array[last]) result = false;
                fist++;
                last--;
            }
            return result;
        }
        static void BubbleSort(int[] arr)
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
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
        }
        static bool IsSortArray(int[] array)
        {
            bool check = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    check = false;
                }
            }
            return check;
        }
        static void Find(int value, int[] array)
        {
            int first = 0, last = array.Length - 1, result = -1;
            while (first < last)
            {
                int mid = (first + last) / 2;
                if (array[mid] == value)
                {
                    result = mid;
                    break;
                }
                else if (array[mid] > value) { last = mid - 1; }
                else { first = mid + 1; }
            }
            if (result == -1) { Console.WriteLine("Not find! "); }
            else { Console.WriteLine($"{value} is element {result}."); }

        }
    }
}
