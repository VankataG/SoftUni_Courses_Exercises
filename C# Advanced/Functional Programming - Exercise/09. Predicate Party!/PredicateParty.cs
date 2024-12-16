using System.Reflection.PortableExecutable;

namespace _09._Predicate_Party_
{
    internal class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string condition = commands[1];
                string argument = commands[2];

                Predicate<string> filter = GetPredicate(condition, argument);
                
                switch (action)
                {
                    case "Double":
                        List<string> matches = people.FindAll(filter);
                        foreach (var match in matches)
                        {
                            int index = people.IndexOf(match);
                            people.Insert(index + 1, match);
                        }
                        break;

                    case "Remove":
                        people.RemoveAll(filter);
                        break;
                }
            }

            if (people.Count <= 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", people) + " are going to the party!");
            }
        }

         static Predicate<string> GetPredicate(string condition, string argument)
         {
             if (condition == "StartsWith")
                 return name => name.StartsWith(argument);

             if (condition == "EndsWith")
                 return name => name.EndsWith(argument);

             if (condition == "Length")
                 return name => name.Length == int.Parse(argument);

            throw new ArgumentException("invalid condition or argument!");
        }
    }
}
