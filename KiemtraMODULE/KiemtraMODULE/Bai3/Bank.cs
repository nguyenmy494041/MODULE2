using System;
using System.Collections.Generic;
using System.Text;

namespace KiemtraMODULE.Bai3
{
    class Bank
    {
        static Dictionary<int, Account> AccountList = new Dictionary<int, Account>();
        static int tempAccountID = 1;
        static void Main(string[] args)
        {
            StartManagementAccount();
        }
        static void StartManagementAccount()
        {
            string choice = "5";
            while (choice != "4")
            {
                Console.WriteLine(" - - - - Management Account - - - - ");
                Console.WriteLine("1. Creat Account.");
                Console.WriteLine("2. Pay Into.");
                Console.WriteLine("3. Show Customers data.");
                Console.WriteLine("4. Exit.");
                Console.Write("Enter you choice: ");
                choice = Console.ReadLine();
                switch (choice)
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
                        Console.WriteLine("No choice!");
                        break;
                }
            }
        }
        static void ShowData()
        {
            Console.WriteLine("...Show Customers data...");
            foreach (var account in AccountList.Values)
            {
                Console.WriteLine(account.ShowInfor());
            }
        }
        static void PayInto()
        {
            Console.WriteLine("...Pay Into...");
            Console.Write("Enter Account ID: ");
            string id_Account = Console.ReadLine();
            int idAccount;
            while (!Int32.TryParse(id_Account, out idAccount) || idAccount <= 0)
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
                    Console.Write("Enter again Account ID: ");
                    strAmount = Console.ReadLine();
                }
                foreach (var account in AccountList.Values)
                {
                    if (account.AccountId == idAccount)
                    {
                        account.PayInto(amount);
                    }
                }
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
            Console.WriteLine("...Creat Account...");
            Account account = new Account();
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
        }
    }
}   

