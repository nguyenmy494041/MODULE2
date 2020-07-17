using System;
using System.Collections.Generic;
using System.Text;

namespace Baitapcuoituan
{
    class Program
    {
        public static  Forum forum = new Forum();
        public static int increment = 0;
        static void Main(string[] args)
        {  
              int choice = 0;
            while (choice != 7)
            {
                string temp;
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("1. Create Post ");
                Console.WriteLine("2. Update Post");
                Console.WriteLine("3. Remove Post");
                Console.WriteLine("4. Show Posts");
                Console.WriteLine("5. Search Author");
                Console.WriteLine("6. Rating");
                Console.WriteLine("7. Exit");
                do
                {
                    Console.Write("Enter choice:  ");
                    temp = Console.ReadLine();
                }
                while (!IsNumber(temp) || int.Parse(temp) > 7);
                choice = int.Parse(temp);
                switch (choice)
                {
                    case 1:
                        CreatePost();
                        Console.WriteLine("       -----------");
                        break;
                    case 2:
                        UpdatePost();
                        Console.WriteLine("       -----------");
                        break;
                    case 3:
                        RemovePost();
                        Console.WriteLine("       -----------");
                        break;
                    case 4:
                        ShowPost();
                        Console.WriteLine("       -----------");
                        break;
                    case 5:
                        SearchAuthor();
                        Console.WriteLine("       -----------");
                        break;
                    case 6:
                        Rating();
                        Console.WriteLine("       -----------");
                        break;
                }
            }



        }



        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static void CreatePost()
        {
            
            int id = forum.Add();
            //increment++;
            //post.Id = increment;
            bool result;
                int number;
                do
                {
                   Console.WriteLine($" enter rate: "); 

                    result = int.TryParse(Console.ReadLine(), out number);

                } while (!result || number < 0 || number > 5);

                Forum.Posts[id].rate.Add(number);          
         

            Forum.Posts[id].CalculatorRate();


        }
        public static void UpdatePost()
        {
            Console.WriteLine("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new content: ");
            string contents = Console.ReadLine();

            forum.Update(id, contents);
        }

        public static void RemovePost()
        {
            Console.WriteLine("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            forum.Remove(id);
        }

        public static void ShowPost()
        {
            
            forum.Show();
        }

        public static void SearchAuthor()
        {
            Console.WriteLine("Please input author");
            string authors = Console.ReadLine();
           Post k = forum.FindAuthor(authors);
            Console.WriteLine($"id\t\ttitle\t\tcontent\t\tauthor\t\tcount\t\taveregeRate");
            k.DisPlay();
        }

        public static void Rating()
        {
            Console.WriteLine("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            int pos = forum.FindId(id);
            if (pos != -1)
            {
                bool result;
                int number;
                do
                {
                    Console.WriteLine($" enter rate: ");

                    result = int.TryParse(Console.ReadLine(), out number);

                } while (!result || number < 0 || number > 5);

                Forum.Posts[id].rate.Add(number);
                Forum.Posts[id].CalculatorRate();

            } else
            {
                Console.WriteLine("Invalid Post  ");
            }
        }












    }







    public interface IPost
    {
        public void DisPlay();
        public void CalculatorRate();
    }
}
