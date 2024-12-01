using System.Security.Cryptography.X509Certificates;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sections = new Dictionary<string, int>();
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();
            string input;
            while ((input = Console.ReadLine()) != "EndDay")
            {
                string[] commands = input.Split(new[] { ": ", "-" },StringSplitOptions.None).ToArray();
                string plantName = commands[1];
                switch (commands[0])
                {
                    case "Plant":
                        double waterNeeded = int.Parse(commands[2]);
                        string section = commands[3];
                        if (plants.ContainsKey(plantName))
                        {
                            plants[plantName].WaterNeeded = waterNeeded;
                        }
                        else
                        {
                            plants.Add(plantName, new Plant(plantName,waterNeeded,section));
                            if (!sections.ContainsKey(section))
                            {
                                sections[section] = 0;
                            }

                            sections[section]++;
                        }
                        break;
                    case "Water":
                        double water = int.Parse(commands[2]);
                        if (plants.ContainsKey(plantName))
                        {
                            plants[plantName].WaterNeeded -= water;
                            if (plants[plantName].WaterNeeded <= 0)
                            {
                                string sect = plants[plantName].Section;
                                plants.Remove(plantName);
                                Console.WriteLine($"{plantName} has been sufficiently watered.");
                                sections[sect]--;
                                if (sections[sect] == 0)
                                {
                                    sections.Remove(sect);
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine("Plants needing water:");
            foreach (Plant plant in plants.Values)
            {
                Console.WriteLine($" {plant.Name} -> {plant.WaterNeeded}ml left");
            }

            Console.WriteLine("Sections with thirsty plants:");
            {
                foreach (var section  in sections)
                {
                    Console.WriteLine($" {section.Key}: {section.Value}");
                }
            }
        }
    }

    public class Plant
    {
        public Plant(string name, double water, string section)
        {
            Name = name;
            WaterNeeded = water;
            Section = section;
        }
        public string Name;
        public double WaterNeeded;
        public string Section;

    }
}
