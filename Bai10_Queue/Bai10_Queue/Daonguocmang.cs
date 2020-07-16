using System;
using System.Collections.Generic;
using System.Text;

namespace Bai10_Queue
{
    class Daonguocmang
    {
        public static void Main()
        {
            float[] arr = { 12, 3.2f, 65, 2 };
            Mangdaonguoc mang = new Mangdaonguoc();
            //float[] cra = mang.daoMangSo(arr);
            foreach (float item in mang.daoMangSo(arr))
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("          -------------       ");
            string[] strings = { "ronaldo", "messi", "kaka", "rivaldo", "cafu" };
            foreach(string item in mang.daoMangString(strings))
            {
                Console.Write(item + ",  ");
            }
            Console.WriteLine();
            Console.WriteLine("          -------------       ");
            Console.WriteLine(mang.daoChuoi("Phan Tien Long"));

        }
    }
    class Mangdaonguoc
    {
        Stack<float> stack = new Stack<float>();
        public float[] daoMangSo(float[] arr)
        {
            float[] brray = new float[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                brray[i] = stack.Peek();
                stack.Pop();
            }
            return brray;
        }
        Stack<string> stackstring = new Stack<string>();
        public string[] daoMangString(string[] arr)
        {
            string[] brray = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                stackstring.Push(arr[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                brray[i] = stackstring.Peek();
                stackstring.Pop();
            }
            return brray;

        }
        Stack<Char> kitu = new Stack<char>();
        public string daoChuoi( string str)
        {
            Char[] arr = new Char[str.Length];
            for (int i = 0; i< str.Length; i++)
            {
                kitu.Push(str[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = kitu.Peek();
                kitu.Pop();
            }
            return string.Join("",arr);
           
        }
    }
}
