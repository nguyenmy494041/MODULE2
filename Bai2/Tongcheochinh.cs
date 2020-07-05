using System;
namespace Bai2
{
    public static class MainTotalDiagonal
    {
        public static void Main()
        {
            int size = FindMininArray.enterSize();
            float sum = 0, sum1 = 0;
            float[,] array = FindLargestElementInArray.GenerateArray(size, size);
            FindLargestElementInArray.printArray2Way(array);
            for (byte i = 0, j = 0; i < array.GetLength(0); i++, j++)
            {
                sum += array[i, j];
            }
            for (int i = 0, j = array.GetLength(0) - 1; i < array.GetLength(0); i++, j--)
            {
                sum1 += array[i, j];
            }
            Console.WriteLine($"Sum the numbers on the main diagonal: {sum}");
            Console.WriteLine($"sum the numbers on the diagonal sub: {sum1}");
        }
    }
}