using System;
using System.Collections.Generic;
using System.Text;

namespace KiemtraMODULE.Bai1
{
    class Program
    {
       
        static void Main()
        {
            int[,] matrix = CreateMatrix();
            Console.WriteLine("Matrix: ");
            PrintMatrix(matrix);
            Console.WriteLine($"\nValue max in matrix: {FindMax(matrix)}");
            Console.WriteLine("\nMatrix Lower Triangle: ");
            ShowMatrix(matrix);
        }
       static int CreateInterger(string st)
        {
            int num;
            Console.WriteLine($"Enter number {st} : ");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out num);
            while (!result || num < 2)
            {
                Console.WriteLine($"Enter again number {st}: ");
                str = Console.ReadLine();
                result = int.TryParse(str, out num);
            }
            return num;
        }
        static int[,] CreateMatrix()
        {
            int n = CreateInterger("n");
            int m = CreateInterger("m");
            int[,] matrix = new int[n, m];
            Random rd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rd.Next(10, 99);
                }
            }
            return matrix;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int FindMax(int[,] matrix)
        {
            int max = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if( matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                
            }
            return max;
        }
        public static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
