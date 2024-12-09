namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charsMap = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (!charsMap.ContainsKey(input[i]))
                    charsMap[input[i]] = 0;
                charsMap[input[i]]++;
            }

            foreach (var (ch, count) in charsMap)
            {
                Console.WriteLine($"{ch}: {count} time/s");
            }
        }
    }
}
