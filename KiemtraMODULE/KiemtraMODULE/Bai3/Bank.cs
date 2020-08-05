using System;
using System.Collections.Generic;
using System.Text;

namespace KiemtraMODULE.Bai3
{
    class Bank
    {
        static Dictionary<int, Post> AccountList = new Dictionary<int, Post>();
        static int tempAccountID = 1;
        static void Main(string[] args)
        {
            string choose = "5";
            while (choose != "4")
            {
                Console.WriteLine(" - - - - Management Account - - - - ");
                Console.WriteLine("1. Creat new Account.");
                Console.WriteLine("2. Pay Into.");
                Console.WriteLine("3. Show Customers data.");
                Console.WriteLine("4. Exit.");
                Console.Write("\nEnter you choose: ");
                choose = Console.ReadLine();
                Console.Clear();
                switch (choose)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        PayInto();
                        break;
                    case "3":
                        ShowData();
                        break;
                    case "4":
                        Console.WriteLine(" - - - - EXIT - - - - ");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No choose!");
                        break;
                }
                Console.WriteLine();
            }
        }        
        static void ShowData()
        {
            Console.WriteLine(" - - -Show Customers data - - - \n");
            foreach (var account in AccountList.Values)
            {
                Console.WriteLine(account.ShowInfor());
            }
        }
        static void PayInto()
        {
            Console.WriteLine(" - - - Pay Into - - - \n");
            Console.Write("Enter Account ID: ");
            string id_Account = Console.ReadLine();
            int idAccount;
            while (!int.TryParse(id_Account, out idAccount) || idAccount <= 0)
            {
                Console.Write("Enter again Account ID: ");
                id_Account = Console.ReadLine();
            }
            if (IsAccountID(idAccount))
            {
                Console.Write("Enter Amount: ");
                string strAmount = Console.ReadLine();
                float amount;
                while (!float.TryParse(strAmount, out amount) || amount <= 0)
                {
                    Console.Write("Enter again Amount: ");
                    strAmount = Console.ReadLine();
                }
                foreach (var key in AccountList.Values)
                {
                    if (key.AccountId == idAccount)
                    {
                        key.PayInto(amount);
                    }
                }
                Console.WriteLine("\nPayed into!");
            }
            else
            {
                Console.Write("Account does not exist! Press \"Enter\" to continue...");
                Console.ReadLine();
            }
        }
        static bool IsAccountID(int accountID)
        {
            foreach (var accountId in AccountList.Keys)
            {
                if (accountId == accountID)
                {
                    return true;
                }
            }
            return false;
        }
        static void CreateAccount()
        {
            Console.WriteLine(" - - - Creat new Account - - - ");
            Post account = new Post();
            Console.Write("Enter Frist name: ");
            string fristNameAccount = Console.ReadLine();
            Console.Write("Enter Last name: ");
            string lastNameAccount = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string genderAccount = Console.ReadLine();
            account.AccountId = tempAccountID++;
            account.Fristname = fristNameAccount;
            account.Lastname = lastNameAccount;
            account.Gender = genderAccount;
            AccountList.Add(account.AccountId, account);
            Console.WriteLine("\nCreate new success!");
        }
    }
}   

