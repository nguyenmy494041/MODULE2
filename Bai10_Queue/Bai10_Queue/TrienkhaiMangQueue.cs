using System;
using System.Collections.Generic;
using System.Text;

namespace Bai10_Queue
{
    class TrienkhaiMangQueue
    {
        public static void Main(string[] args)
        {
            MyQueue queue = new MyQueue(4);
            queue.Enqueue(4);
            //queue.Dequeue();
            queue.Enqueue(56);
            queue.Enqueue(2);
            queue.Enqueue(67);
            //queue.Dequeue();
            //queue.Dequeue();
            //queue.Enqueue(24);
            queue.Dequeue();
            //queue.Enqueue(98);
            //queue.Enqueue(45);
            //queue.Enqueue(23);
            //queue.Enqueue(435);
        }
    }

    public class MyQueue
    {

        private int capacity;
        private int[] queueArr;
        private int head = 0;
        private int tail = -1;
        private int currentSize = 0;

        public MyQueue(int queueSize)
        {
            this.capacity = queueSize;
            queueArr = new int[this.capacity];
        }
        public bool IsQueueFull()
        {
            bool status = false;
            if (currentSize == capacity)
            {
                status = true;
            }
            return status;
        }
        public bool IsQueueEmpty()
        {
            bool status = false;
            if (currentSize == 0)
            {
                status = true;
            }
            return status;
        }
        public void Enqueue(int item)
        {
            if (IsQueueFull())
            {
                Console.WriteLine("Overflow ! Unable to add element: " + item);
            }
            else
            {
                tail++;
                if (tail == capacity - 1)
                {
                    tail = 0;
                }
                queueArr[tail] = item;
                currentSize++;
                Console.WriteLine("Element " + item + " is pushed to Queue !");
            }
        }
        public void Dequeue()
        {
            if (IsQueueEmpty())
            {
                Console.WriteLine("Underflow ! Unable to remove element from Queue");
            }
            else
            {
                head++;
                if (head == capacity - 1)
                {
                    Console.WriteLine("Pop operation done ! removed: " + queueArr[head - 1]);
                    head = 0;
                }
                else
                {
                    Console.WriteLine("Pop operation done ! removed: " + queueArr[head - 1]);
                }
                currentSize--;
            }
        }
    }
}
