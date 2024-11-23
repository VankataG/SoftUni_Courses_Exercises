namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> allArrays = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> result = new();

            for (int i = allArrays.Count - 1; i >= 0; i--)
            {
                string[] array = allArrays[i].Split(" ",StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(array);
                
            }
            Console.WriteLine(String.Join(" ", result));

        }
    }
}
