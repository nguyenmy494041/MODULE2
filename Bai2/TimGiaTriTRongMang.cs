using System;
namespace Bai2
{
    public class TimGiaTriTrongMang
    {
        public static void Main()
        {
            string[] student = { "Christian", "Michael", "Camila", "Sienna", "Tanya", "Connor", "Zachariah", "Mallory", "Zoe", "Emily" };
            Console.WriteLine("Enter name is student: ");
            string name_input = Console.ReadLine();
            byte i;
            for (i = 0; i < student.Length; i++)
            {
                if (name_input == student[i])
                {
                    Console.WriteLine("Position of the students in the list " + name_input + " is: " + (i + 1));
                    break;
                }
            }
            if (i == student.Length)
            {
                Console.WriteLine("Not found " + name_input + " in the list.");
            }

        }
    }
}