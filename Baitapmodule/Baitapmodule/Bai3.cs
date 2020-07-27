using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Baitapmodule
{
    class Bai3
    {
        public OrderData orderData = new OrderData();
        static string filePath = $@"E:\CODEGYM\Module2\Baitapmodule\Baitapmodule\Data";
        const int numberTable = 3;
        public static void Main()
        {
           string filePath = $@"E:\CODEGYM\Module2\Baitapmodule\Baitapmodule\Data\datainput.json";
            var orderData = new OrderData();

            //// Nhap du lieu ban dau.
            //using (StreamWriter sw = File.CreateText(filePath))
            //{
            //    OrderData orderData = new OrderData();
            //    orderData.orders.Add(CreateData());
            //    orderData.orders.Add(CreateData());
            //    var datainput = JsonConvert.SerializeObject(orderData);
            //    sw.Write(datainput);
            //}

            // lay du lieu ra
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                orderData = JsonConvert.DeserializeObject<OrderData>(data);
            }

          



        }
        public static void getData()
        {
            var orderData = new OrderData();
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                orderData = JsonConvert.DeserializeObject<OrderData>(data);
            }
        }
        public static Order FindTable(string tableNo, out int position)
        {
            position = -1;
            if (orderData != null && orderData.orders != null)
            {
                foreach (var order in orderData.orders)
                {
                    if (order.tableNo.Equals(tableNo) && !order.paid)
                    {
                        position = orderData.orders.IndexOf(order);
                        return order;
                    }
                }
            }
            return null;
        }
        public static Bill ProcessBill(string tableNo)
        {
            var foundTable = FindTable(tableNo, out int pos);
            if (foundTable != null)
            {
                var bill = new Bill()
                {
                    endtime = DateTime.Now.ToString("hh:mm tt dd/MM/yyyy"),
                    starttime = foundTable.starttime,
                    tableNo = foundTable.tableNo
                };
                bill.orderdetails = new List<OrderDetail>();
                foreach (var detail in foundTable.orderdetails)
                {
                    bill.orderdetails.Add(new OrderDetail()
                    {
                        count = detail.count,
                        money = detail.CalculatorMoney(),
                        name = detail.name,
                        price = detail.price,
                    });
                }
                return bill;
            }
            return null;
        }

        public static bool PrintBill(string tableNo)
        {
            try
            {
                var bill = ProcessBill(tableNo);
                if (bill != null)
                {
                    string fileName = $"bill_{tableNo}_{DateTime.Now.ToString("yyyyMMddhhmm")}.json";
                    using (StreamWriter sw = File.CreateText($@"{filePath}\{fileName}"))
                    {
                        var billData = JsonConvert.SerializeObject(bill);
                        sw.WriteLine(billData);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        static Order CreateData()
        {
            //OrderData orderData = new OrderData();
            bool result; int num, num1, num2;
            Order order = new Order();
            do
            {
                Console.Write("Enter number tableNo: ");
                result = int.TryParse(Console.ReadLine(), out num);

            } while (!result || num <= 0 || num > 30);

            order.tableNo = $"0{num}";
            order.paid = false;
            order.starttime = DateTime.Now.ToString("hh:mm tt dd/MM/yyyy");
            string key = "Y";
            do
            {
                OrderDetail orderDetail = new OrderDetail();
                Console.Write("Input name order: ");
                orderDetail.name = Console.ReadLine();
                do
                {
                    Console.Write("Input number amount: ");
                    result = int.TryParse(Console.ReadLine(), out num1);

                } while (!result || num1 <= 0 || num1 > 100);

                orderDetail.count = num1;
                do
                {
                    Console.Write("Input price: ");
                    result = int.TryParse(Console.ReadLine(), out num2);

                } while (!result || num2 <= 0);

                orderDetail.price = num2;
                order.orderdetails.Add(orderDetail);
                Console.Write("Press N to exit: ");
                key = Console.ReadLine();
            }
            while (string.Compare(key.ToUpper(), "N") != 0);

            //orderData.orders.Add(order);

            return order;
        }

    }
    class OrderData
    {
        public List<Order> orders { get; set; }
        public OrderData()
        {
            orders = new List<Order>();
        }
       
    }
    class Order
    {
        public string tableNo { get; set; }
        public bool paid { get; set; }
        public string starttime { get; set; }
        public List<OrderDetail> orderdetails { get; set; }
        public Order()
        {
            orderdetails = new List<OrderDetail>();
        }
        
    }

    class OrderDetail
    {
        public string name { get; set; }
        public int count { get; set; }
        public long price { get; set; }
        public long money { get; set; }
        public long CalculatorMoney()
        {
            return price * count;
        }
    }
    class Bill : Order
    {
        //public string tableNo { get; set; }
        //public string starttime { get; set; }
        //public string total => SumTotal();
        //public List<OrderDetail> orderdetails { get; set; }
        public string endtime { get; set; }
       

        public long SumTotal()
        {
            long sum = 0;
            foreach (var item in orderdetails)
            {
                sum += item.money;
            }
            return sum;
        }
    }
}
