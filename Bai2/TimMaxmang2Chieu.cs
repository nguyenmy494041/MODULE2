using System;
namespace Bai2
{
    public static class FindLargestElementInArray
    {
        public static void Main()
        {
            float[,] array = GenerateArray(8, 5);
            printArray2Way(array);
            float max = array[0, 0];
            int x = 0, y = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        x = i;
                        y = j;
                    }
                }
            }
            Console.WriteLine($"Max: {max} in row: {x + 1}, col: {y + 1}");

        }
        public static float[,] GenerateArray(int row, int col)
        {
            float[,] array = new float[row, col];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(-20, 40);
                }

            }
            return array;
        }
        public static void printArray2Way(float[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + ",  ");
                }
                Console.WriteLine();
            }
        }

    }
}