namespace OffroadChallenge
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int altitudes = 0;
            bool outOfFuel = false;
            bool reachedTop = false;
            List<string> reachedAltitudes = new List<string>();

            Stack<int> fuelInts = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> consumptInts = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> results = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int totalAltitudes = results.Count;

            while (!outOfFuel && !reachedTop)
            {
                int fuel = fuelInts.Pop();
                int consumpt = consumptInts.Dequeue();
                int result = results.Dequeue();

                if (fuel - consumpt >= result)
                {
                    altitudes++;
                    reachedAltitudes.Add($"Altitude {altitudes}");
                    if (altitudes == totalAltitudes)
                    {
                        reachedTop = true;
                        break;
                    }
                }
                else
                {
                    outOfFuel = true;
                    break;
                }
            }

            for (int i = 1; i <= altitudes; i++)
                Console.WriteLine($"John has reached: Altitude {i}");

            if (outOfFuel)
                Console.WriteLine($"John did not reach: Altitude {altitudes+1}");

            if (reachedTop)
                Console.WriteLine($"John has reached all the altitudes and managed to reach the top!");
            else if (altitudes <= 0)
                Console.WriteLine($"John failed to reach the top.\r\nJohn didn't reach any altitude.");
            else
                Console.WriteLine($"John failed to reach the top.\r\nReached altitudes: {string.Join(", ", reachedAltitudes)}");
        }
    }
}
