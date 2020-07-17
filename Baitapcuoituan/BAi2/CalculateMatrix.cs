using System;
using System.Collections.Generic;
using System.Text;

namespace BAi2
{
    class CalculateMatrix
    {
        public static int[,] CreateMatrixx(int number)
        {
          
            int[,] matrix = new int[number, number];
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(10, 90);
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
                    Console.Write($"{matrix[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        public static int[,] Sum2Matrix(int[,] matrix1, int[,] matrix2)
        {

            if (matrix1.GetLength(0) == matrix2.GetLength(0)
                && matrix1.GetLength(1) == matrix2.GetLength(1))
            {
                int[,] matrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return matrix;
            }
            else return null;
        }

        public static int[,] Multiply2Matrix(int[,] matrix1, int[,] matrix2)
        {

            if (matrix1.GetLength(1) == matrix2.GetLength(0)                )
            {
                int[,] matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int k = 0; k< matrix1.GetLength(1); k++)
                    {
                        int j = 0;
                        matrix[i, k] = 0;
                        while (j < matrix1.GetLength(1))
                        {
                            matrix[i, k] += matrix1[i, j] * matrix2[j, k];
                            j++;
                        }
                    }
                }
                return matrix;
            }
            else return null;
        }
    }
}
