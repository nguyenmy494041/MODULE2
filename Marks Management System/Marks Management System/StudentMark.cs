using System;
using System.Collections.Generic;
using System.Text;

namespace Marks_Management_System
{
    class StudentMark : IStudentMark
    {
        private string Fullname;
        private string Class;
        private int ID;
        private int Semester;
        private float AverageMark;
        public string theFullname
        {
            get => Fullname;
            set => Fullname = value;
        }
        public string theClass
        {
            get => Class;
            set => Class = value;
        }
        public int theID
        {
            get => ID;
            set => ID = value;
        }
        public int theSumester
        {
            get => Semester;
            set => Semester = value;
        }
        public float theAverageMark
        {
            get => AverageMark;
           
        }

        public void Display()
        {
            Console.WriteLine($"{ID}\t {Fullname}\t {Class}\t  {Semester}\t\t {AverageMark}");
        }
        public int[] SubjectMarkList = new int[5];




        public void AveCal()
        {
            float total = 0;
            foreach(var item in SubjectMarkList)
            {
                total += item;
            }
            AverageMark = total / SubjectMarkList.Length;
        }


    }
}
