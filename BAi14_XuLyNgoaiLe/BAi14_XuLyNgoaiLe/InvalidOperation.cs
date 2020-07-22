using System;
using System.Collections.Generic;
using System.Text;

namespace BAi14_XuLyNgoaiLe
{
    class InvalidOperation
    { static void Main()
        {
            checked
            {
                try
                {
                    List<Person> listPerson = new List<Person>();
                    listPerson.Add(new Person("Hoang", 23, true));
                    listPerson.Add(new Person("Hoang Nam", 21, false));
                    listPerson.Add(new Person("Huy Hoang", 19, true));
                    listPerson.Add(new Person("Hoang Thien", 18, false));
                    for (int i = 0; i < 2; i++)
                    {
                        listPerson.Remove(listPerson[0]);
                    }
                    foreach (var item in listPerson)
                    {
                        item.Talk();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType());
                }
            }
        }
    }
    public class Person
    {
        private string fullname;
        private int age;
        private bool gender;

        public string Fullname { get => fullname; set => fullname = value; }
        public int Age { get => age; set => age = value; }
        public bool Gender { get => gender; set => gender = value; }
        public Person()
        {

        }
        public Person(string _fullname, int _age, bool _gender)
        {
            this.Fullname = _fullname;
            this.Age = _age;
            this.Gender = _gender;
        }
         
        public void Talk()
        {
            Console.WriteLine($"fullname: {fullname}, age: {age}, gender: {((gender)? "Man":"Women")}.");
        }
    }
}
