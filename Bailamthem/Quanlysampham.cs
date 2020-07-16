using System;
using System.Collections.Generic;
using System.Text;

namespace Bailamthem
{
    class Quanlysampham
    {
        public static void Main()
        {
            int choise = -1;
            while (choise != 0)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Show product.");
                Console.WriteLine("2. Add product.");
                Console.WriteLine("3. Edit product");
                Console.WriteLine("4. Delete product");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter the choice: ");
                choise = Byte.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        ProductService.Show();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        EditProduct();
                        break;
                    case 4:
                        RemoveProduct();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No choice!");
                        break;
                }

            }




            // AddProduct();
            // CreateProduct();
            // CreateProduct();
            // ProductService.Show();
            // RemoveProduct();
            // EditProduct();
            // ProductService.Show();
        }
        public static ProductService ProductService = new ProductService();
        public static void AddProduct()
        {
            string key = "Y";
            do
            {
                var product = new Product();
                Console.Write("Product name: ");
                product.Name = Console.ReadLine();
                Console.Write("Product Code: ");
                product.Code = Console.ReadLine();
                Console.Write("Price: ");
                product.Price = double.Parse(Console.ReadLine());
                Console.Write("Product date: ");
                product.Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Manufactory: ");
                product.Manufactory = Console.ReadLine();
                // Random rnd = new Random();
                // var product = new Product()
                // {
                //     Code = rnd.Next(1000, 9999).ToString(),
                //     Date = DateTime.Parse("2020/07/07"),
                //     Manufactory = "USA",
                //     Name = "IP6",
                //     Price = 5000000
                // };
                ProductService.Add(product);
                Console.Write("continue? (Y/N): ");
                key = Console.ReadLine();
            } while (key.ToUpper() != "N");
        }


        public static void RemoveProduct()
        {
            string key = "Y";
            do
            {
                Console.Write("Enter code: ");
                var code = Console.ReadLine();
                ProductService.Delete(code);
                Console.Write("continue? (Y/N): ");
                key = Console.ReadLine();
            } while (key.ToUpper() != "N");

        }
        public static void EditProduct()
        {
            ProductService.Show();
            string key = "Y";
            do
            {
                Console.WriteLine("Enter code: ");
                var code = Console.ReadLine();
                ProductService.Edit(code);
                Console.Write("continue? (Y/N): ");
                key = Console.ReadLine();
            } while (key.ToUpper() != "N");

        }
    }








    class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string Manufactory { get; set; }

        public string ShowProductInfo()
        {
            return $"{Name}\t{Code}\t{Price}\t{Date.ToString("ddd, MMM dd yyyy")}\t{Manufactory}";
        }
    }






    class ProductService
    {
        public Product[] products = new Product[0];
        public void Add(Product product)
        {
            Array.Resize(ref products, products.Length + 1);
            products[products.Length - 1] = product;
        }
        private int FindProduct(string code)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Code.ToUpper() == code.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }

        public void Edit(string code)
        {
            int pos = FindProduct(code);
            if (pos != -1)
            {
                Console.Write("Name: ");
                products[pos].Name = Console.ReadLine();
                Console.Write("Price: ");
                products[pos].Price = double.Parse(Console.ReadLine());
                Console.Write("Manufactory: ");
                products[pos].Manufactory = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Code: {code} not found");
            }
        }

        public void Delete(string code)
        {
            var pos = FindProduct(code);
            if (pos != -1)
            {
                for (int i = pos; i < products.Length - 1; i++)
                {
                    products[i] = products[i + 1];
                }
                Array.Resize(ref products, products.Length - 1);
            }
            else
            {
                Console.WriteLine($"Code: {code} not found");
            }
        }

        public void Show()
        {
            string table = $"Name\tCode\tPrice\tDate\t\t\t Manufactory";
            for (int i = 0; i < products.Length; i++)
            {
                table = table + $"\n" + products[i].ShowProductInfo();
            }
            Console.WriteLine(table);
        }
    }
}
