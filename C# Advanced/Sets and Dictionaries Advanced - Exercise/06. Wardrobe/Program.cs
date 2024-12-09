namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new();
                }
                string[] clothes = input[1].Split(",");
                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth] = 0;
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] searched = Console.ReadLine().Split();
            string searchedColor = searched[0];
            string searchedCloth = searched[1];

            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (cloth, count) in clothes)
                {
                    Console.Write($"* {cloth} - {count}");
                    if (searchedColor == color && searchedCloth == cloth)
                        Console.Write(" (found!)");
                    Console.WriteLine();
                }
            }
        }
    }
}
