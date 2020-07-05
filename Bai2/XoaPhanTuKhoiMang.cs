using System;
namespace Bai2
{
    public class RemoveElemnetFromArray
    {
        public static void Main()
        {
            string[] array = { "12", "messi", "7", "ronaldo", "22", "kaka", "7", "pele", "henry", "7" };
            Console.Write("Array before: ");
            Console.WriteLine(AddElemnentToArray.printStringArray(array));
            Console.WriteLine("Enter value: ");
            string value = Console.ReadLine();
            Console.Write($"Array after: ");
            Console.WriteLine(AddElemnentToArray.printStringArray(removeElemnetFromArray(array, value)));

        }
        public static string[] removeElemnetFromArray(string[] arr, string value)
        {
            int index, count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == value)
                {
                    count++;
                    index = i;
                    for (int k = index; k < arr.Length - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }
                }
            }
            if (count > 1) count--;
            Array.Resize(ref arr, arr.Length - count);
            return arr;
        }
    }

}