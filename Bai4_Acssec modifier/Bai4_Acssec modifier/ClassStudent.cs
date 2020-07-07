using System;
using System.Collections.Generic;
using System.Text;

namespace Bai4_Acssec_modifier
{ public class StudentClass
    {
        public static void Main()
        {
            ClassStudent student1 = new ClassStudent(12, "Hoa Vinh", "Tp. Hue", 24);
            ClassStudent student2 = new ClassStudent();
            student2.Id = 32;
            student2.Name = "Phan Phuc An";
            student2.Address = "Tp. Hue";
            student2.Age = 17;
            Console.WriteLine( student1.ToString());
            Console.WriteLine(student2.ToString());



        }
    }
    class ClassStudent
    {
        private int id;
        private string name;
        private string address;
        private int age;
        public ClassStudent() { }
        public ClassStudent(int _id, string _name, string _address, int _age)
        {
            this.id = _id;
            this.name = _name;
            this.address = _address;
            this.age = _age;
        }
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
        public override string ToString()
        {
            return "Id : " + id + ",Name : " + name + ",Address : " + address + ",Age : " + age;
        }

    }
}
