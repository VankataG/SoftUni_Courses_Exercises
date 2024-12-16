using System.Diagnostics;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class PartyFilterModule
    {
        static void Main(string[] args)
        {
            //Get the input
            List<string> partyList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            //Create dictionary to keep all filters
            Dictionary<string, Predicate<string>> filters = new();

            //Get commands
            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] commands = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string condition = commands[1];
                string argument = commands[2];

                //Create unique key for the filter and predicate
                string filterKey = condition + ";" + argument;
                Predicate<string> filterPredicate = GetFilter(condition, argument);

                //Add or remove the filter switch to the action
                switch (action)
                {
                    case "Add filter":
                        if (!filters.ContainsKey(filterKey))
                            filters.Add(filterKey, filterPredicate);
                        break;

                    case "Remove filter":
                        if (filters.ContainsKey(filterKey))
                            filters.Remove(filterKey);
                        break;
                }
            }

            //Apply all filter left to the collection
            foreach (Predicate<string> filter in filters.Values)
            {
                partyList.RemoveAll(filter);
            }

            //Print the filtered collection
            Console.WriteLine(String.Join(" ", partyList));


        }

        //Create method to make filter up to specified condition and argument
        static Predicate<string> GetFilter(string condition, string argument)
        {
            return condition switch
            {
                "Starts with" => name => name.StartsWith(argument),

                "Ends with" => name => name.EndsWith(argument),

                "Length" => name => name.Length == int.Parse(argument),

                "Contains" => name => name.Contains(argument),

                _ => throw new ArgumentException("Invalid condition or argument!")
            };
        }
    }
}
