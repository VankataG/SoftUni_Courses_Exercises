using System.Text.RegularExpressions;
/*
 3
   Arnoldii<->4
   Woodii<->7
   Welwitschia<->2
   Rate: Woodii - 10
   Rate: Welwitschia - 7
   Rate: Arnoldii - 3
   Rate: Woodii - 5
   Update: Woodii - 5
   Reset: Arnoldii
   Exhibition
 */
namespace _03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plantsMap = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plantInfos = Console.ReadLine().Split("<->");
                string plantName = plantInfos[0];
                int plantRarity = int.Parse(plantInfos[1]);
                Plant newPlant = new Plant(plantName, plantRarity);
                if (!plantsMap.ContainsKey(plantName))
                {
                    plantsMap.Add(plantName, newPlant);
                }
                else
                {
                    plantsMap[plantName] = newPlant;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] commands = input.Split(new[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string plant = commands[1].Trim();
                switch (commands[0])
                {
                    case "Rate":
                        double rating = double.Parse(commands[2]);
                        if (plantsMap.ContainsKey(plant))
                        {
                            plantsMap[plant].Ratings.Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;
                    case "Update":
                        int newRarity = int.Parse(commands[2]);
                        if (plantsMap.ContainsKey(plant))
                        {
                            plantsMap[plant].Rarity = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;
                    case "Reset":
                        if (plantsMap.ContainsKey(plant))
                        {
                            plantsMap[plant].Ratings.Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach ((string plantName, Plant plant) in plantsMap)
            {
                //if (plant.Ratings.Count > 0)
                //    Console.WriteLine($"- {plantName}; Rarity: {plant.Rarity}; Rating: {plant.Ratings.Average():f2}");
                //else
                //    Console.WriteLine($"- {plantName}; Rarity: {plant.Rarity}; Rating: 0.00");
                Console.WriteLine($"- {plantName}; Rarity: {plant.Rarity}; Rating: {(plant.Ratings.Count > 0 ? plant.Ratings.Average().ToString("f2") : "0.00")}");

            }
        }

        public class Plant
        {
            public Plant(string name, int rarity)
            {
                Name = name;
                Rarity = rarity;
                Ratings = new();
            }

            public string Name;
            public int Rarity;
            public List<double> Ratings;

        }

    }
}
