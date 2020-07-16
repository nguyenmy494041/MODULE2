using System;
using System.Collections;
using System.Collections.Generic;

namespace Marks_Management_System
{
    class Program
    {
        public static LinkedList<StudentMark> students = new LinkedList<StudentMark>();
        public static int increment = 0;
        public static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 4)
            {
                string temp;
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("1. Insert New Student. ");
                Console.WriteLine("2. View List Of Student.");
                Console.WriteLine("3. Average Mark.");
                Console.WriteLine("4. Exit");
                do
                {
                    Console.Write("Enter choice:  ");
                    temp = Console.ReadLine();
                }
                while (!IsNumber(temp) || int.Parse(temp) > 4);
               choice = int.Parse(temp);
                switch (choice)
                {
                    case 1:
                        InsertNewStudent();
                        break;
                    case 2:
                        ViewListOfStudent();
                        break;
                    case 3:
                        AverageMark();
                        break;
                }
            }
            
        }
        public static void  InsertNewStudent()
        {
            string temp;
            StudentMark student = new StudentMark();
            increment++;
            student.theID = increment;
            Console.Write("Please input student fullname:  ");
            student.theFullname = Console.ReadLine();
            Console.Write("Please input class name:  ");
            student.theClass = Console.ReadLine();

            do
            {
                Console.Write("Please input semester:  ");
                temp = Console.ReadLine();
            }
            while (!IsNumber(temp) || int.Parse(temp) > 8);
            student.theSumester = int.Parse(temp);

            for (int i =0; i< student.SubjectMarkList.Length; i++)
            {
                do
                {
                    Console.Write($"Please input mark of subject {i+1}:  ");
                    temp = Console.ReadLine();
                }
                while (!IsNumber(temp) || int.Parse(temp) > 100);
                student.SubjectMarkList[i] = int.Parse(temp);
            }
            students.AddFirst(student);
            Console.WriteLine("                  --------------------------                        ");

        }
        public static void ViewListOfStudent()
        {
            Console.WriteLine($"ID\t Fullname\t Class\t  Semester\t AverageMark");
            foreach (StudentMark item in students)
            {
                item.Display();
                Console.WriteLine();
            }
            Console.WriteLine("                  --------------------------                        ");
        }
        public static void AverageMark()
        {
            foreach (StudentMark item in students)
            {
                item.AveCal();
            }
            ViewListOfStudent();
           
        }
        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }


    }
    public interface IStudentMark
    {
        public void Display();
    }
}
