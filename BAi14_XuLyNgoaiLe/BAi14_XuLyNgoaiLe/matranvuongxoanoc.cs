using System;
using System.Collections.Generic;
using System.Text;

namespace BAi14_XuLyNgoaiLe
{
    public class matranvuongxoanoc
    {
        static void Main()
        {
           int[,] matrix = CreateNewMatrix(8);
            matranvuongdemso.PrintMatrix(matrix);

        }
        static int[,] CreateNewMatrix(int size = 8)
        {
            int[,] matrix = new int[size, size];
            int l = matrix.GetLength(1);
           int n = (l % 2 == 0)?(l / 2 ) :(l / 2 + 1);
            matrix[0, 0] = 1;
            matrix[l-1, l-1] = 2 * l - 1;
            for (int i = 1; i < n; i++)
            {               
                matrix[i, i] = matrix[i - 1, i - 1] + 4 * (l - 2 * i + 1);
                matrix[l - 1 - i, l - 1 - i] = matrix[l - i, l - i] + 4 * (l - 2 * i);
            }
            for (int i = l-1;  i >= 0; i--)
            {
                for (int j = i-1; j>= l-i; j--)
                {
                    matrix[i, j] = matrix[i, i] + l - 1 - j;
                }
            }
            





            return matrix;
        }
    }
}
