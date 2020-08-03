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
            TakeAction();
        }
        static void TakeAction()
        {
            Console.WriteLine("- - - - SIGN IN - - - -");
            Method.Login(out bool IsAdmin, out int id_Custemer);

            while (IsAdmin)
            {
                //int key_id = id_Custemer;
                Console.Clear();
                Console.WriteLine("Logged in successfully\n");
                ActionAdmin(id_Custemer);
            }
            while (!IsAdmin)
            {
                Console.Clear();
                Console.WriteLine("Logged in successfully\n");
                ActionUser(id_Custemer);
            }
        }
        static void ActionAdmin(int id_Custemer)
        {
            User ADMIN = new User();
            ADMIN.Isadmin = true;
            int choose = -1;
            while (choose != 0)
            {
                Console.WriteLine("Please seclect of option: ");
                Console.WriteLine("1. Account processing");
                Console.WriteLine("2. Manage orders");
                Console.WriteLine("3. Manage all items in the store");
                Console.WriteLine("4. Logout\n");
                choose = Management.CreateInteger("choose", 1, 12);
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("        Account processing");
                        Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                        int seclect = -1;
                        while (seclect != 5)
                        {
                            Console.WriteLine("1. Create new Admin");
                            Console.WriteLine("2. Create new User ");
                            Console.WriteLine("3. Change Password");
                            Console.WriteLine("4. Show accounts");
                            Console.WriteLine("5. Exit");
                            seclect = Management.CreateInteger("seclect", 1, 5);
                            switch (seclect)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("       Create new Admin");
                                    Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                                    Method.Create_Admin(ADMIN);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("       Create new User");
                                    Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                                    Method.Create_User(ADMIN);
                                    break;
                                case 3:
                                    int i;
                                    Console.Clear();
                                    Console.WriteLine("      Change password");
                                    Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                                    Console.Write("Enter the account name to change the password: ");
                                    string name = Console.ReadLine().Trim();
                                    Method.ReadOnMember();
                                    for (i = 0; i < Method.data.members.Count; i++)
                                    {
                                        if (Method.data.members[i].user_name == name)
                                        {
                                            Method.changePassword(Method.data.members[i].user_id);
                                            break;
                                        }
                                    }
                                    if (i == Method.data.members.Count)
                                    {
                                        Console.WriteLine("Not found account!");
                                    }
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("       Show all accounts");
                                    Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                                    Method.ShowAccounts();
                                    break;
                                case 5:
                                    Console.Clear();
                                    ActionAdmin(id_Custemer);
                                    break;
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("       Manage orders");
                        Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                        int seclect1 = -1;
                        while (seclect1 != 7)
                        {
                            Console.WriteLine("1. Show information of Custumer");
                            Console.WriteLine("2. View all orders ");
                            Console.WriteLine("3. Search for an order by orderId");
                            Console.WriteLine("4. Search for orders by Customer Name");
                            Console.WriteLine("5. Create orders for customers");
                            Console.WriteLine("6. Update orders according to order codes");
                            Console.WriteLine("7. Pay order");
                            Console.WriteLine("8. Exit");
                            seclect1 = Management.CreateInteger("seclect", 1, 7);
                            Console.Clear();
                            switch (seclect1)
                            {
                                case 1:
                                    Console.WriteLine("      Show information of Custumer");
                                    Console.WriteLine("  - - - - - - - - - - - - - - - - - -  \n");
                                    Method.ShowInformationCustumer();
                                    break;
                                case 2:
                                    Console.WriteLine("       View all orders");
                                    Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                                    Method.ViewAllOrders();
                                    break;
                                case 3:
                                    Console.WriteLine("      Search for an order by orderId");
                                    Console.WriteLine("  - - - - - - - - - - - - - - - - - - - - - \n");
                                    int idorder = Management.CreateInteger("id of Order", 1);
                                    Method.Find_Order_byIdOrder(idorder);
                                    break;
                                case 4:
                                    Console.WriteLine("      Search for orders by Customer Name");
                                    Console.WriteLine("  - - - - - - - - - - - - - - - - - - - - -  \n");
                                    Method.Find_Order_By_NameCustumer();
                                    break;
                                case 5:
                                    Console.WriteLine("      Create orders for customers");
                                    Console.WriteLine("  - - - - - - - - - - - - - - - - - -  \n");
                                    Method.CreateNewOrderForCUstumer();
                                    break;
                                case 6:
                                    Console.WriteLine("      Update orders according to order codes");
                                    Console.WriteLine("  - - - - - - - - - - - - - - - - - - - - - - - \n");
                                    Method.UpdateOrdersAccording();
                                    break;
                                case 7:
                                    Console.WriteLine("      Payment orders");
                                    Console.WriteLine("  - - - - - - - - - - - - - -  \n");
                                    Method.PayOrderByIdOrder();
                                    break;
                                case 8:
                                    ActionAdmin(id_Custemer);
                                    break;
                            }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Manage all items in the store");
                        Console.WriteLine("  - - - - - - - - - - - - - -  ");
                        choose = -1;
                        while (choose != 0)
                        {
                            Console.WriteLine("\nAdministration of all items.");
                            Console.WriteLine("1. Show Product");
                            Console.WriteLine("2. Add product.");
                            Console.WriteLine("3. Update product.");
                            Console.WriteLine("4. Delete product");
                            Console.WriteLine("5. Find product by codeProduct");
                            Console.WriteLine("6. Exit");
                            choose = Management.CreateInteger("choose", 1, 6);
                            Console.Clear();
                            switch (choose)
                            {
                                case 1:
                                    Console.WriteLine(" *  *  Show Product  *  *\n");
                                    Management.ShowProduct();
                                    break;
                                case 2:
                                    Management.AddProduct();
                                    break;
                                case 3:
                                    Console.WriteLine(" * *  Update product  * *\n");
                                    Management.ShowProduct();
                                    Console.WriteLine();
                                    Management.UpdateProduct();
                                    break;
                                case 4:
                                    Console.WriteLine("*  *   Delete product  *  *\n");
                                    Management.ShowProduct();
                                    Console.WriteLine();
                                    Management.RemoveProduct();
                                    break;
                                case 5:
                                    Management.FindProduct();
                                    break;
                                case 6:
                                    ActionAdmin(id_Custemer);
                                    break;
                            }                         

                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Logged out\n");
                        TakeAction();
                        break;
                }
            }

        }
        static void ActionUser(int id_Custumer)
        {
            int choose = -1;
            while (choose != 0)
            {
                Console.WriteLine("Please seclect of option: ");
                Console.WriteLine("1. Change password");
                Console.WriteLine("2. Create an order");
                Console.WriteLine("3. Show all order");
                Console.WriteLine("4. Find order by id");                
                Console.WriteLine("5. Logout\n");
                choose = Management.CreateInteger("choose", 1, 5);
                Console.Clear();
                switch (choose)
                {
                    case 1:
                        Method.changePassword(id_Custumer);
                        break;
                    case 2:
                        Management.CreateNewOder(id_Custumer);
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        break;
                 
                    case 5:                       
                        Console.WriteLine("Logged out\n");
                        TakeAction();
                        break;

                }
            }
        }
      
    }
}
