namespace _05._Filter_By_Age
{
    internal class FilterByAge
    {

        static void Main(string[] args)
        {

            //Read input
            List<Person> people = ReadList(new List<Person>());

            //Read condition and age threshold
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());

            //Create new List with the given condition
            List<Person> filteredPeople = new();
            switch (condition)
            {
                case "older":
                    filteredPeople = people.Where(x => x.Age >= ageThreshold).ToList();
                    break;
                case "younger":
                    filteredPeople = people.Where(x => x.Age < ageThreshold).ToList();
                    break;
            }

            //Print with the given format
            string printFormat = Console.ReadLine();
            switch (printFormat)
            {
                case "name":
                    filteredPeople.ForEach(x => Console.WriteLine(x.Name));
                    break;
                case "age":
                    filteredPeople.ForEach(x => Console.WriteLine(x.Age));
                    break;
                case "name age":
                    filteredPeople.ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
                    break;

            }

        }


        static List<Person> ReadList(List<Person> people)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personInfo[0], int.Parse(personInfo[1])));
            }
            return people;
        }

        class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
