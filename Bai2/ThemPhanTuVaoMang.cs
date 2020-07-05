using System;
namespace Bai2
{
    public class AddElemnentToArray
    {
        public static void Main()
        {
            string[] array = { "12", "messi", "7", "ronaldo", "22", "kaka" };
            Console.Write("Array before: ");
            Console.WriteLine(printStringArray(array));
            Console.WriteLine("Enter value: ");
            string value = Console.ReadLine();
            Console.WriteLine("Enter index: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine($"Array after: ");
            Console.WriteLine(printStringArray(addElemnetToArray(array, value, index)));


        }
        public static string[] addElemnetToArray(string[] array, string value, int index)
        {
            if (index < 0 || index > array.Length)
            {
                Array.Resize(ref array, 1);
                array[0] = "Can not add element to array";
                return array;
            }
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = value;
            return array;
        }
        public static string printStringArray(string[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + ",  ";
            }
            return str;
        }

    }
}