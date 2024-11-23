namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charsCount = new();
            char[] chars = Console.ReadLine().Where(c => c != ' ').ToArray();

            foreach (char c in chars)
            {
                if (!charsCount.ContainsKey(c))
                {
                    charsCount[c] = 0;
                }
                charsCount[c]++;
            }
            foreach ((char chaR, int count) in charsCount)
                {
                Console.WriteLine($"{chaR} -> {count}");
            }
        }
    }
}
