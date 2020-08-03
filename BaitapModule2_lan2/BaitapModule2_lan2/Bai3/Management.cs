using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
    class Management
    {
        public List<Product> listProduct { get; set; }
        public Management()
        {
            listProduct = new List<Product>();
        }
        
        public static Management management = new Management();
      
        public static Product CreateProduct()
        {
            Product product = new Product();
            Console.Write("Enter Code Product: ");
            product.code_product = Console.ReadLine();
            Console.Write("Enter name Product: ");
            product.name_product = Console.ReadLine();
            Console.Write("Enter price Product: ");
            string price = Console.ReadLine();
            long kq; bool result;
            result = long.TryParse(price, out kq);
            while (!result || kq < 0)
            {
                Console.Write("Enter again price Product: ");
                price = Console.ReadLine();
            }
            product.price_product = kq;
            return product;
        }
       
        public static void PushProduct()
        {
            string path = $@"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\listProduct.json";
            using (StreamWriter sw = File.CreateText(path))
            {
                var data = JsonConvert.SerializeObject(management);
                sw.Write(data);
            }
        }
       
        public static void ReadProduct()
        {
            string path = $@"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\listProduct.json";
            using (StreamReader sr = File.OpenText(path))
            {
                var data = sr.ReadToEnd();
                management = JsonConvert.DeserializeObject<Management>(data);
            }
        }
       
        public static void AddProduct()
        {
            Management.ReadProduct();
            Product product = Management.CreateProduct();
            int pos = Management.Find(product.code_product);
            if (pos == -1)
            {
                management.listProduct.Add(product);
                Management.PushProduct();
                Console.WriteLine("Added");
            }
            else
            {
                Console.WriteLine($"\nProduct exits!");
            }
        }
       
        public static int Find(string code_product)
        {
            for (int i = 0; i < management.listProduct.Count; i++)
            {
                if (management.listProduct[i].code_product == code_product)
                {
                    return i;
                }
            }
            return -1;
        }
       
        public static void UpdateProduct()
        {
            Management.ReadProduct();
            Console.Write("Enter id Product: ");
            string code = Console.ReadLine();
            int pos = Management.Find(code);

            if (pos != -1)
            {
                Console.Write("Enter new price Product: ");
                string price = Console.ReadLine();
                long kq; bool result;
                result = long.TryParse(price, out kq);
                while (!result || kq < 0)
                {
                    Console.Write("Enter again new price Product: ");
                    price = Console.ReadLine();
                }
                management.listProduct[pos].price_product = kq;
                Management.PushProduct();
                Console.WriteLine("Fixed purchase information");
            }
            else
            {
                Console.WriteLine($"\n Product not exit!");
            }

        }
       
        public static void RemoveProduct()
        {
            Management.ReadProduct();
            Console.Write("Enter id Product: ");
            string id = Console.ReadLine();
            int pos = Management.Find(id);
            if (pos != -1)
            {
                management.listProduct.RemoveAt(pos);
                Management.PushProduct();
                Console.WriteLine("Product deleted");
            }
            else { Console.WriteLine($"\nProduct not exit!"); }
        }
      
        public static void ShowProduct()
        {
            Management.ReadProduct();
            Console.WriteLine("\tCode\tName product\t\tPrice");
            for(int i = 0; i < management.listProduct.Count; i++)
            {
                Console.WriteLine($"{i+1}\t{management.listProduct[i].OutString()}");
            }
        }
       
        public static void FindProduct()
        {
            Management.ReadProduct();
            Console.Write("Enter id Product: ");
            string id = Console.ReadLine();
            int pos = Management.Find(id);
            if (pos != -1)
            {
                Console.WriteLine("Code\tName product\t\tPrice");
                Console.WriteLine(management.listProduct[pos].OutString());
            }

        }
       
        public static void CreateNewOder(int id_Custumer)
        {
            Oder oder = new Oder();
            Method.ReadOnMember();
            int pos_Custumer = Management.FindIndexOfIdCustumer(id_Custumer);
            if (pos_Custumer != -1)
            {
                if (Method.data.custumers[pos_Custumer].oders.Count == 0)
                {
                    oder.OrderItem = 1;
                }
                else
                {
                    int max = Method.data.custumers[pos_Custumer].oders[0].OrderItem;
                    for (int i = 1; i < Method.data.custumers[pos_Custumer].oders.Count; i++)
                    {
                        if (Method.data.custumers[pos_Custumer].oders[i].OrderItem > max)
                        {
                            max = Method.data.custumers[pos_Custumer].oders[i].OrderItem;
                        }
                    }
                    oder.OrderItem = max + 1;
                }
                oder.status = "Waiting";
                oder.OrderId = int.Parse($"{id_Custumer}{ oder.OrderItem}");
                string key = "Y";
                do
                {
                    Product product = new Product();
                    Console.WriteLine("Product list in store");
                    Management.ShowProduct();
                    Console.Write("\nEnter the Code to select the product: ");
                    string code = Console.ReadLine();
                    int pos = Management.Find(code);
                    while (pos == -1)
                    {
                        Console.Write("\nNot found! Enter again the Code to select the product: ");
                        code = Console.ReadLine();
                        pos = Management.Find(code);
                    }
                    product.code_product = code;
                    product.name_product = management.listProduct[pos].name_product;
                    product.price_product = management.listProduct[pos].price_product;
                    product.quantity_product = Management.CreateInteger("quantity", 1, 10000);
                    int j;
                    if (oder.products.Count == 0) 
                    { 
                        oder.products.Add(product); 
                    }
                    else
                    {
                        for(j = 0; j < oder.products.Count; j++)
                        { 
                            if (oder.products[j].code_product == product.code_product)
                            {
                                oder.products[j].quantity_product += product.quantity_product;
                                break;
                            }
                           
                        }
                        if (j == oder.products.Count)
                        {
                            oder.products.Add(product);
                        }
                    }                   
                    Console.Write("Continue? (Y/N): ");
                    key = Console.ReadLine();               
                
                }
                while (key.ToUpper() != "N");
                Method.data.custumers[pos_Custumer].oders.Add(oder);
                Method.PushInDATA();
            }
        }
       
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
                    Console.Write($"Enter again new  {str}: ");
                    result = int.TryParse(Console.ReadLine(), out num);
                }
            }
            return num;
        }
       
        public static int FindIndexOfIdCustumer(int id_Custumer)
        {
            Method.ReadOnMember();
            for (int i =0; i < Method.data.custumers.Count; i++)
            {
                if (Method.data.custumers[i].id_custumer == id_Custumer)
                    return i;
            }
            return -1;
        }
       
        public static int FindIndexProductInOder(int id_Custumer,int id_Oder,string code_product)
        {
            Method.ReadOnMember();
            int pos_Custumer = Management.FindIndexOfIdCustumer(id_Custumer);
            int pos_Oder = Management.FindIndexOderInOders(id_Custumer, id_Oder);
            if (pos_Custumer != -1)
            {
                if (pos_Oder != -1)
                {
                    for (int i = 0; i < Method.data.custumers[pos_Custumer].oders[pos_Oder].products.Count; i++)
                    {
                        if(Method.data.custumers[pos_Custumer].oders[pos_Oder].products[i].code_product == code_product)
                        {
                            return i;
                        }
                    }return -1;
                }
                return -1;
            }
            return -1;
        }
      
        public static int FindIndexOderInOders(int id_Custumer, int id_Oder)
        {
            Method.ReadOnMember();
            int pos_Custumer = Management.FindIndexOfIdCustumer(id_Custumer);
            if(pos_Custumer!= -1)
            {
                for (int i = 0; i < Method.data.custumers[pos_Custumer].oders.Count; i++)
                {
                    if(Method.data.custumers[pos_Custumer].oders[i].OrderItem == id_Oder)
                    {
                        return i;
                    }
                }return -1;
            }
            return -1;
        }
        

    }
}
