using System;
namespace Bai2
{
    public static class FindMininArray
    {
        public static void Main()
        {
            int size = enterSize();
            float[] array = generateArrayByKeyboard(size);
            Console.WriteLine($"Min of Array: {findMin(array)}");
        }
        public static float[] generateArrayByKeyboard(int size = 8)
        {
            int count = 0;
            float[] array = new float[size];
            while (count < size)
            {
                Console.WriteLine($"Enter the {count + 1} element: ");
                array[count] = float.Parse(Console.ReadLine());
                count++;
            }
            return array;
        }
        public static int enterSize()
        {
            int size;
            do
            {
                Console.WriteLine("Enter size: ");
                size = int.Parse(Console.ReadLine());
                if (size < 1 || size > 30)
                {
                    Console.WriteLine(" The value of size is from 1 to 30");
                }

            }
            while (size < 1 || size > 30);
            return size;
        }
        public static float findMin(float[] arr)
        {
            float min = arr[0];
            for (byte i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
    }
}