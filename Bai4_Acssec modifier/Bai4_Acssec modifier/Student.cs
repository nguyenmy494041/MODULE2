using System;
using System.Collections.Generic;
using System.Text;

namespace Bai4_Acssec_modifier
{
    public class Student
    { public static void Main()
        {
            Student1.Change();//calling change method
                             //creating objects
            Student1 s1 = new Student1(111, "P. Schole");
            Student1 s2 = new Student1(222, "P. Pogba");
            Student1 s3 = new Student1(333, "L. Nani");
            //calling display method
            s1.Display();
            s2.Display();
            s3.Display();

        }
    }
    public class Student1
    {
        private int rollno;
        private string name;
        private static string college = "BBDIT";

        //constructor to initialize the variable
        public Student1(int r, string n)
        {
            rollno = r;
            name = n;
        }

        //static method to change the value of static variable

        public static void Change()
        {
            college = "Manchester United";
        }

        //method to display values
        public void Display()
        {
            Console.WriteLine(rollno + " " + name + " " + college);
        }
    }
}
