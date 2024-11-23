namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        public class Family
        {
            public List<Person> People { get; set; } = new();
            public void AddMember(Person person)
            {
                People.Add(person);
            }
            public Person GetOldestMember(List< Person> family)
            {
                return family.OrderByDescending(x => x.Age).First();
                
            }
        public class Person
        {
            public Person(string name,int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person newPerson = new Person(input[0], int.Parse(input[1]));
                family.AddMember(newPerson);
            }
            Person oldest = family.GetOldestMember(family.People);
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
