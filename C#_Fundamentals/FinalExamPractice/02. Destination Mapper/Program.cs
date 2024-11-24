using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> locations = new();
            string pattern = @"([\=\/])(?<Location>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            int travelPoints = 0;
            foreach (Match match in Regex.Matches(input, pattern))
            {
                travelPoints += match.Groups["Location"].Value.Length;
                locations.Add(match.Groups["Location"].Value);
            }
            Console.WriteLine($"Destinations: {String.Join(", ", locations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
