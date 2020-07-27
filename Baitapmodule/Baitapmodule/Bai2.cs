using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Baitapmodule
{
    class Bai2
    {
        const int numberStudent = 3;
        static void Main()
        {
            var filePath = $@"E:\CODEGYM\Module2\Baitapmodule\Baitapmodule\Data\data.json";
            var outfilePath = $@"E:\CODEGYM\Module2\Baitapmodule\Baitapmodule\Data\Outcome.json";
            var result = new Students();

            // write file data.json
            using (StreamWriter sw = File.CreateText(filePath))
            {
                Students students = new Students();
                students = CreateData();
                var datainput = JsonConvert.SerializeObject(students);
                sw.Write(datainput);
            }


            // read file data.json
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Students>(data);
            }

            // xu ly du lieu
            var processing = new ProcessingData()
            {
                students = new List<ResStudent>()
            };
           
            foreach (var std in result.students)
            {
                processing.students.Add(new ResStudent()
                {
                    code = std.code,
                    average = std.AverageScore(),
                    gender = std.gender,
                    fullname = std.fullname,
                    subject = std.subject,
                    rank = std.RankedAcademic(std.AverageScore())
                });
            }
            processing.students.Sort(new AverageScoreComparer());
            processing.students.Reverse();
            using (StreamWriter sw = File.CreateText(outfilePath))
            {
                var data = JsonConvert.SerializeObject(processing);
                sw.Write(data);
            }
          
        }
        static Students CreateData()
        {
            List<string> nameSubject = new List<string> { "Math", "Physical", "Chemistry" };
            Students students = new Students();
            for (int i = 0; i < numberStudent; i++)
            {
                Student student = new Student();
                Console.Write($"Enter code student_{i + 1}: ");
                student.code = Console.ReadLine();
                Console.Write($"Enter fullname student_{i + 1}: ");
                student.fullname = Console.ReadLine();
                Console.Write($"Enter gender student_{i + 1}: ");
                student.gender = Console.ReadLine();

                foreach (var item in nameSubject)
                {
                    Subject subject = new Subject();
                    bool result; float number;
                    subject.name = item;
                    do
                    {
                        Console.Write($"Enter score {item}: ");
                        result = float.TryParse(Console.ReadLine(), out number);

                    } while (!result || number <= 0 || number > 10.0);
                    subject.score = number;

                    student.subject.Add(subject);
                }
                students.students.Add(student);
                Console.WriteLine();
            }
            return students;
        }

    }


    public class Students
    {
        public List<Student> students { get; set; }
        public Students()
        {
            students = new List<Student>();
        }

    }
    public class Student
    {
        public string code { get; set; }
        public string fullname { get; set; }
        public string gender { get; set; }
        public List<Subject> subject { get; set; }
        public Student()
        {
            this.subject = new List<Subject>();
        }
        public override string ToString()
        {
            return $"{code}\t{fullname}\t{gender}\t\t{subject[0].score}" +
                $"\t\t{subject[1].score}\t\t{subject[2].score}" +
                $"\t{AverageScore()}\t{RankedAcademic(AverageScore())}";
        }
        public double AverageScore()
        {
            double total = 0.0f;
            foreach (var item in subject)
            {
                if (item.name == "Math")
                {
                    total += item.score * 2;
                }
                else
                {
                    total += item.score;
                }
            }
            return Math.Round(total / (subject.Count + 1), 2);
        }
        public string RankedAcademic(double ave)
        {
            if (ave >= 9.0f) return "Excellent";
            if (ave >= 8.0f) return "Great";
            if (ave >= 7.0f) return "Pretty";
            if (ave >= 6.5f) return "Quite_good";
            if (ave >= 5.0f) return "Average";
            if (ave >= 3.5f) return "Weak";
            return "Least";
        }
    }
    public class Subject
    {
        public string name { get; set; }
        public float score { get; set; }
    }
    public class ProcessingData
    {
        public List<ResStudent> students { get; set; }
    }

    public class ResStudent : Student
    {
        public double average { get; set; }
        public string rank { get; set; }
    }
    public class AverageScoreComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.AverageScore().CompareTo(y.AverageScore());
        }
    }
}