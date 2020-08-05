using System;
using System.Collections.Generic;
using System.Text;

namespace KiemtraMODULE.Bai3
{
    class Program
    {
        public static List<Post> PostList = new List<Post>();
        static void Main(string[] args)
        {
            int choise = -1;
            while (choise !=4 )
            {
                Console.WriteLine(" - - - - Management Post - - - - ");
                Console.WriteLine("1. Creat Post.");
                Console.WriteLine("2. Calculator");
                Console.WriteLine("3. Show list");                
                Console.WriteLine("4. Exit.");
                choise = CreateChoise();
                while (PostList.Count == 0 && choise != 1)
                {
                    choise = CreateChoise();
                }
                Console.Clear();
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("- - Create new Post. - -\n");
                        CreatePost();
                        Console.WriteLine("\nHas created a new Post!");
                        break;
                    case 3:
                        Console.WriteLine("Show all posts in the Postlist\n");
                        ShowList();
                        break;
                    case 2:
                        Console.WriteLine("Show all posts in the Postlist\n");
                        ShowList();
                        Console.WriteLine($"\nAverage rating of posts: {Calculator()}");
                        break;
                    case 4:
                        Console.WriteLine(" \n- - - - EXIT - - - - ");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No choose!");
                        break;
                }
                Console.WriteLine();
            }
        }
        static int CreateRate(string st)
        {
            int num;
            Console.Write($"Enter rating turn {st} : ");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out num);
            while (!result || num < 1 || num > 5)
            {
                Console.Write($"Enter again rating turn {st}: ");
                str = Console.ReadLine();
                result = int.TryParse(str, out num);
            }
            return num;
        }
        static int CreateChoise()
        {
            int num;
            Console.Write($"Enter choise : ");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out num);
            while (!result || num < 1 || num > 4)
            {
                Console.Write($"Enter again choise: ");
                str = Console.ReadLine();
                result = int.TryParse(str, out num);
            }
            return num;
        }
        static void CreatePost()
        {
            Post post = new Post();
            post.Id = PostList.Count + 1;
            Console.Write("Enter Title: ");
            post.Title = Console.ReadLine();
            Console.Write("Enter Content: ");
            post.Content = Console.ReadLine();
            Console.Write("Enter Author: ");
            post.Author = Console.ReadLine();
            for (int i = 1; i <= post.Rates.Length; i++)
            {
                post.Rates[i - 1] = CreateRate($"{i}");
            }
            PostList.Add(post);
        }
        static void ShowList() 
        {
            Console.WriteLine($"Id\tTitle\tContent\tAuthor\tAverageRate");
            foreach (var item in PostList)
            {
                Console.WriteLine(item.Display());
            }
        }
        static float Calculator() 
        {
            float sum = 0;
            foreach (var item in PostList)
            {
                sum += item.AverageRate;
            }
            return sum / PostList.Count;
           
        }
        
    }
}   

