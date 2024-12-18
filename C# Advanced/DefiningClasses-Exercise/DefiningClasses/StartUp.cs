namespace DefiningClasses
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] memberData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = memberData[0];
                int age = int.Parse(memberData[1]);
                people.Add(new Person(name, age));
            }

            foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }




            //---------------------------------------------------------------------------------------------------------

            //Oldest Family Member


            //Family family = new Family();

            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    string[] memberData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            //    string name = memberData[0];
            //    int age = int.Parse(memberData[1]);
            //    family.AddMember(new Person(name, age));
            //}

            //Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);
        }
    }
}
