using System;
namespace HelloWorld
{
    public class docSoThanhChu
    {

        public static void docSoThanhChuAnh()
        {
            Console.WriteLine("Enter number: ");
            int number = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"{number} english reading is: {docChuSo(number)}");

        }

        public static string doc1so(Int32 num)
        {
            string bien = "a";

            switch (num)
            {
                case 0:
                    bien = "";
                    break;
                case 1:
                    bien = "one";
                    break;
                case 2:
                    bien = "two";
                    break;
                case 3:
                    bien = "three";
                    break;
                case 4:
                    bien = "four";
                    break;
                case 5:
                    bien = "five";
                    break;
                case 6:
                    bien = "six";
                    break;
                case 7:
                    bien = "seven";
                    break;
                case 8:
                    bien = "eight";
                    break;
                case 9:
                    bien = "nine";
                    break;

                case 10:
                    bien = "ten";
                    break;

                case 11:
                    bien = "eleven";
                    break;
                case 12:
                    bien = "twelve";
                    break;
                case 15:
                    bien = "fifteen";
                    break;
                case 13:
                    bien = " thirteen";
                    break;
                case 20:
                    bien = "twenty";
                    break;
                default:
                    bien = doc1so(num % 10) + "teen";
                    break;

            }
            return bien;
        }
        public static string doc2so(int num)
        {
            string doc = "doc2so";
            switch (num / 10)
            {
                case 2:
                    doc = "twenty " + doc1so(num % 10);
                    break;
                case 3:
                    doc = "thirty " + doc1so(num % 10);
                    break;
                case 4:
                    doc = "forty " + doc1so(num % 10);
                    break;
                case 5:
                    doc = "fifty " + doc1so(num % 10);
                    break;
                case 8:
                    doc = "eighty " + doc1so(num % 10);
                    break;
                default:
                    doc = $"{doc1so(num / 10)}ty {doc1so(num % 10)}";
                    break;
            }
            return doc;
        }
        public static string doc3so(int num)
        {
            string doc = "doc3so";
            string haiso = (num % 100) == 0 ? "" : (num % 100) <= 20 ? "and " + doc1so(num % 100) : "and " + doc2so(num % 100);
            doc = $"{doc1so(num / 100)} hundreds {haiso}";
            return doc;
        }
        public static string doc4so(int num)
        {
            string doc = "doc4so";
            string baso = (num % 1000) == 0 ? "" : (num % 1000) <= 20 ? "and " + doc1so(num % 1000) : (num % 1000) < 100 ? "and " + doc2so(num % 1000) : doc3so(num % 1000);
            doc = $"{doc1so(num / 1000)} thousands {baso} ";
            return doc;
        }
        public static string doc5so(int num)
        {
            string doc = "doc5so";
            string bonso = (num / 1000) <= 20 ? doc1so(num / 1000) : doc2so(num / 1000);
            string duoi = (num % 1000) == 0 ? "" : (num % 1000) <= 20 ? "and " + doc1so(num % 1000) : (num % 1000) < 100 ? "and " + doc2so(num % 1000) : doc3so(num % 1000);
            doc = $"{bonso} thousands {duoi} ";
            return doc;
        }
        public static string docChuSo(int number)
        {
            string doc = "docso";
            if (number == 0)
            {
                doc = "zero";
            }
            else if (number > 0)
            {
                if (number <= 20) { doc = doc1so(number); }
                else if (number < 100) { doc = doc2so(number); }
                else if (number < 1000) { doc = doc3so(number); }
                else if (number < 10000) { doc = doc4so(number); }
                else if (number < 100000) { doc = doc5so(number); }
                else { doc = " Nhap so chua dung"; }
            }
            else { doc = "negative " + docChuSo(number * (-1)); }
            return doc;
        }
    }
}