using System;
using System.Collections.Generic;
using System.Text;

namespace BaitapModule2_lan2.Bai3
{
    public class DATA
    {
        public List<User> members { get; set; }
        public List<Custumer> custumers { get; set; }
        public DATA()
        {
            members = new List<User>();
            custumers = new List<Custumer>();
        }
    }
   
    public class PayOrder:Oder
    {
        public int Id_Custumer { get; set; }
        public string Name_Custumer { get; set; }
        public string Adrres { get; set; }
        public string Phone_number { get; set; }
        public string timePay => DateTime.Now.ToString("hh:mm tt dd/MM/yyyy");
        public long total => totalmoney();
        public long totalmoney()
        {
            long sum = 0;
            foreach (var item in products)
            {
                sum += item.pay_money;
            }
            return sum;
        }
        public PayOrder()
        {
            products = new List<Product>();
        }
    }

}