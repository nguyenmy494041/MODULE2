using System;
namespace Bai2
{
    public class DemSinhVienThiDo
    {
        public static void Main()
        {
            float[] array = taoBang();
            Console.WriteLine(inMang1Chieu(array));
            Console.WriteLine($"So luong sinh vien thi do: {kiemTra(array)}");

        }
        public static float[] taoBang()
        {
            float[] arr4 = new float[0];
            string key = "C";
            do
            {
                Console.Write("Nhap diem so: ");
                float num = float.Parse(Console.ReadLine());
                Array.Resize(ref arr4, arr4.Length + 1);
                arr4[arr4.Length - 1] = num;
                Console.Write("Ban co muon nhap tiep khong? (C/K): ");
                key = Console.ReadLine();
            }
            while ((key.ToUpper() != "K") && (arr4.Length < 30));
            return arr4;
        }
        public static string inMang1Chieu(float[] arr)
        {
            string str = "";
            for (byte i = 0; i < arr.Length; i++)
            {
                str += arr[i] + "; ";
            }
            return str;
        }
        public static int kiemTra(float[] arr)
        {
            int kq = 0;
            for (byte i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 5.0)
                {
                    kq++;
                }
            }
            return kq;
        }

    }
}