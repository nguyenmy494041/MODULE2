using System;
using System.Collections.Generic;
using System.Text;

namespace BaitapcuoiModule
{
    public class Customer
    {
        public List<Orders> listorder { get; set; }
        public Customer()
        {
            listorder = new List<Orders>();
        }
    }
    public class Orders
    {
        public int oredrId { get; set; }
        public string nameCustomer { get; set; }
        public string adrees { get; set; }
        public string startime { get; set; }
        public string status { get; set; }
       
        public List<Order> orders { get; set; }
        public long total => Total();
        public Orders()
        {
            orders = new List<Order>();
        }
        public long Total()
        {
            long total = 0;
            foreach (var item in orders)
            {
                total += item.Sum();
            }
            return total;
        }
        public override string ToString()
        {
            string str = "";
            foreach (var item in orders)
            {
                str += item.ToString() + $"\t{item.quantity}\t\t{item.money}\n";
            }
            return $"Order ID: {oredrId}\nCustomer: {nameCustomer}\nAdress: {adrees}\nTime: {startime}\nStatus: {status}\n\n" +
                $"Code\tNameproduct\t\tPriceproduct\tQuantity\tMoney\n" +
                $"{str}";
        }
        public static void ShowItems()
        {
            List<Order> products = CreateOrder();
            Console.WriteLine("The products are in store: ");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].ToString()}");
            }
        }
        public static List<Order> CreateOrder()
        {
            List<string> nameproduct = new List<string> { "Instruction book ", "Calculator       ", "Bluetooth speaker", "Wireless mouse   ", "Keyboard         ", "Radiator fan     " };
            List<long> priceproduct = new List<long> { 46000, 350000, 150000, 220000, 120000, 80000 };
            List<Order> products = new List<Order>();
            for (int i = 0; i < nameproduct.Count; i++)
            {
                Order order = new Order();
                order.nameproduct = nameproduct[i];
                order.priceproduct = priceproduct[i];
                order.codeproduct = $"A{i + 1}";
                products.Add(order);
            }
            return products;

        }
        public class Order
        {
            public string nameproduct { get; set; }
            public string codeproduct { get; set; }
            public long priceproduct { get; set; }
            public int quantity { get; set; }
            public long money => Sum();
            public long Sum()
            {
                return priceproduct * quantity;
            }
            public override string ToString()
            {
                return $"{codeproduct}\t{nameproduct}\t{priceproduct} VND";
            }
        }
    }
    public class Int
    {
        public static int CreateInteger(string str, int? min = null, int? max = null)
        {
            int num; bool result;
            Console.Write($"Enter {str}: ");
            result = int.TryParse(Console.ReadLine(), out num);
            if (min.HasValue)
            {
                if (max.HasValue)
                {
                    while (!result || num < min.Value || num > max.Value)
                    {
                        Console.Write($"Enter again new {str} from {min.Value} to {max.Value}: ");
                        result = int.TryParse(Console.ReadLine(), out num);
                    }
                }
                else
                {
                    while (!result || num < min.Value)
                    {
                        Console.Write($"Enter again new {str} greater than or equal to {min.Value}: ");
                        result = int.TryParse(Console.ReadLine(), out num);
                    }
                }
            }
            else
            {
                while (!result)
                {
                    Console.WriteLine($"Enter again new  {str}: ");
                    result = int.TryParse(Console.ReadLine(), out num);
                }
            }
            return num;
        }
    }
}
