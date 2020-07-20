using System;

namespace Bai4
{
    class Program
    {
        private static int[] array;
        static void Main(string[] args)
        {
            int choise = -1;
            while(choise != 5)
            {
                Console.WriteLine("Please input an option:");
                Console.WriteLine("1. Create array. ");
                Console.WriteLine("2. Check for symmetric arrays.");
                Console.WriteLine("3. Array sort."); ;
                Console.WriteLine("4. Find.");
                Console.WriteLine("5. Exit.");
                choise = InputNumber("choise", 1, 5);
              
               switch (choise)
                {
                    case 1:
                        int size = InputNumber("size",2,25);
                        array = CreateArray(size);
                        PrintArray(array);
                        break;
                    case 2:
                        Console.WriteLine(IsSymmetryArray(array));
                        break;
                    case 3:
                        SelectionSort(array);
                        PrintArray(array);
                        break;
                    case 4:
                        if (IsSortArray(array))
                        {
                            int value = InputNumber("value",1, 100);
                            Find(value, array);
                        }
                        else { Console.WriteLine(" Array is not sort."); }
                        break;
                }
                Console.WriteLine();
            }
          
        }

        static int InputNumber(string str,int min, int max)
        {
            bool result;
            int number;
            do
            {
                Console.Write($"Input {str}: ");
                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result || number < min || number > max);
            return number;
        }
        static int[] CreateArray(int size)
        {
            Random rnd = new Random();
            int[] result = new int[size];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = rnd.Next(30, 40);
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
        static void SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min_index = i;
                for (int j = i; j < n; j++)
                {
                    if (array[j] < array[min_index])
                    {
                        min_index = j;
                    }
                }
                int temp = array[i];
                array[i] = array[min_index];
                array[min_index] = temp;
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
