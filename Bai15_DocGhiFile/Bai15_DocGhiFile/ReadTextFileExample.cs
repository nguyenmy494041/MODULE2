using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai15_DocGhiFile
{
    class ReadTextFileExample
    {
        static void Main()
        {
            string filePath = @"E:\CODEGYM\Module2\Bai15_DocGhiFile\Bai15_DocGhiFile\data_nhap.txt";
            List<int> data = ReadTextFile(filePath);
            int sum = 0;
            foreach (var item in data)
            {
                sum += item;
            }
            Console.WriteLine($"Total: {sum}");
        }
        static List<int> ReadTextFile(string filePath)
        {
            try
            {
                var data = new List<int>();
                using (StreamReader sr = File.OpenText(filePath))
                {
                    var line = string.Empty;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data.Add(int.Parse(line));
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
    }
}
