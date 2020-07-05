using System;
namespace Bai2
{
    public class DaoNguocMang
    {
        public static void Main()
        {
            int[] array = taoMang1Chieu(10);
            Console.WriteLine("Mang vua tao: " + printArray(array));

            daoNguocMang(array);
            Console.WriteLine();
            Console.WriteLine("Mang sau khi dao: " + printArray(array));
        }
        public static int[] taoMang1Chieu(int size = 7, int min = -20, int max = 50)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(min, max);
            }
            return array;
        }
        public static string printArray(int[] arr)
        {
            string str = "";
            for (byte i = 0; i < arr.Length; i++)
            {
                str += arr[i] + "; ";
            }
            return str;
        }
        public static int[] daoNguocMang(int[] arr)
        {

            int fist = 0; int last = arr.Length - 1;
            while (fist < last)
            {
                int tem = arr[fist];
                arr[fist] = arr[last];
                arr[last] = tem;
                fist++;
                last--;
            }
            return arr;
        }
    }
}