using System;
using System.Collections.Generic;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
 
    public class Member
    {
        public List<User> member { get; set; }
        public Member()
        {
            member = new List<User>();
        }
    }
    public class User
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_mail { get; set; }
        public string user_password { get; set; }       
        public bool Isadmin { get; set; } = false;
        public static User CreateUser()
        {
            User user = new User();
            Console.Write("Enter name User: ");
            user.user_name = (Console.ReadLine()).Trim();
            
            while (!Testuser(user.user_name))
            {
                Console.Write("Enter again name User: ");
                user.user_mail = (Console.ReadLine()).Trim();
            }
            Console.Write("Enter user gmail: ");
            user.user_mail = (Console.ReadLine()).Trim();
            while (!Testgmail(user.user_mail))
            {
                Console.Write("Enter again user gmail: ");
                user.user_mail = (Console.ReadLine()).Trim();
            }
            Console.Write("Enter user password: ");
            string pass = (Console.ReadLine()).Trim();
            while (!Testpass(pass))
            {
                Console.Write("Enter new user password minimum of 8 characters and non-Space : ");
                pass = (Console.ReadLine()).Trim();
            }
            Console.Write("Enter confirm password: ");
            user.user_password = (Console.ReadLine()).Trim();
            while (user.user_password != pass)
            {
                Console.Write("Enter again confirm password: ");
                user.user_password = (Console.ReadLine()).Trim();
            }            
            return user;
        }
        public static bool Testpass(string str)
        {
            if (str.Length < 8) { return false; }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ') return false;
                }
                return true;
            }
        }
        public static bool Testuser(string str)
        {            
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ') return false;
                }
                return true;
        }
        public static bool Testgmail(string str)
        {
            if (str.Length <= 10)
            {
                return false;
            }
            else 
            {
                string str1 = str.Substring(str.Length - 10);
                if (str1 == "@gmail.com") return true;
                return false;
            }
        }
        
    }
   



    public class Custumer
    {
        public int id_custumer { get; set; }
        public string name_custumer { get; set; }
        public string adress_custumer { get; set; }
        public string number_phone { get; set; }
        public List<Oder> oders { get; set; }
        public Custumer()
        {
            oders = new List<Oder>();
        }
       

    }

    public class Oder
    {
        public int OrderItem { get; set; }
        public int OrderId { get; set; }
        public string timeOrder => DateTime.Now.ToString("hh:mm tt dd/MM/yyyy");
        public string status { get; set; }
        public List<Product> products { get; set; }
        public Oder()
        {
            products = new List<Product>();
        }

    }  
   
    public class Product
    {
        public string code_product { get; set; }
        public string name_product { get; set; }
        public long price_product { get; set; }
        public int quantity_product { get; set; }
        public long pay_money => pay();
        public long pay()
        {
            return price_product * quantity_product;
        }
        public override string ToString()
        {
            return $"{code_product}\t{name_product}\t\t{price_product}\t{quantity_product}\t{pay_money}";
        }
        public string OutString()
        {
            return $"{code_product}\t{name_product}\t\t{price_product}VND";
        }
    }
    
}
