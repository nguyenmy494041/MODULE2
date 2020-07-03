namespace HelloWorld
{
    public class Person
    {
        public string name;

        public Person(string _name)
        {
            name = _name;
        }

        public static string GetClassName()
        {
            return "Person";
        }
    }
}