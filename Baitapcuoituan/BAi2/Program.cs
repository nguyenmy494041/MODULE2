using System;


namespace BAi2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            int number;
            do
            {
                Console.WriteLine("Enter number: ");
                result = int.TryParse(Console.ReadLine(), out number);

            } while (!result || number < 2 || number > 20);
            int[,] matrix1 = CalculateMatrix.CreateMatrixx(number);
            int[,] matrix2 = CalculateMatrix.CreateMatrixx(number);
            Console.WriteLine($"Show matrix1: ");
            CalculateMatrix.PrintMatrix(matrix1);
            Console.WriteLine($"Show matrix2: ");
            CalculateMatrix.PrintMatrix(matrix2);
            Console.WriteLine("    ---------------        ");
            Console.WriteLine("Sum 2 matrix: ");
            CalculateMatrix.PrintMatrix(CalculateMatrix.Sum2Matrix(matrix1,matrix2));
            Console.WriteLine("    ---------------        ");
            Console.WriteLine("Multiply 2 matrix: ");
            CalculateMatrix.PrintMatrix(CalculateMatrix.Multiply2Matrix(matrix1, matrix2));

        }
    }
}
