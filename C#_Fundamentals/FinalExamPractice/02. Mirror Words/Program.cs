using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mirrorWords = new();
            string pattern = @"([\@\#])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();
            int pairCount = 0;
            foreach (Match match in Regex.Matches(input,pattern))
            {
                pairCount++;
                string word1 = match.Groups["word1"].Value;
                string word2 = match.Groups["word2"].Value;
                string reversed = new string(word2.Reverse().ToArray());
                if (word1 == reversed)
                {
                    mirrorWords.Add($"{word1} <=> {word2}");
                }
            }

            if (pairCount > 0)
            {
                Console.WriteLine($"{pairCount} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrorWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", mirrorWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
