using System;
using System.Collections.Generic;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
    public class DATA
    {
        public List<User> members { get; set; }
        public List<Custumer> custumers { get; set; }
        public DATA()
        {
            members = new List<User>();
            custumers = new List<Custumer>();
        }
    }
    public class METHOD
    {
        public static DATA data = new DATA();       
        public static int FindIndexInMembers(int id_Custumer)
        {
            int index = -1;
            for (int i = 0; i < data.members.Count; i++)
            {
                if (data.members[i].user_id == id_Custumer) index = i;

            }
            return index;
        }
        public static void ChangePassword(int id_Custumer)
        {
            int pos = METHOD.FindIndexInMembers(id_Custumer);
            if(pos != -1)
            {
                Console.Write("Enter password: ");
                string pass = Console.ReadLine();
                if(pass != data.members[pos].user_password)
                {
                    Console.Write("Current password is incorrect! Re-enter password: ");
                    pass = Console.ReadLine();
                }
                Console.Write("Enter new user password: ");
                string pass1 = (Console.ReadLine()).Trim();
                while (!User.Testpass(pass1))
                {
                    Console.Write("Enter new user password minimum of 8 characters and non-Space : ");
                    pass1 = (Console.ReadLine()).Trim();
                }
                Console.Write("Enter confirm new password: ");
                data.members[pos].user_password = (Console.ReadLine()).Trim();
                while (data.members[pos].user_password != pass1)
                {
                    Console.Write("Enter again confirm password: ");
                    data.members[pos].user_password = (Console.ReadLine()).Trim();
                }
            }

        }
        
    }

}