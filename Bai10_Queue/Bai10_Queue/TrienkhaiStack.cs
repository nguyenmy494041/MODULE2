using System;
using System.Collections.Generic;
using System.Text;

namespace Bai10_Queue
{
    class TrienkhaiStack
    {
        static void Main(string[] args)
        {

            MyStack stack = new MyStack(5);

            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            Console.WriteLine("1. Size of stack after push operations: " + stack.Size());
            Console.WriteLine("2. Pop elements from stack : ");

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("\n3. Size of stack after pop operations : " + stack.Size());
        }
    }
}


public class MyStack
{
    private int[] arr;
    private int size;
    private int index = 0;

    public MyStack(int size)
    {
        this.size = size;
        arr = new int[size];
    }
    public bool IsEmpty()
    {
        if (index == 0)
        {
            return true;
        }
        return false;
    }
    public bool IsFull()
    {
        if (index == size)
        {
            return true;
        }
        return false;
    }
    public int Size()
    {
        return index;
    }
    public void Push(int element)
    {
        if (IsFull())
        {
            throw new Exception("Stack is full");
        }
        arr[index] = element;
        index++;
    }
    public int Pop()
    {
        if (IsEmpty())
        {
            throw new Exception("Stack is null");
        }
        return arr[--index];
    }

}
