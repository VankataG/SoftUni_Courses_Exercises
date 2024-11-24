namespace _03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new();
            

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] cityData = input.Split("||");
                int population = int.Parse(cityData[1]);
                int gold = int.Parse(cityData[2]);
                City city = new City(cityData[0], population, gold);

                if (cities.ContainsKey(cityData[0]))
                {
                    cities[cityData[0]].Population += population;
                    cities[cityData[0]].Gold += gold;
                }
                else
                {
                    cities.Add(cityData[0], city);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split("=>");
                string city = commands[1];
                int gold = 0;
                switch (commands[0])
                {
                    case "Plunder":
                        int people = int.Parse(commands[2]);
                        gold = int.Parse(commands[3]);

                        cities[city].Population -= people;
                        cities[city].Gold -= gold;
                        Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (cities[city].Population == 0 || cities[city].Gold == 0)
                        {
                            cities.Remove(city);
                            Console.WriteLine($"{city} has been wiped off the map!");
                        }
                        break;

                    case "Prosper":
                        gold = int.Parse(commands[2]);
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            cities[city].Gold += gold;
                            Console.WriteLine(
                                $"{gold} gold added to the city treasury. {city} now has {cities[city].Gold} gold.");
                        }
                        break;
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (City city in cities.Values)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    public class City
    {
        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }
        public string Name;
        public int Population;
        public int Gold;
    }
}
