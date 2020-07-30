using System;
using System.Collections.Generic;
using System.IO;
using static ListOrder.Orders;
using Newtonsoft.Json;

namespace ListOrder
{
    class ListOrder
    {
        public static Customer customer = new Customer();
        public static  int id = 0;

        public static object JsonConvert { get; private set; }

        static void Main(string[] args)
        {
            int choose = -2;
            while (choose!= 0)
            {
                Console.Clear();
                Console.WriteLine("1. Add order");
                Console.WriteLine("2. Update order");
                Console.WriteLine("3. Show order");
                Console.WriteLine("4. Find order by id");
                Console.WriteLine("5. Find order by name");
                Console.WriteLine("6. Pay order");
                Console.WriteLine("0. Exit");
                choose = Int.CreateInteger("choose", 0, 6);
                switch (choose)
                {
                    case 1:
                        AddOrder();
                        break;
                    case 2:
                        UpdateOrder();
                        break;
                    case 3:
                        Show();
                        break;
                    case 4:
                        FindOrderByID();
                        break;
                    case 5:
                        FindOrderByNameCustomer();
                        break;
                    case 6: PayOrder(); 
                        break;

                }
                Console.ReadKey();
            }
           
        }
        static void AddOrder()
        {
            Orders orders = new Orders();

            orders.oredrId = ++id;
            Console.Write("Enter name customer: ");
            orders.nameCustomer = Console.ReadLine();
            Console.Write("Enter adress customer: ");
            orders.adrees = Console.ReadLine();
            orders.startime = DateTime.Now.ToString("hh:mm tt dd/MM/yyyy");
            orders.status = "Order";
           
            string key = "Y";
            do
            {
                List<Order> list = Orders.CreateOrder();
                Order order = new Order();
                Console.WriteLine("List of products: ");
                Orders.ShowItems();
                int choose = Int.CreateInteger("choose", 1, 6);
                for(int i =0; i < list.Count; i++)
                {
                    if(choose  == i + 1)
                    {
                        order.nameproduct = list[i].nameproduct;
                        order.priceproduct = list[i].priceproduct;
                        order.codeproduct = list[i].codeproduct;
                    }
                }
                order.quantity = Int.CreateInteger("quantity", 1, 1000);
                orders.orders.Add(order);
                Console.Write("Continue (Y/N): ");
                key = Console.ReadLine();
            }
            while (key.ToUpper() != "N");
         
            customer.listorder.Add(orders);
            
        }
        static void Show()
        {
            foreach (var item in customer.listorder)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static int FindByIdCustomer(int id)
        {
            int pos = -1;
            for (int i = 0; i < customer.listorder .Count; i++)
            {
                if (customer.listorder[i].oredrId ==id)
                {
                    return pos = i;
                }
            }
            return pos;
        }
        static void UpdateOrder()
        {
            try
            {
                int id = Int.CreateInteger("id of Order", 1);
                int pos = FindByIdCustomer(id);
                int choice = -2;
                while(choice != 0)
                {
                    Console.WriteLine("1. Add new product in orders");
                    Console.WriteLine("2. Update product in orders");
                    Console.WriteLine("3. Delete product in orders");
                    Console.WriteLine("0. Exit");
                    choice = Int.CreateInteger("choice", 0, 3);
                    switch (choice)
                    {
                        case 1:
                            AddProduct(pos);
                            break;
                        case 2:
                            UpdateProduct(pos);
                            break;
                        case 3:
                            RemoveProduct(pos);
                            break;                            
                    }
                }              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message) ;
            }

        }
        static int FindByIdOrder(int pos, string codeproduct)
        {
            try
            {
                int k = -1;
                for (int j = 0; j < customer.listorder[pos].orders.Count; j++)
                {
                    if (customer.listorder[pos].orders[j].codeproduct == codeproduct)
                    {
                        return k = j;
                    }
                }
                return k = -1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error on runtime");
            }
        }
        static void AddProduct(int posOrder)
        {
            string key = "Y";
            do
            {
                List<Order> list = Orders.CreateOrder();
                Order order = new Order();
                Console.WriteLine("List of products: ");
                Orders.ShowItems();
                int choose = Int.CreateInteger("choose", 1, 6);
                for (int i = 0; i < list.Count; i++)
                {
                    if (choose == i + 1)
                    {
                        order.nameproduct = list[i].nameproduct;
                        order.priceproduct = list[i].priceproduct;
                        order.codeproduct = list[i].codeproduct;
                    }
                }
                order.quantity = Int.CreateInteger("quantity", 1, 1000);

                int poss = FindByIdOrder(posOrder, order.codeproduct);
                if (poss == -1)
                {
                    customer.listorder[posOrder].orders.Add(order);
                }
                else
                {
                    customer.listorder[posOrder].orders[poss].quantity += order.quantity;
                }

                Console.Write("Continue (Y/N): ");
                key = Console.ReadLine();
            }
            while (key.ToUpper() != "N");

        }
        static void UpdateProduct(int posOrder)
        {
            Console.Write("Enter code of product: ");
            string code = Console.ReadLine();
            int pos = FindByIdOrder(posOrder, code);
            if (pos != -1)
            {
                int quan = Int.CreateInteger("quantity of product", 1, 1000);
                customer.listorder[posOrder].orders[pos].quantity = quan;
                Console.WriteLine("Fixed purchase information");
            }
            else
            {
                Console.WriteLine("The product is not in the orders");
            }
        }
        static void RemoveProduct(int posOrder)
        {
            Console.Write("Enter code of product: ");
            string code = Console.ReadLine();
            int pos = FindByIdOrder(posOrder, code);
            if (pos != -1)
            {
                customer.listorder[posOrder].orders.RemoveAt(pos);
                Console.WriteLine("Product deleted");
            }
            else
            {
                Console.WriteLine("The product is not in the orders");
            }
        }
        static void FindOrderByID()
        {
            int idorder = Int.CreateInteger("id of order", 1);
            int pos = FindByIdCustomer(idorder);
            if( pos != -1)
            {
                Console.WriteLine(customer.listorder[pos].ToString());
            }
            else Console.WriteLine("Not found !");
        }
        static void FindOrderByNameCustomer()
        {
            Console.Write("Enter name customer: ");
            string name = Console.ReadLine();
            int count = 0;
            for( int i = 0; i < customer.listorder.Count; i++)
            {
               if( customer.listorder[i].nameCustomer == name)
                {
                    Console.WriteLine(customer.listorder[i].ToString());
                    count++;
                    Console.WriteLine();
                }
            }
            if (count == 0) Console.WriteLine("Not found !");
            
        }
        static void PayOrder()
        {
            var outfilePath = $@"E:\CODEGYM\Module2\ListOrder\ListOrder\Pay";
            string fileName = $@"Pay__{DateTime.Now.ToString("yyyyMMddhhmm")}.json";
            int idorder = Int.CreateInteger("id order", 1);
            int pos = FindByIdCustomer(idorder);
            if (pos != -1)
            {
                if (customer.listorder[pos].status == "Order")
                {
                    customer.listorder[pos].status = "Payed";

                    using (StreamWriter sw = File.CreateText($@"{outfilePath}\{fileName}"))
                    {
                        var data = customer.listorder[pos];
                        sw.Write(data);
                    }

                }
                else Console.WriteLine("Order was payed!");
            }
            else Console.WriteLine("Not found order!");
        }
        static void WriteDATA()
        {
            var outfilePath = $@"E:\CODEGYM\Module2\ListOrder\ListOrder\DATA\input.json";
            using (StreamWriter sw = File.CreateText(outfilePath))
            {
               
                
            }
        }
    }
}
