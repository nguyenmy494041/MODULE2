using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BAi9_Arraylist
{
    class MyListTest
    {
        static void Main()
        {
            My_List<int> list = new My_List<int>();
            list.Add(15);
            list.Add(30);
   
            list.Add(30);
            list.PrintArray();
            Console.WriteLine(list.GetData(1));
        }
      
    }
    public class My_List<T>
    {
        private int Capacity { get; set; }
        public T[] Items { get; set; }
        public int Length
        {
            get => Items.Length;
        }
        public My_List()
        {
            Items = new T[10];
        }
        public My_List(int Capacity)
        {
            Items = new T[Capacity];
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
        //public My_List<T> Clone()
        //{
        //    My_List<T>[] arr = new My_List<T>(Items);
        //}



    }
}



