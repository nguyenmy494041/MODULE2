using System;
using System.Collections.Generic;
using System.Collections;

namespace BookMagagementSystem
{
    
    class Program
    {
       
        public static LinkedList<Book> linkedListBook = new LinkedList<Book>();
        public static int increment = 0;

        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("Please select of option: ");
                Console.WriteLine("1. Insert New Book. ");
                Console.WriteLine("2. View List Of Book.");
                Console.WriteLine("3. Average Price.");
                Console.WriteLine("4. Exit.");
                Console.Write(" Enter choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        InsertNewBook();
                        break;
                    case 2:
                        ViewListOfBook();
                        break;
                    case 3:
                        AveragePrice();
                        break;
                }
            }
           
        }
        public static void InsertNewBook()
        {
            increment++;
            Book book = new Book();
            book.Id = increment;
          
            Console.Write("Name: ");
            book.Name = Console.ReadLine();
            Console.Write("Publish date: ");
            book.PublishDate = Console.ReadLine();
            Console.Write("Author: ");
            book.Author = Console.ReadLine();
            Console.Write("Language: ");
            book.Language = Console.ReadLine();
            string price;
            for (int i = 0; i < book.PriceList.Length; i++)
            {
                do
                {
                    Console.Write($"Price {i + 1}: ");
                    price = Console.ReadLine();
                }
                while (!IsNumber(price));
                book.PriceList[i] = int.Parse(price);
            }
            linkedListBook.AddLast(book);


        }
        public static void ViewListOfBook()
        {
            Console.WriteLine($"Id \t Name \t PublishDate \t Author \t Language \t AveragePrice.");
            foreach( Book item in linkedListBook)
            {
                item.Display();
            }
              
        }
        public static void AveragePrice()
        {
            foreach (Book book in linkedListBook)
            {
                book.Calculate();
            }
            ViewListOfBook();

        }
        //public void EnterInteger()
        //{
        //    do
        //    {
        //        Console.Write("ernnnn: ");
        //        int b = int.Parse(Console.ReadLine());
        //    } while ();
        //}
        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }



    }










    public interface IBooks
    {
        public void Display();
    }
}
