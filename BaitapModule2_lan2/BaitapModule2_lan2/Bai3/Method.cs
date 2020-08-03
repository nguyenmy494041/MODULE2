using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
   public class Method
    {
                
        public static DATA data = new DATA();
       public static void Create_User(User user)
        {
            ReadOnMember();
            if (user.Isadmin)
            {
                User user1 = User.CreateUser();
                Custumer custumer = new Custumer();
                user1.Isadmin = false;
                user1.user_id = Method.FindMaxIsCustumer()+1;
                data.members.Add(user1);
                Console.WriteLine("\nCreate user successfully");
                custumer.id_custumer = user1.user_id;
                Console.WriteLine("Fill in user information");
                Console.Write("Enter name Custumer: ");
                custumer.name_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter adress Custumer: ");
                custumer.adress_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter numberPhone Custumer:  ");
                string str = Console.ReadLine();
                while (!Method.Test_numberPhone(str))
                {
                    Console.Write("Enter again numberPhone Custumer:  ");
                    str = Console.ReadLine();
                }
                custumer.number_phone = str;
                data.custumers.Add(custumer);
                PushInDATA();
                
            }          
        }
        
        public static bool Test_numberPhone(string str)
        {
            long num;
            bool sdt = long.TryParse(str, out num);
            if ((str.Length == 10) && sdt && str[0] =='0') return true;
            return false;

        }
        public static void Create_Admin(User user)
        {
            ReadOnMember();
            if (user.Isadmin)
            {
                User user1 = User.CreateUser();
                Custumer custumer = new Custumer();
                user1.Isadmin = true;
                user1.user_id = Method.FindMaxIsCustumer() + 1;
                data.members.Add(user1);
                Console.WriteLine("\nCreate Admin successfully");
                custumer.id_custumer = user1.user_id;
                Console.WriteLine("Fill in user information");
                Console.Write("Enter name Custumer: ");
                custumer.name_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter adress Custumer: ");
                custumer.adress_custumer = Method.RemoveWhitespace((Console.ReadLine().Trim()));
                Console.Write("Enter numberPhone Custumer:  ");
                string str = Console.ReadLine();
                while (!Method.Test_numberPhone(str))
                {
                    Console.Write("Enter again numberPhone Custumer:  ");
                    str = Console.ReadLine();
                }
                custumer.number_phone = str;
                data.custumers.Add(custumer);
                PushInDATA();
               
            }
        }
        public static void PushInDATA()
        {
            string Path = @"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\database.json";
            using(StreamWriter sw = File.CreateText(Path))
            {
                var DATA = JsonConvert.SerializeObject(data);
                sw.Write(DATA);

            }
        }
        public static void ReadOnMember()
        {
            string Path = @"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\database.json";
            using (StreamReader sr = File.OpenText(Path))
            {
                var dataa = sr.ReadToEnd();
                data= JsonConvert.DeserializeObject<DATA>(dataa);
            }
        }       
        public static int FindMaxIsCustumer()
        {
            if (data.members.Count == 0) return 0;
            else
            {
                int max = data.members[0].user_id;
                foreach (var item in data.members)
                {
                    if(max < item.user_id)
                    {
                        max = item.user_id;
                    }
                }
                return max;
            }
        }
        public static bool ExitUser(string nameUser, out int index)
        {
            index = -1;
            for(int i = 0; i < data.members.Count; i++)
            {
                if (data.members[i].user_name == nameUser)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        public static bool IsPasswordofUser(int index, string pass)
        {
            if (data.members[index].user_password == pass) return true;
            return false;

        }
        public static void Login(out bool IsAdmin, out int id_Custumer)
        {
            Method.ReadOnMember();
            Console.Write("Enter User: ");
            string user = (Console.ReadLine()).Trim();

            var isUserExited = Method.ExitUser(user, out int index);
            while (!isUserExited)
            {            
                Console.Write("User not Exit! Re-enter the user: ");
                user = (Console.ReadLine()).Trim();
                isUserExited = Method.ExitUser(user, out index);
            }
           
            Console.Write("Enter password: ");
            string pass = (Console.ReadLine()).Trim();
            while (!IsPasswordofUser(index, pass))
            {
                Console.Write("Incorrect password! Re_enter the password: ");
                pass = (Console.ReadLine()).Trim();
            }
            IsAdmin = data.members[index].Isadmin;
            id_Custumer = data.members[index].user_id;
        }
        public static string RemoveWhitespace(string str)
        {
            string[] data = str.Split(' ');
            return string.Join("", data); 
        }
        public static void ShowAccounts()
        {
            Console.Clear();
            Console.WriteLine("- - - - Account list - - - -");
            Method.ReadOnMember();
            Console.WriteLine("Id\tuser name\t\tuser mail\t\t\tuser password\t\tIsadmin");
            foreach (var item in data.members)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void changePassword( int id_Custumer)
        {
            Console.Clear();
            Method.ReadOnMember();
            Console.WriteLine("- - - - Change Password - - - -");
            Console.Write("Enter current password: ");
            string pass = (Console.ReadLine()).Trim();
            int pos = Method.FindMemberById(id_Custumer);
            while (data.members[pos].user_password!= pass)
            {
                Console.Write("Enter again current password: ");
                 pass = (Console.ReadLine()).Trim();
            }
            Console.Write("Enter new user password: ");
            string pass1 = (Console.ReadLine()).Trim();
            while (!User.Testpass(pass1))
            {
                Console.Write("Enter new user password minimum of 8 characters and non-Space : ");
                pass1 = (Console.ReadLine()).Trim();
            }
            Console.Write("Enter reenter password: ");
            data.members[pos].user_password = (Console.ReadLine()).Trim();
            while (data.members[pos].user_password != pass1)
            {
                Console.Write("Enter again confirm password: ");
                data.members[pos].user_password = (Console.ReadLine()).Trim();
            }
            Method.PushInDATA();
        }
        public static int FindMemberById(int id_Custumer)
        {
            for (int i = 0; i < data.members.Count; i++)
            {
                if (data.members[i].user_id == id_Custumer) return i;
               
            }
            return -1;
        }
        public static void ShowInformationCustumer()
        {
            Console.Clear();
            Method.ReadOnMember();
            Console.WriteLine("Show information Custumer: \n");
            Console.WriteLine("id\t Name\t\t\t Adress\t\t\tGmail\t\t\t\tPhone");
            for (int i = 0; i < data.members.Count; i++)
            {
                Console.WriteLine($"{data.members[i].user_id}\t{data.custumers[i].name_custumer}\t\t{data.custumers[i].adress_custumer}" +
                    $"\t\t{data.members[i].user_mail}\t\t{data.custumers[i].number_phone}");
            }
        }
        public static void ViewAllOrders()
        {
            foreach (var item in data.custumers)
            {
                Console.WriteLine($"Custumer: {item.name_custumer}");
                Console.WriteLine($"Adress: {item.adress_custumer}\n");
                foreach (var oder in item.oders)
                {
                    Console.WriteLine($"\tOrder Id: {oder.OrderId}");
                    Console.WriteLine($"\tTime order: {oder.timeOrder}");
                    Console.WriteLine($"\tStatus: {oder.status}\n");
                    Console.WriteLine($"\tCode\tName product\t\tprice\t\tquantity\tmoney");
                    foreach (var pro in oder.products)
                    {
                        Console.WriteLine($"\t{pro.code_product}\t{pro.name_product}\t\t{pro.price_product}\t\t{pro.quantity_product}\t\t{pro.pay_money}");
                    }
                    Console.WriteLine("\n");
                }
            }
        }
        public static int Find_IdOrder(int idorder,out int index_custumer) 
        {
           
            Method.ReadOnMember();
            for (int i = 0; i < data.custumers.Count; i++)
            {
                for (int j = 0; j < data.custumers[i].oders.Count; j++)
                {
                    if (data.custumers[i].oders[j].OrderId == idorder) 
                    {
                        index_custumer = i;
                        return j; 
                    }
                }

            }
            index_custumer = -1;
            return -1;

        }
        public static void Find_Order_byIdOrder(int idorder)
        {
            Method.ReadOnMember();
           
            int pos = Method.Find_IdOrder(idorder, out int index_custumer);
            if(pos != -1)
            {
                Console.WriteLine($"\nId Order: {idorder}");
                Console.WriteLine($"Custumer: {data.custumers[index_custumer].name_custumer}");
                Console.WriteLine($"Adress: {data.custumers[index_custumer].adress_custumer}");
                Console.WriteLine($"Phone: {data.custumers[index_custumer].number_phone}");               
                Console.WriteLine($"Time order: {data.custumers[index_custumer].oders[pos].timeOrder}");
                Console.WriteLine($"Status: {data.custumers[index_custumer].oders[pos].status}\n");
                Console.WriteLine($"Code\tName product\t\tprice\t\tquantity\tmoney");
                foreach (var pro in data.custumers[index_custumer].oders[pos].products)
                {
                    Console.WriteLine($"{pro.code_product}\t{pro.name_product}\t\t{pro.price_product}\t\t{pro.quantity_product}\t\t{pro.pay_money}");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Not found Order!");
            }
        }
        public static void Find_Order_By_NameCustumer()
        {
            int i;
            Method.ReadOnMember();
            Console.Write("Enter name Custumer: ");
            string name = Method.RemoveWhitespace(Console.ReadLine().Trim());
            for ( i = 0; i < data.custumers.Count; i++)
            {
                if(data.custumers[i].name_custumer == name)
                {
                    Console.WriteLine($"Custumer: {name}");
                    Console.WriteLine($"Adress: {data.custumers[i].adress_custumer}\n");
                    for(int j = 0; j < data.custumers[i].oders.Count; j++ )
                    {
                        Console.WriteLine($"\tOrder Id: {data.custumers[i].oders[j].OrderId}");
                        Console.WriteLine($"\tTime order: {data.custumers[i].oders[j].timeOrder}");
                        Console.WriteLine($"\tStatus: {data.custumers[i].oders[j].status}\n");
                        Console.WriteLine($"\tCode\tName product\t\tprice\t\tquantity\tmoney");
                        for (int  k = 0; k < data.custumers[i].oders[j].products.Count;k++)
                        {
                            Console.WriteLine($"\t{data.custumers[i].oders[j].products[k].code_product}" +
                                $"\t{data.custumers[i].oders[j].products[k].name_product}" +
                                $"\t\t{data.custumers[i].oders[j].products[k].price_product}" +
                                $"\t\t{data.custumers[i].oders[j].products[k].quantity_product}" +
                                $"\t\t{data.custumers[i].oders[j].products[k].pay_money}");
                        }
                        Console.WriteLine("\n");
                    }
                    break;
                }
            }
            if (i == data.custumers.Count)
            {
                Console.WriteLine("Not found Custumer!");
            }
        }
        public static void CreateNewOrderForCUstumer()
        {
            int id_custumer,i;
            Method.ReadOnMember();
            Console.Write("Enter name Custumer: ");
            string name = Method.RemoveWhitespace(Console.ReadLine().Trim());
            for(i = 0; i < data.custumers.Count; i++)
            {
                if(data.custumers[i].name_custumer == name)
                {
                    id_custumer = data.custumers[i].id_custumer;
                    Management.CreateNewOder(id_custumer);
                    break;
                }
               
            }
            if( i == data.custumers.Count)
            {
                Console.WriteLine("Not found Custumer!");
            }
        }
        public static void UpdateOrdersAccording()
        {
            Method.ReadOnMember();
            int idorder = Management.CreateInteger("id of Order", 1);
            int pos1 = Method.Find_IdOrder(idorder, out int index_custumer);
            int keyof = index_custumer;
            if(pos1!= -1)
            {
                int choose = -1;
                while (choose !=4)
                {
                    Find_Order_byIdOrder(idorder);
                    Console.WriteLine("\n1. Add product on Order");
                    Console.WriteLine("2. Remove product on Order");
                    Console.WriteLine("3. Update product on Order");
                    Console.WriteLine("4. Exit");
                    choose = Management.CreateInteger("choose", 1, 4);
                    Console.Clear();
                    Find_Order_byIdOrder(idorder);
                    switch (choose)
                    {
                        case 1:
                          
                            string key = "Y";
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\n   *   *  Add product on Order   *  * \n");
                                Find_Order_byIdOrder(idorder);
                                Product product = new Product();
                                Console.WriteLine("\nProduct list in store");
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
                                product.name_product = Management.management.listProduct[pos].name_product;
                                product.price_product = Management.management.listProduct[pos].price_product;
                                product.quantity_product = Management.CreateInteger("quantity", 1, 10000);
                                int j;
                                if (data.custumers[keyof].oders[pos1].products.Count == 0)
                                {
                                    data.custumers[keyof].oders[pos1].products.Add(product);
                                }
                                else
                                {
                                    for (j = 0; j < data.custumers[keyof].oders[pos1].products.Count; j++)
                                    {
                                        if (data.custumers[keyof].oders[pos1].products[j].code_product == product.code_product)
                                        {
                                            data.custumers[keyof].oders[pos1].products[j].quantity_product += product.quantity_product;
                                            break;
                                        }

                                    }
                                    if (j == data.custumers[keyof].oders[pos1].products.Count)
                                    {
                                        data.custumers[keyof].oders[pos1].products.Add(product);
                                    }
                                }
                                Method.PushInDATA();
                                Console.Write("Continue? (Y/N): ");
                                key = Console.ReadLine();

                            }
                            while (key.ToUpper() != "N");
                            Console.Clear();
                            break;
                        case 2:
                           
                            key = "Y";
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\n   *   * Update product on Order  *  * \n");
                                Find_Order_byIdOrder(idorder);
                                //Management.ShowProduct();
                                Console.Write("\nEnter the Code to select the product: ");
                                string code = Console.ReadLine();
                                for (int i = 0; i < data.custumers[keyof].oders[pos1].products.Count; i++)
                                {
                                    if(data.custumers[keyof].oders[pos1].products[i].code_product == code)
                                    {
                                        data.custumers[keyof].oders[pos1].products.RemoveAt(i);
                                        Console.WriteLine("Product deleted");
                                        break;
                                    }
                                }
                                Method.PushInDATA();
                                Console.Write("Continue? (Y/N): ");
                                key = Console.ReadLine();
                            }
                            while (key.ToUpper() != "N");
                            Console.Clear();
                            break;
                        case 3:
                           
                            key = "Y";
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\n   *   * Remove product on Order  *  * \n");
                                Find_Order_byIdOrder(idorder);
                                //Management.ShowProduct();
                                Console.Write("\nEnter the Code to select the product: ");
                                string code = Console.ReadLine();
                                int quan = Management.CreateInteger("quantity", 1);
                                for (int i = 0; i < data.custumers[keyof].oders[pos1].products.Count; i++)
                                {
                                    if (data.custumers[keyof].oders[pos1].products[i].code_product == code)
                                    {
                                        data.custumers[keyof].oders[pos1].products[i].quantity_product = quan;
                                        Console.WriteLine("Purchase quantity has been changed");
                                        break;
                                    }
                                }
                                Method.PushInDATA();
                                Console.Write("Continue? (Y/N): ");
                                key = Console.ReadLine();
                            }
                            while (key.ToUpper() != "N");
                            Console.Clear();
                            break;
                    }
                }             

            }
            else
            {
                Console.WriteLine("Not found Order!");
            }
            //Method.PushInDATA();

        }
        public static void PayOrderByIdOrder()
        {
           
            Method.ReadOnMember();
            int idorder = Management.CreateInteger("id Order", 1);
            int pos = Method.Find_IdOrder(idorder, out int index_custumer);
            if(pos!= -1 && data.custumers[index_custumer].oders[pos].status == "Waiting")
            {
                string Path = @"E:\CODEGYM\Module2\BaitapModule2_lan2\BaitapModule2_lan2\Bai3\PayOrder";
                string fileName = $"{DateTime.Now.ToString("dd-MM-yyyy")}__{idorder}";
                PayOrder payOrder = new PayOrder();
                payOrder.Id_Custumer = data.custumers[index_custumer].id_custumer;
                payOrder.Name_Custumer = data.custumers[index_custumer].name_custumer;
                payOrder.Adrres = data.custumers[index_custumer].adress_custumer;
                payOrder.Phone_number = data.custumers[index_custumer].number_phone;
                payOrder.status = "Payed";
                payOrder.products = data.custumers[index_custumer].oders[pos].products;
                data.custumers[index_custumer].oders[pos].status = "Payed";
                using(StreamWriter sw = File.CreateText($@"{Path}\{fileName}"))
                {
                    var dada = JsonConvert.SerializeObject(payOrder);
                    sw.Write(dada);
                }
                Method.PushInDATA();
                Console.WriteLine("Payment success");
            }
            else
            {
                Console.WriteLine("Not found Order or Order Payed!");
            }
           

        }
        public static void ShowAllOrderByCustumer(int id_Custumer)
        {
            Method.ReadOnMember();
            int index = -1;
            for (int i = 0; i < data.custumers.Count; i++)
            {
                if(data.custumers[i].id_custumer == id_Custumer)
                {
                    index = i;
                    break;
                }
            }
            if(index!= -1)
            {
                Console.WriteLine($"Custumer: {data.custumers[index].name_custumer}");
                Console.WriteLine($"Adress: {data.custumers[index].adress_custumer}\n");
                foreach (var oder in data.custumers[index].oders)
                {
                    Console.WriteLine($"\tOrder Id: {oder.OrderId}");
                    Console.WriteLine($"\tTime order: {oder.timeOrder}");
                    Console.WriteLine($"\tStatus: {oder.status}\n");
                    Console.WriteLine($"\tCode\tName product\t\tprice\t\tquantity\tmoney");
                    foreach (var pro in oder.products)
                    {
                        Console.WriteLine($"\t{pro.code_product}\t{pro.name_product}\t\t{pro.price_product}\t\t{pro.quantity_product}\t\t{pro.pay_money}");
                    }
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("Not found !");
            }
           
        }
        public static void FindOrderOFCustumer(int id_Custumer)
        {
            Method.ReadOnMember();
            int index = -1, pos = -1;
            for (int i = 0; i < data.custumers.Count; i++)
            {
                if (data.custumers[i].id_custumer == id_Custumer)
                {
                    index = i;
                    break;
                }
            }
            int idorder = Management.CreateInteger("id order", 1);
            for (int i = 0; i < data.custumers[index].oders.Count; i++)
            {
                if (data.custumers[index].oders[i].OrderId == idorder)
                {
                    pos = i;
                    break;
                }
            }
            if (pos != -1)
            {
                Console.WriteLine($"\nId Order: {idorder}");
                Console.WriteLine($"Custumer: {data.custumers[index].name_custumer}");
                Console.WriteLine($"Adress: {data.custumers[index].adress_custumer}");
                Console.WriteLine($"Phone: {data.custumers[index].number_phone}");
                Console.WriteLine($"Time order: {data.custumers[index].oders[pos].timeOrder}");
                Console.WriteLine($"Status: {data.custumers[index].oders[pos].status}\n");
                Console.WriteLine($"Code\tName product\t\tprice\t\tquantity\tmoney");
                foreach (var pro in data.custumers[index].oders[pos].products)
                {
                    Console.WriteLine($"{pro.code_product}\t{pro.name_product}\t\t{pro.price_product}\t\t{pro.quantity_product}\t\t{pro.pay_money}");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Not found Order!");
            }

        }
    }
}
