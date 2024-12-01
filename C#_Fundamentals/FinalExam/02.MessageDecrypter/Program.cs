using System.Text.RegularExpressions;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern =
                @"^([$%])(?<Tag>[A-Z][a-z]{2,})\1\: \[(?<num1>\d+)\]\|\[(?<num2>\d+)\]\|\[(?<num3>\d+)\]\|$";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                {
                    
                    string message = default;
                    Match match = Regex.Match(input, pattern);
                    string tag = match.Groups["Tag"].Value;
                    int num1 = int.Parse(match.Groups["num1"].Value);
                    int num2 = int.Parse(match.Groups["num2"].Value);
                    int num3 = int.Parse(match.Groups["num3"].Value);
                    message += (char)num1;
                    message += (char)num2;
                    message += (char)num3;
                    Console.WriteLine($"{tag}: {message}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
