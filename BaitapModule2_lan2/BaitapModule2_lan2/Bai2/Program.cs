using System;
using System.Collections.Generic;
using System.Text;

namespace BaitapModule2_lan2.Bai2
{
    class Program
    { 
        static void Main()
        {
            int n = CreateInteger("n", 2, 25);
            int m = CreateInteger("m", 2, 25);
            int k = CreateInteger("k", 2, 25);
            int[,] matrixA = CreateMatrix(n, m);
            Console.WriteLine("Matrix A:");
            PrintMatrix(matrixA);
            int[,] matrixB = CreateMatrix(m, k);
            Console.WriteLine("Matrix A:");
            PrintMatrix(matrixB);
            Console.WriteLine("\nMatrix C = A x B:");
            int[,] matrixC = MultipleMatrix(matrixA, matrixB);
            PrintMatrix(matrixC);

        }
        
        static int[,] CreateMatrix(int n, int m)
        {
            Random rn = new Random();
            int[,] matrix = new int[n, m];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rn.Next(10, 50);
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
                    Console.Write(matrix[i, j]+"  "); 
                }
                Console.WriteLine();
            }
        }
        static int[,] MultipleMatrix(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(1) == matrixB.GetLength(0))
            {
                int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
                for (int i = 0; i < matrixC.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixC.GetLength(1); j++)
                    {
                        int sum = 0;
                        for (int l = 0; l < matrixA.GetLength(1); l++)
                        {
                            sum += matrixA[i, l] * matrixB[l, j];
                        }
                        matrixC[i, j] = sum;
                    }                    
                }
                return matrixC;
            }
            return null;
        }
        static int CreateInteger(string str, int? min = null, int? max = null)
        {
            int num; bool result;
            Console.WriteLine($"Enter {str}: ");
            result = int.TryParse(Console.ReadLine(), out num);
            if (min.HasValue)
            {
                if (max.HasValue)
                {
                    while (!result || num < min.Value || num > max.Value)
                    {
                        Console.WriteLine($"Enter again new {str} from {min.Value} to {max.Value}: ");
                        result = int.TryParse(Console.ReadLine(), out num);
                    }
                }
                else
                {
                    while (!result || num < min.Value)
                    {
                        Console.WriteLine($"Enter again new {str} greater than or equal to {min.Value}: ");
                        result = int.TryParse(Console.ReadLine(), out num);
                    }
                }
            }
            else
            {
                while (!result)
                {
                    Console.WriteLine($"Enter again new  {str}: ");
                    result = int.TryParse(Console.ReadLine(), out num);
                }
            }
            return num;
        }


    }
}
