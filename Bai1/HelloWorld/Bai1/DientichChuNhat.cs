using System;

namespace HelloWorld
{
    public class Bai3
    {

        public static void tinhDienTich()
        {
            float chieurong, chieudai;
            Console.Write("Nhap chieu rong:");
            chieurong = float.Parse(Console.ReadLine());
            Console.Write("Nhap chieu dai:");
            chieudai = float.Parse(Console.ReadLine());
            // float Area = chieudai * chieurong;
            Console.WriteLine("Dien tich la: " + chieudai * chieurong);
        }
    }
}