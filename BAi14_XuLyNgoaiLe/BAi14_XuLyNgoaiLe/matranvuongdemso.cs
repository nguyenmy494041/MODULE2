using System;
using System.Collections.Generic;
using System.Text;

namespace BAi14_XuLyNgoaiLe
{
    public class matranvuongdemso
    {
        static void Main()
        {
            int[,] matrix = CreateMatrix2(20);
            PrintMatrix(matrix);
        }
        public static int[,] CreateMatrix(int size = 10)
        {
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i % 2 == 1)
                {
                    matrix[0, i] = matrix[0, i - 1] + 1;
                    for (int l = 0; l <= i; l++)
                    {
                        matrix[l, i] = matrix[0, i] + l;
                        matrix[i, l] = matrix[0, i] + 2 * i - l;

                    }
                }
                else
                {
                    matrix[0, i] = (i + 1) * (i + 1);
                    for (int l = 0; l <= i; l++)
                    {
                        matrix[l, i] = matrix[0, i] - l;
                        matrix[i, l] = matrix[0, i] - 2 * i + l;

                    }
                }
            }
            return matrix;
        }
        public static int[,] CreateMatrix2(int size = 10)
        {
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = (i + 1) * (i + 1) - i;

                for (int j = 0; j <= i; j++)
                {
                    if (i % 2 == 0)
                    {
                        matrix[i, j] = matrix[i, i] - i + j;
                        matrix[j, i] = matrix[i, i] + i - j;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i, i] + i - j;
                        matrix[j, i] = matrix[i, i] - i + j;
                    }

                }
            }
            return matrix;
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 10)
                    {
                        Console.Write($"{matrix[i, j]}   ");
                    }
                    else if (matrix[i, j] < 100)
                    {
                        Console.Write($"{matrix[i, j]}  ");
                    }
                    else
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }

                }
                Console.WriteLine();
            }
        }
    }

}
