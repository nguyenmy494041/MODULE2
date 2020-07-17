using System;

namespace Baitap1
{
    class Program
    {
       public  static void Main(string[] args)
        {
            CreateMatrix create = new CreateMatrix();
            int[,] matrix = CreateMatrix.CreateMatrixx();
            Console.WriteLine("      --------------------      ");
            Console.WriteLine("Matrix display:");
            CreateMatrix.PrintMatrix(matrix);                   
            Console.WriteLine($"Sum value the Even Number: {CreateMatrix.SumtheEvenNumber(matrix)}");            
            Console.WriteLine($"Sum Values on the Main Diagonal: {CreateMatrix.SumValuesontheMainDiagonal(matrix)}");
            Console.WriteLine($"Sum Values on the Sub Diagonal: {CreateMatrix.SumValuesontheSubDiagonal(matrix)}"); 
            Console.WriteLine($"Sum Values on the Boundary: {CreateMatrix.SumValuesontheBoundary(matrix)}");
            Console.WriteLine();
            Console.WriteLine("Show the lower triangle matrix: ");
            CreateMatrix.PrintLowerTriangle(matrix);
            Console.WriteLine();
            Console.WriteLine("Show ma triangles on: ");
            CreateMatrix.PrintMaOnTriangle(matrix);
        }
    }
}
