using System;
using System.Collections.Generic;
using System.Text;

namespace Bai10_Queue
{
    class ChuyenHeNhiPhan
    {
        public static void Main()
        {
            Console.WriteLine(doiSoNguyenSangNhiPhan(96)); 
        }
        public static string doiSoNguyenSangNhiPhan(int number)
        {
            Stack<int> nhiphan = new Stack<int>();
            string kq = "1";
            if (number > 0)
            {
                do
                {
                    nhiphan.Push(number % 2);
                    number /= 2;

                }
                while (number / 2 != 0);
                while (nhiphan.Count > 0)
                {
                    kq += nhiphan.Peek();
                    nhiphan.Pop();
                }
                return kq;
            }
            else return kq = "khong chuyen duoc";
        }
        public static string doiSoThucDuongSangNhiPhan(double number)
        {
            string kq = "";
            int phanuyen = (int) number;
            double phanam = (number - phanuyen);
            Queue<int> kqs = new Queue<int>();



            return kq;
        }
    }
}
