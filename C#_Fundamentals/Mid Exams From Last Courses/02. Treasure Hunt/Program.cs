namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|").ToList();
            string input;
            double averageGain = default;
            bool isFailed = false;
            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                if (isFailed) break;

                List<string> commands = input.Split().ToList();
                switch (commands[0])
                {
                    case "Loot":
                        for (int i = 1; i <= commands.Count - 1; i++)
                        {
                            if (!items.Contains(commands[i]))
                            {
                                items.Insert(0, commands[i]);
                            }
                        }
                        break;

                    case "Drop":
                        int index = int.Parse(commands[1]);
                        if (index >= 0 && index < items.Count)
                        {
                            items.Add(items[index]);
                            items.RemoveAt(index);
                        }
                        break;

                    case "Steal":
                        int lastCount = int.Parse(commands[1]);
                        List<string> stealed = new();
                        if (lastCount > items.Count)
                        {
                            lastCount = items.Count;
                        }

                        for (int i = items.Count - lastCount; i < items.Count; i++)
                        {
                            stealed.Add(items[i]);
                            items.Remove(items[i]);
                            i--;
                        }
                        Console.WriteLine(String.Join(", ", stealed));

                        break;

                }

            }
           
                double sum = default;
                for (int i = 0; i < items.Count; i++)
                {
                    sum += items[i].Length;
                }
                averageGain = (sum *1.0) / items.Count;
            if (averageGain > 0)
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            else
                Console.WriteLine("Failed treasure hunt.");
            
        }
    }
}
