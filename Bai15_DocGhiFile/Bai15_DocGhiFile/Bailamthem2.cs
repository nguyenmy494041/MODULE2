using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai15_DocGhiFile
{
    class Bailamthem2
    {
        static void Main()
        {
            var filePath = @"E:\CODEGYM\Module2\Bai15_DocGhiFile\Bai15_DocGhiFile\Data.txt";
            var path = @"E:\CODEGYM\Module2\Bai15_DocGhiFile\Bai15_DocGhiFile\Out.txt";
            using (StreamWriter sw = File.CreateText(filePath))
            {
                CreateMatrix(sw);
            }
            int[,] array = ReadArray(filePath);
            using (StreamWriter sw = File.CreateText(path))
            {
                Output(sw,array);
            }

        }
        static void CreateMatrix(StreamWriter sw)
        {
            Console.Write(" Enter n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write(" Enter m = ");
            int m = int.Parse(Console.ReadLine());
            sw.WriteLine($"{n} {m}");
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    sw.Write(rnd.Next(10, 70) + " ");
                    if (j == m - 2)
                    {
                        sw.Write(rnd.Next(10, 70));
                    }
                }
                sw.WriteLine();
            }
        }
        static int[,] ReadArray(string filePath)
        {
            try
            {              
                using (StreamReader sr = File.OpenText(filePath))
                {
                    var line = sr.ReadLine();
                    string[] data1 = line.Split(' ');
                    int i = 0;
                    int[,] array = new int[int.Parse(data1[0]), int.Parse(data1[1])];
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(' ');

                        for (int j = 0; j < data.Length; j++)
                        {
                            array[i, j] = int.Parse(data[j]);
                        }
                        i++;
                    }
                    return array;
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        static void Output( StreamWriter sw, int[,] array)
        {
            int even = 0, multipleOf5 = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] % 2 == 0) even++;
                    if (array[i, j] % 5 == 0) multipleOf5++;
                }
            }
            sw.WriteLine($"The number of even numbers: {even}");
            sw.WriteLine($"Number of numbers is a multiple of 5: {multipleOf5}");

        }
    }
}
