using System;

namespace Bai10_Queue
{
    class TrienkhaiQueue
    {
        static void Main(string[] args)
        {
            MyLinkedListQueue queue = new MyLinkedListQueue();
            queue.Enqueue(10);
            //Console.WriteLine("Dequeued item is " + queue.Dequeue().key);
            queue.Enqueue(20);
            //Console.WriteLine("Dequeued item is " + queue.Dequeue().key);
            //queue.Dequeue();
           
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            Console.WriteLine("Dequeued item is " + queue.Dequeue().key);
        }
    }

    public class Node
    {
        public int key;
        public Node next;

        public Node(int key)
        {
            this.key = key;
            this.next = null;
        }
    }
    public class MyLinkedListQueue
    {
        private Node head;
        private Node tail;

        public MyLinkedListQueue()
        {
            this.head = null;
            this.tail = null;
        }
        public void Enqueue(int key)
        {
            Node temp = new Node(key);
            if (this.tail == null)
            {
                this.head = this.tail = temp;
                return;
            }
            this.tail.next = temp;
            this.tail = temp;
        }
        public Node Dequeue()
        {
            if (this.head == null)
                return null;
            Node temp = this.head;
            this.head = this.head.next;
            if (this.head == null)
                this.tail = null;
            return temp;
        }
    }
}
