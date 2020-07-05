using System;
namespace Bai2
{
    public class ThaoTacVoiBang
    {
        public static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 2;
            array[1] = 12;
            array[2] = 122;
            array[3] = 5162;
            array[4] = 1322;
            Console.WriteLine(array[2]);
            Console.WriteLine(array[4]);
            Console.WriteLine(array[0]);
            // Tinh tong cac phan tu
            Console.WriteLine($"Tong cac phan tu cua mang: {tinhTongMang1Chieu(array)}");

        }
        public static int tinhTongMang1Chieu(int[] arr)
        {
            int sum = 0;
            for (byte i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
}