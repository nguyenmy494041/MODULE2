using System;
using System.Collections.Generic;
using System.Text;

namespace Baitap1
{
     public class CreateMatrix
    {
        public static int[,] CreateMatrixx()
        {
            bool result;
            int number;
            do
            {
                Console.WriteLine("Enter number: ");
                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result || number < 2 || number > 20);
                      
           
            int[,] matrix = new int[number, number];
            Random rnd = new Random();
            for(int i =0; i< matrix.GetLength(0); i++)
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
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static double SumtheEvenNumber(int[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   if(matrix[i,j] % 2 == 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                
            }
            return sum;
        }

        public static double SumValuesontheMainDiagonal(int[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }
        public static double SumValuesontheSubDiagonal(int[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, matrix.GetLength(0)-1-i];
            }
            return sum;
        }
        public static double SumValuesontheBoundary(int[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, 0];
                sum += matrix[i, matrix.GetLength(0) - 1];
            }
            for (int i = 1; i < matrix.GetLength(0)-1; i++)
            {
                sum += matrix[0, i];
                sum += matrix[matrix.GetLength(0) - 1,i];
            }
            return sum;
        }
        public static void PrintLowerTriangle(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintMaOnTriangle(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j< i; j++)
                {
                    Console.Write($"   ");
                }
                for (int j = i; j < matrix.GetLength(0); j++)
                {
                   
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
