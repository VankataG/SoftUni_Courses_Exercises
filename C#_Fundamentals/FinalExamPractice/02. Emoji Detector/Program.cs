using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string digitPattern = @"\d";
            string emojiPattern = @"(::|\*\*)(?<Letters>[A-Z][a-z]{2,})\1";
            ulong coolThreshold = 1;
            int allEmojis = 0;
            List<string> coolEmojis = new();

            string input = Console.ReadLine();
            foreach (Match match in Regex.Matches(input, digitPattern))
            {
                coolThreshold *= ulong.Parse(match.Value);
            }

            foreach (Match match in Regex.Matches(input, emojiPattern))
            {
                allEmojis++;
                ulong cool = 0;
                foreach (char ch in match.Groups["Letters"].Value)
                {
                    cool += ch;
                }

                if (cool >= coolThreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{allEmojis} emojis found in the text. The cool ones are:");
            Console.WriteLine(String.Join("\n", coolEmojis));

        }
    }
}
