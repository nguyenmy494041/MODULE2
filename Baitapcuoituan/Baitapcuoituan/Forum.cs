using System;
using System.Collections.Generic;
using System.Text;

namespace Baitapcuoituan
{
   public  class Forum
    {
        //public static  Post post = new Post();
        public static int increment = 0;
        public static SortedList<int, Post> Posts = new SortedList<int, Post>();


        public int Add()
        {
           
            Post post = new Post();
            increment++;
            post.Id = increment;
            Console.WriteLine("Please input title: ");
            post.Title = Console.ReadLine();
            Console.WriteLine("Please input content: ");
            post.Content = Console.ReadLine();
            Console.WriteLine("Please input author: ");
            post.Author = Console.ReadLine();
            Posts.Add(post.Id, post);
            return post.Id;
        }

        public int FindId( int id)
        {
            int pos = -1;
           foreach(var item in Posts.Keys)
            {
                if (item == id)
                {
                    pos = item;
                }
            }
            return pos;
        }

        public void Update(int id, string contents)
        {

            int pos = FindId(id);
            if ( pos !=  -1 )
            {
                Posts[id].Content = contents;
            }
            else
            {
                Console.WriteLine("Fail!");
            }
        }

        public void Remove(int id)
        {
            int pos = FindId(id);
            if (pos != -1)
            {
                Posts.Remove(id);
            }
            else
            {
                Console.WriteLine("Fail!");
            }

        }

        public void Show()
        {
            Console.WriteLine($"id \t title \t content \t author \t count \t averegeRate");
           foreach(var item in Posts.Keys)
            {
                Posts[item].DisPlay();
            }
          
        }

        public Post FindAuthor( string authors)
        {
            int pos = -1;
            for (int i = 1; i <= Posts.Count; i++)
            {
                if (Posts[i].Author == authors)
                {
                    pos = i;
                }
            }
            if (pos != -1) return Posts[pos];
            else return (Post)default;
        }






    }
}
