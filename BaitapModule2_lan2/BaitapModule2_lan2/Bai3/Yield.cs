using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
    class Yield
    {
        public List<Product> listProduct { get; set; }
        public Yield()
        {
            listProduct = new List<Product>();
        }
        public static DATA data = new DATA();
        public static Yield yield = new Yield();
        // tao moi 1 san pham
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
        // ghi san pham vao file json
        public static void PushProduct()
        {
            string path = $@"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\listProduct.json";
            using (StreamWriter sw = File.CreateText(path))
            {
                var data = JsonConvert.SerializeObject(yield);
                sw.Write(data);
            }
        }
        // doc danh sach san pham tu file json
        public static void ReadProduct()
        {
            string path = $@"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\listProduct.json";
            using (StreamReader sr = File.OpenText(path))
            {
                var data = sr.ReadToEnd();
                yield = JsonConvert.DeserializeObject<Yield>(data);
            }
        }
        // them san pham vao danh sach
        public static void AddProduct()
        {
            Yield.ReadProduct();
            Product product = Yield.CreateProduct();
            int pos = Yield.Find(product.code_product);
            if (pos == -1)
            {
                yield.listProduct.Add(product);
                Yield.PushProduct();
            }
            else
            {
                Console.WriteLine($"\nProduct exits!");
            }
        }
        // kiem tra xem san pham da co trong danh sach chua, neu co tra ve vi tri
        public static int Find(string code_product)
        {
            for (int i = 0; i < yield.listProduct.Count; i++)
            {
                if (yield.listProduct[i].code_product == code_product)
                {
                    return i;
                }
            }
            return -1;
        }
        // thay doi gia cua san pham
        public static void UpdateProduct()
        {
            Yield.ReadProduct();
            Console.Write("Enter id Product: ");
            string code = Console.ReadLine();
            int pos = Yield.Find(code);

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
                yield.listProduct[pos].price_product = kq;
                Yield.PushProduct();
            }
            else
            {
                Console.WriteLine($"\n Product not exit!");
            }

        }
        // xoa san pham ra khoi danh sach
        public static void RemoveProduct()
        {
            Yield.ReadProduct();
            Console.Write("Enter id Product: ");
            string id = Console.ReadLine();
            int pos = Yield.Find(id);
            if (pos != -1)
            {
                yield.listProduct.RemoveAt(pos);
                Yield.PushProduct();
            }
            else { Console.WriteLine($"\nProduct not exit!"); }
        }
        // show san pham
        public static void ShowProduct()
        {
            Yield.ReadProduct();
            Console.WriteLine("\tCode\tName product\t\tPrice");
            for(int i = 0; i < yield.listProduct.Count; i++)
            {
                Console.WriteLine($"{i+1}\t{yield.listProduct[i].OutString()}");
            }
        }
        // tim san pham
        public static void FindProduct()
        {
            Yield.ReadProduct();
            Console.Write("Enter id Product: ");
            string id = Console.ReadLine();
            int pos = Yield.Find(id);
            if (pos != -1)
            {
                Console.WriteLine("Code\tName product\t\tPrice");
                Console.WriteLine(yield.listProduct[pos].OutString());
            }

        }
        // quan ly tat ca cac mat hang
        public static void AdministrationItems()
        {
            int choose = -1;
            while (choose != 0)
            {
                Console.WriteLine("Administration of all items.");
                Console.WriteLine("1. Show Product");
                Console.WriteLine("2. Add product.");
                Console.WriteLine("3. Update product.");
                Console.WriteLine("4. Delete product");
                Console.WriteLine("5. Find product by codeProduct");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter choose: ");
                string str = Console.ReadLine();
                int num;
                bool result = int.TryParse(str, out num);
                while (!result || num < 0 || num > 5)
                {
                    Console.Write(" Enter choose from 0 to 5: ");
                    str = Console.ReadLine();                    
                    result = int.TryParse(str, out num);
                }
                choose = num;
                switch (choose)
                {
                    case 1:
                        ShowProduct();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        UpdateProduct();
                        break;
                    case 4:
                        RemoveProduct();
                        break;
                    case 5:
                        FindProduct();
                        break;
                }
                Console.ReadKey();

            }
        }
        // tao don hang
        public static void CreateNewOder(int id_Custumer)
        {
            Oder oder = new Oder();
            Method.ReadOnMember();
            int pos_Custumer = Yield.FindIndexOfIdCustumer(id_Custumer);
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
                    Yield.ShowProduct();
                    Console.Write("\nEnter the Code to select the product: ");
                    string code = Console.ReadLine();
                    int pos = Yield.Find(code);
                    while (pos == -1)
                    {
                        Console.Write("\nNot found! Enter again the Code to select the product: ");
                        code = Console.ReadLine();
                        pos = Yield.Find(code);
                    }
                    product.code_product = code;
                    product.name_product = yield.listProduct[pos].name_product;
                    product.price_product = yield.listProduct[pos].price_product;
                    product.quantity_product = Yield.CreateInteger("quantity", 1, 10000);
                    if (oder.products.Count == 0) 
                    { 
                        oder.products.Add(product); 
                    }
                    else
                    {
                        for(int i = 0; i < oder.products.Count; i++)
                        {
                            if (oder.products[i].code_product == product.code_product)
                            {
                                oder.products[i].quantity_product += product.quantity_product;
                            }
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
        // tao 1 so nguyen
        public static int CreateInteger(string str, int? min = null, int? max = null)
        {
            int num; bool result;
            Console.WriteLine($"Enter {str}: ");
            result = int.TryParse(Console.ReadLine(), out num);
            if (min.HasValue)
            {
                if (max.HasValue)
                {
                    while (!result || num < min.Value || num > max.Value)
                    {
                        Console.WriteLine($"Enter again new {str} from {min.Value} to {max.Value}: ");
                        result = int.TryParse(Console.ReadLine(), out num);
                    }
                }
                else
                {
                    while (!result || num < min.Value)
                    {
                        Console.WriteLine($"Enter again new {str} greater than or equal to {min.Value}: ");
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
        // ham tra ve vi tri cua User trong Custumer
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
        // tim xem san pham da co trong Oder ko, tra ve vi tri
        public static int FindIndexProductInOder(int id_Custumer,int id_Oder,string code_product)
        {
            Method.ReadOnMember();
            int pos_Custumer = Yield.FindIndexOfIdCustumer(id_Custumer);
            int pos_Oder = Yield.FindIndexOderInOders(id_Custumer, id_Oder);
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
        // tim vi tri cua Oder trong Odres
        public static int FindIndexOderInOders(int id_Custumer, int id_Oder)
        {
            Method.ReadOnMember();
            int pos_Custumer = Yield.FindIndexOfIdCustumer(id_Custumer);
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
