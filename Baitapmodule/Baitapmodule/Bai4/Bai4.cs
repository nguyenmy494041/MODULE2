﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Baitapmodule.Bai4
{
    class Bai4
    {
    
        public static void Main()
        {
            int choice = -1;
            Cart cart = new Cart();
            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine("Please select option: ");
                Console.WriteLine("1. Add product in Cart.");
                Console.WriteLine("2. Update product in Cart.");
                Console.WriteLine("3. Delete product in Cart.");
                Console.WriteLine("4. Show product in Cart.");
                Console.WriteLine("5. Pay.");
                Console.WriteLine("0. Exit");
                choice = CreateInteger("choice", 0, 5);
                switch (choice)
                {
                    case 1:
                        AddItems(cart);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        ShowCart(cart);
                        break;
                    case 5:
                        break;
                       
                }
                Console.ReadKey();
            }
            
        }

        public static void UpdateItems(Cart cart)
        {
            int iditem = CreateInteger("Iditem", 1, 100);
            int price = CreateInteger("quantity of product idtem: ", 1, 100);
            foreach (var item in cart.carts)
            {
                if (item.idItem == iditem)
                {
                    cart.carts[iditem].quantityItem = price;
                    break;
                }
            }
        }
        public static void RemoveItems(Cart cart)
        {
            int iditem = CreateInteger("Iditem", 1, 100);
            foreach (var item in cart.carts)
            {
                if(item.idItem == iditem)
                {
                    cart.carts.Remove(item);
                    break;
                }
            }             
        }
        public static void ShowCart(Cart cart)
        {
            Console.WriteLine($"idItem\t\tnameItem\t\tpriceItem\t\tquantityItem");
            foreach (var item in cart.carts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
        public static void AddItems(Cart cart)
        {
            Items items = ChooseProduct();
            if (cart.carts.Count == 0)
            {
                items.idItem = cart.carts.Count + 1;
                cart.carts.Add(items);
            }
            else
            {
                for (int j = 0; j <  cart.carts.Count;j++)
                {
                    if (cart.carts[j].nameItem == items.nameItem)
                    {
                        cart.carts[j].quantityItem += items.quantityItem;
                        break;
                    }
                    if (j == cart.carts.Count-1)
                    {
                        items.idItem = cart.carts.Count + 1;
                        cart.carts.Add(items);
                        break;
                    }
                    
                }
            }
            
        }
        public static Items ChooseProduct()
        {
            bool result; int num;
            List<Product> products = CreateItems();
            Items items = new Items();
            ShowItems();           
            do
            {
                Console.Write("Enter to select from 1 to 6: ");
                result = int.TryParse(Console.ReadLine(), out num);
            } while (!result || num <1 || num > 6);
          
            for (int i = 0; i < products.Count; i++)
            {
                if (i == num - 1)
                {
                    items.nameItem = products[i].name;
                    items.priceItem = products[i].price;
                  
                }
            }
            do
            {
                Console.Write("Enter Quantity: ");
                result = int.TryParse(Console.ReadLine(), out num);
            } while (!result || num < 1 || num > 30);
            items.quantityItem = num;
            return items;      
          
        }
        public static void ShowItems()
        {
            List<Product> products = CreateItems();
            Console.WriteLine("The products are in store: ");
           for(int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1}. {products[i].ToString()}");
            }

        }
        public static List<Product> CreateItems()
        {
            List<string> nameproduct = new List<string> { "Instruction book", "Calculator", "Bluetooth speaker", "Wireless mouse", "Keyboard", "Radiator fan" };
            List<long> priceproduct = new List<long> { 46000, 350000, 150000, 220000, 120000, 80000 };
            List<Product> products = new List<Product>();
            for (int i = 0; i < nameproduct.Count; i++)
            {
                Product product = new Product();
                product.name = nameproduct[i];
                product.price = priceproduct[i];
                products.Add(product);
            }
            return products;
        }
        public static int CreateInteger(string str, int min, int max) 
        {
            int num; bool result;
            do
            {
                Console.Write($"Enter {str}: ");
                result = int.TryParse(Console.ReadLine(), out num);
            } while (!result || num < min||num > max);

            return num;

        }


    }
    public class Cart
    {
        public List<Items> carts { get; set; }
        public Cart()
        {
            carts = new List<Items>();
        }
    }
    public class Items
    {
        public int idItem { get; set; }
        public string nameItem { get; set; }
        public long priceItem { get; set; }
        public int quantityItem { get; set; }
        public Items()
        {

        }
        public override string ToString()
        {
            return $"{idItem}\t\t{nameItem}\t\t{priceItem}\t\t{quantityItem}";
        }
    }
    public class Product
    {
        public string name { get; set; }
        public long price { get; set; }
        public override string ToString()
        {
            return $"{name},   price: {price}VND";
        }
    }
    public class closeTheOrder : Cart
    {

        public long total => Sumprice();
        public long Sumprice()
        {
            long sum = 0;
            foreach (var item in carts)
            {
                sum += item.priceItem * item.quantityItem;
            }
            return sum;
        }
    }
}
