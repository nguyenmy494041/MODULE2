using System;
namespace HelloWorld
{
    public class nhap
    {
        public static void NHAP()
        {
            int a = 1;
            int b = 2;
            Console.WriteLine("Trước khi thay đổi");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Swap(ref a, ref b);
            Console.WriteLine("Sau khi thay đổi");
            Console.WriteLine("a = {0}, b = {1}", a, b);

            int x;
            GetValue(out x);

            Console.WriteLine(x);

        }

        public static void Swap(ref int a, ref int b)
        {
            int tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

        public static void GetValue(out int x)
        {
            x = 5;
        }

    }
}
