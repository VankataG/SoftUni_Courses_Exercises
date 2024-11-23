namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input.Split();

                string name = elements[0];
                string id = elements[1];
                int age = int.Parse(elements[2]);

                Person personFound = people.FirstOrDefault(person => person.ID == id);
                if (personFound != null)
                {
                    personFound.Name = name;
                    personFound.Age = age;
                }
                else
                {
                    people.Add(new Person(name, id, age));
                }
          
               
            }
            people.Sort((x, y) => x.Age.CompareTo(y.Age));
            

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

            public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
