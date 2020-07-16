using System;
using System.Collections.Generic;
using System.Text;

namespace BAi9_Arraylist
{
    class MyLinkedListTest
    {
        public static void Main()
        {
            MyLinkedList list = new MyLinkedList(10);
            list.AddFirst(11);
            list.PrintList();

            list.AddFirst(12);
            list.PrintList();

            list.AddLast(13);
            list.PrintList();

            list.Add(9, 4);
            list.PrintList();

            list.Add(15, 4);
            list.PrintList();
            Console.WriteLine();
            Console.WriteLine();
            list.Remove(3);
            list.PrintList();

        }
    }
    public class MyLinkedList
    {
        Node Head;
        public int NodeCnt = 0;

        public MyLinkedList(Object[] args)
        {

            Node temp = Head = new Node(args[0]);
            NodeCnt++;

            int idx = 1;

            while (idx < args.Length)
            {
                temp.Next = new Node(args[idx]);
                NodeCnt++;
            }
        }

        public MyLinkedList(Object Data)
        {
            Head = new Node(Data);
        }
        public void Add(Object Data, int idx)
        {
            Node temp = Head;
            Node holder;
            for (int i = 0; i < idx - 1 && temp.Next != null; i++)
            {
                temp = temp.Next;
            }

            holder = temp.Next;
            temp.Next = new Node(Data);
            temp.Next.Next = holder;
            NodeCnt++;
        }



        public void AddFirst(Object Data)
        {
            Node temp = Head;
            Head = new Node(Data);
            Head.Next = temp;
            NodeCnt++;
        }
        public void AddLast( Object Data)
        {
            Node temp = Head;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new Node(Data);
            NodeCnt++;
        }

        public Node GetData(int idx)
        {
            Node temp = Head;
            for (int i = 0; i < idx; i++)
            {
                temp = temp.Next;
            }
            return temp;
        }
        public void Remove(int ind)
        {
            if(ind < 1)
            {
                return;
            }

            Node temp = Head;
            int i = 1;
            
            while(i < ind - 1)
            {
                temp = temp.Next;
                i++;
            }

            temp.Next = temp.Next.Next;
        }
        public void PrintList()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.Write($"{temp.Data}  ");
                temp = temp.Next;
            }

            Console.WriteLine();
        }
    }




    public class Node
    {

        public Object Data { get; set; }
        public Node Next { get; set; }

        public Node(Object Data)
        {
            this.Data = Data;
            Next = null;
            
        }
    }
}
