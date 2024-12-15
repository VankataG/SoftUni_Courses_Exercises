namespace _01.SortEvenNumbers
{
    internal class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();
            Console.WriteLine(String.Join(", ",numbers.Where(n => n % 2 == 0)));
        }
    }
}
