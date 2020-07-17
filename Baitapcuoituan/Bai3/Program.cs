using System;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            int number;
            int rows = CreateNumberIsInteger("rows");
            int cols = CreateNumberIsInteger("cols");

            int[,] matrix = CreateMatrix(rows, cols);
            Console.WriteLine($"Implement matrix {rows} x {cols}: ");
            Console.WriteLine();
            Print_IntMatrix(matrix);
            Console.WriteLine();
           
            do
            {
                System.Console.Write("Enter V value: ");
                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result || number < 20 || number > 60);
            int V = number;
            Console.WriteLine("Matric V");
            Print_StringMatrix(MatrixV(V, matrix));
            Console.WriteLine("Matix bow of 5:");
            Print_StringMatrix(MatrixBowOf5(matrix));
            Console.WriteLine("Matrix convert: ");
            Print_IntMatrix(ConvertMatrix(matrix));

        }




        public static int CreateNumberIsInteger(string str)
        {
            bool result;
            int number;
            do
            {
                System.Console.Write($" Enter {str}: ");
                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result || number < 2 || number > 20);
            return number;
        }
        public static int[,] CreateMatrix(int row, int col)
        {
            Random rnd = new Random(); 
            int[,] matrix = new int[row, col];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(20, 60);
                }
            }
            return matrix;
        }
        public static void Print_IntMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j =0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] +" ");
                }
                Console.WriteLine();
            }
        }
        public static string[,] MatrixV(int V, int[,] matrix)
        {
            string[,] result = new string[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == V)
                    {
                        result[i, j] = $"{V}";
                    }else
                    {
                        result[i, j] = "* ";
                    }
                }
                
            }
            return result;
        }
        public static void Print_StringMatrix(string[,] matrix)
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
        public static string[,] MatrixBowOf5(int[,] matrix)
        {
            string[,] result = new string[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 5 == 0)
                    {
                        result[i, j] = $"{matrix[i, j]}";
                    }
                    else
                    {
                        result[i, j] = "* ";
                    }
                }

            }
            return result;
        }
        public static int[,] ConvertMatrix(int[,] matrix)
        {
            int[,] result = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for(int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrix[j, i];
                }
            }
            return result;
        }


    }
}
