using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
   public class Method
    {
                
        public static DATA data = new DATA();
       public static void Create_User(User user)
        {
            ReadOnMember();
            if (user.Isadmin)
            {
                User user1 = User.CreateUser();
                Custumer custumer = new Custumer();
                user1.Isadmin = false;
                user1.user_id = Method.FindMaxIsCustumer()+1;
                data.members.Add(user1);
                Console.WriteLine("\nCreate user successfully");
                custumer.id_custumer = user1.user_id;
                Console.WriteLine("Fill in user information");
                Console.Write("Enter name Custumer: ");
                custumer.name_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter adress Custumer: ");
                custumer.adress_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter numberPhone Custumer:  ");
                string str = Console.ReadLine();
                while (!Method.Test_numberPhone(str))
                {
                    Console.Write("Enter again numberPhone Custumer:  ");
                    str = Console.ReadLine();
                }
                custumer.number_phone = str;
                data.custumers.Add(custumer);
                PushInDATA();
                
            }          
        }
        
        public static bool Test_numberPhone(string str)
        {
            long num;
            bool sdt = long.TryParse(str, out num);
            if ((str.Length == 10) && sdt && str[0] =='0') return true;
            return false;

        }
        public static void Create_Admin(User user)
        {
            ReadOnMember();
            if (user.Isadmin)
            {
                User user1 = User.CreateUser();
                Custumer custumer = new Custumer();
                user1.Isadmin = true;
                user1.user_id = Method.FindMaxIsCustumer() + 1;
                data.members.Add(user1);
                Console.WriteLine("\nCreate Admin successfully");
                custumer.id_custumer = user1.user_id;
                Console.WriteLine("Fill in user information");
                Console.Write("Enter name Custumer: ");
                custumer.name_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter adress Custumer: ");
                custumer.adress_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter numberPhone Custumer:  ");
                string str = Console.ReadLine();
                while (!Method.Test_numberPhone(str))
                {
                    Console.Write("Enter again numberPhone Custumer:  ");
                    str = Console.ReadLine();
                }
                custumer.number_phone = str;
                data.custumers.Add(custumer);
                PushInDATA();
               
            }
        }
        public static void PushInDATA()
        {
            string Path = @"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\database.json";
            using(StreamWriter sw = File.CreateText(Path))
            {
                var DATA = JsonConvert.SerializeObject(data);
                sw.Write(DATA);

            }
        }
        public static void ReadOnMember()
        {
            string Path = @"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\database.json";
            using (StreamReader sr = File.OpenText(Path))
            {
                var dataa = sr.ReadToEnd();
                data= JsonConvert.DeserializeObject<DATA>(dataa);
            }
        }       
        public static int FindMaxIsCustumer()
        {
            if (data.members.Count == 0) return 0;
            else
            {
                int max = data.members[0].user_id;
                foreach (var item in data.members)
                {
                    if(max < item.user_id)
                    {
                        max = item.user_id;
                    }
                }
                return max;
            }
        }
        public static bool ExitUser(string nameUser, out int index)
        {
            index = -1;
            for(int i = 0; i < data.members.Count; i++)
            {
                if (data.members[i].user_name == nameUser)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        public static bool IsPasswordofUser(int index, string pass)
        {
            if (data.members[index].user_password == pass) return true;
            return false;

        }
        public static void Login(out bool IsAdmin, out int id_Custumer)
        {
            Method.ReadOnMember();
            Console.Write("Enter User: ");
            string user = (Console.ReadLine()).Trim();

            var isUserExited = Method.ExitUser(user, out int index);
            while (!isUserExited)
            {            
                Console.Write("User not Exit! Re-enter the user: ");
                user = (Console.ReadLine()).Trim();
            }
           
            Console.Write("Enter password: ");
            string pass = (Console.ReadLine()).Trim();
            while (!IsPasswordofUser(index, pass))
            {
                Console.Write("Incorrect password! Re_enter the password: ");
                pass = (Console.ReadLine()).Trim();
            }
            IsAdmin = data.members[index].Isadmin;
            id_Custumer = data.members[index].user_id;
        }
        public static string RemoveWhitespace(string str)
        {
            string[] data = str.Split(' ');
            return string.Join("", data); 
        }
        

    }
}
