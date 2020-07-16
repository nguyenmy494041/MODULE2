using System;
using System.Collections;
using System.Collections.Generic;

namespace BAi9_Arraylist
{
    public class Listdongian
    {
        static void Main()
        {
            MyList<int> listInteger = new MyList<int>();
            listInteger.Add(10);
            listInteger.Add(15);
            listInteger.Add(20);
            listInteger.Add(30);
            listInteger.Add(50);
            listInteger.PrintArray();
            Console.WriteLine("Item 1: " + listInteger.GetData(1));
            Console.WriteLine("Item 4: " + listInteger.GetData(4));
            Console.WriteLine("Item 2: " + listInteger.GetData(2));
            listInteger.Remove(2);
            listInteger.PrintArray();

        }
    }

    public class MyList<T>
    {
        private int Capacity { get; set; }
        public T[] Items { get; set; }
        public int Length
        {
            get => Items.Length;
        }
        public MyList()
        {
            Items = new T[10];
        }
        private void EnsureCapacity()
        {
            int newSize = Items.Length * 2;
            Array.Copy(Items, Items, newSize);
        }

        public void Add(T data)
        {
            if (Capacity == Items.Length)
            {
                EnsureCapacity();
            }

            Items[Capacity++] = data;
        }

        public T GetData(int idx)
        {
            if (idx >= Capacity || idx < 0)
            {
                throw new IndexOutOfRangeException("Index: " + idx + ", Capacity: " + Capacity);
            }

            return (T)Items[idx];
        }
        public void Remove(int idx)
        {
            for (int i = idx; i < Items.Length - 1; i++)
            {
                Items[i] = Items[i + 1];
            }
            Array.Copy(Items, Items, Items.Length - 2);
        }
        public void PrintArray()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                //if (int.Parse(Items[i].ToString()) != 0)
                {
                    Console.Write($"{Items[i]},   ");
                }
            }
            Console.WriteLine();
        }
    }
}
