using System;
namespace Bai2
{
    public static class SumInGivenColumn
    {
        public static void Main()
        {
            int column;
            Console.Write("Enter the rows: ");
            int row = FindMininArray.enterSize();
            Console.Write("Enter the colums: ");
            int col = FindMininArray.enterSize();
            float[,] array = generateArray2waybykeyboard(row, col);
            FindLargestElementInArray.printArray2Way(array);
            do
            {
                Console.WriteLine("Enter the column to sum: ");
                column = int.Parse(Console.ReadLine());
                if (column < 0 || column >= col)
                {
                    Console.WriteLine($"The colomn of size is from 0 to {col - 1}: ");
                }
            }
            while (column < 0 || column >= col);
            float sum = sumInGivenColumn(array, column);
            Console.WriteLine($"Sum in given {column} is: {sum}");
        }
        public static float[,] generateArray2waybykeyboard(int row, int col)
        {
            float[,] arr = new float[row, col];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Enter element in row {i}, column {j} position: ");
                    arr[i, j] = float.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            }
            return arr;
        }
        public static float sumInGivenColumn(float[,] arr, int col)
        {
            float sum = 0;
            for (byte i = 0; i < arr.GetLength(0); i++)
            {
                sum += arr[i, col];
            }
            return sum;
        }

    }
}