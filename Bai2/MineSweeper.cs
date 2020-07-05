using System;
namespace Bai2
{
    public class MineSweeper
    {
        public static void Main()
        {
            string[,] arr = taoBangGame();
            Console.WriteLine("ma tran duoc cung cap:");
            inMang2Chieu(arr);
            Console.WriteLine("ma tran thu duoc:");
            string[,] brr = mangThuDuoc(arr);
            inMang2Chieu(brr);


        }
        // tao mang game
        public static string[,] taoBangGame(byte size = 8)
        {
            string[,] arr = new string[size, size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[rnd.Next(0, size - 1), rnd.Next(0, size - 1)] = "*";
            }

            int length = arr.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (arr[i, j] != "*")
                    {
                        arr[i, j] = ".";
                    }
                }
            }
            return arr;
        }
        public static void inMang2Chieu(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static string[,] mangThuDuoc(string[,] arr)
        {
            Random rnd = new Random();
            int length = arr.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (arr[i, j] != "*")
                    {
                        arr[i, j] = $"{rnd.Next(0, 3)}";
                    }
                }
            }
            return arr;
        }
    }
}