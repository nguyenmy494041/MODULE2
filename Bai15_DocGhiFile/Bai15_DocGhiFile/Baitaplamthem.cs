using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai15_DocGhiFile
{
    class Baitaplamthem
    {
        static void Main()
        {
            var filePath = @"E:\CODEGYM\Module2\Bai15_DocGhiFile\Bai15_DocGhiFile\InputData.txt";
            var path = @"E:\CODEGYM\Module2\Bai15_DocGhiFile\Bai15_DocGhiFile\OutputData.txt";
            using (StreamWriter sw = File.CreateText(filePath))
            {
                Console.Write("Enter row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter col: ");
                int col = int.Parse(Console.ReadLine());
                sw.WriteLine($"{row} {col}");
                Random rnd = new Random();

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col - 1; j++)
                    {
                        sw.Write(rnd.Next(10, 80) + " ");
                        if( j == col - 2)
                        {
                            sw.Write(rnd.Next(10, 80));
                        }
                    }
                    sw.WriteLine();
                }
            }

            List<int> data = ReadRowCol(filePath);           
            int[,] array = ReadArray(data[0], data[1], filePath);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"Matrix input:");
                WriteFile(sw, array);
                int temp = SumArray(array, out int primes, out int odd);
                sw.WriteLine();
                sw.WriteLine($"Total force value in the matrix: {SumBoundary(array)}");             
                sw.WriteLine($"The number of primes in the matrix: {primes}");           
                sw.WriteLine($"The number of odd numbers in the matrix: {odd}");
                sw.WriteLine($"The total value on the boundary: {SumBoundary(array)}");
                sw.WriteLine($"The matrix after the values ​​in the matrix are multiplied by 3: ");
                WriteFile(sw, MultipliedBy3(array));
            }          
        }

        static void WriteFile(StreamWriter sw , int[,] array)
        {
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] < 100)
                    {
                        sw.Write(array[i, j] + "  ");
                    } else
                    {
                        sw.Write(array[i, j] + " ");
                    }
                }
                sw.WriteLine();
            }
        }     


        static List<int> ReadRowCol(string filePath)
        {
            try
            {
                var data = new List<int>();
                using (StreamReader sr = File.OpenText(filePath))
                {
                    var line = sr.ReadLine();
                    string[] array = line.Split(' ');
                    foreach (var item in array)
                    {
                        data.Add(int.Parse(item) );
                    }                    
                }
                return data;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }
        static int[,] ReadArray( int row, int col, string filePath)
        {           
            try
            {
                int[,] array = new int[row, col];
                using (StreamReader sr = File.OpenText(filePath))
                {
                    var line = sr.ReadLine();
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(' ');
                       
                        for (int j = 0; j < data.Length; j++)
                        {
                            array[i,j] = int.Parse(data[j]);
                        }
                        i++;
                    }
                }
                return array;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }
        static bool IsPrime(int number)
        {           
            try
            {
                if (number < 2) return false;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        static int SumArray(int[,] array, out int primes, out int odd)
        {
            int sum = primes = odd = 0;
        
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array .GetLength (1); j++)
                {
                    sum += array[i, j];
                    if (IsPrime(array[i, j])) primes++;
                    if (array[i, j] % 2 == 1) odd++;
                }
            }           
            return sum;
        }
        static int SumBoundary(int[,] array)
        {
            try
            {
                int sum = 0;
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    sum += array[0, i] + array[array.GetLength(0) - 1, i];
                }
                for (int i = 1; i < array.GetLength(0) - 1; i++)
                {
                    sum += array[i, 0] + array[i, array.GetLength(1) - 1];
                }
                return sum;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
        static int[,] MultipliedBy3(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] *= 3;
                }
            }
            return array;
        }


    }
    
}
