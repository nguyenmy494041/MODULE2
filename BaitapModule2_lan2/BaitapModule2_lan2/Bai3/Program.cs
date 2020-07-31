using System;
using System.Collections.Generic;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
    class Program
    {

        static void Main()
        {
            User ADMIN = new User();
            ADMIN.Isadmin = true;
            //Method.Login(out bool IsAdmin);
            //Console.WriteLine($"\n{IsAdmin}");
           
            Method.Create_Admin(ADMIN);
            Yield.CreateNewOder(1);

        }
    }
}
