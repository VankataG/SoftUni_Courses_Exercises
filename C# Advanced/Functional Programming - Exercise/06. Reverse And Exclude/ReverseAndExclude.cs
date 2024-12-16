namespace _06._Reverse_And_Exclude
{
    internal class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            
            Console.WriteLine(String.Join(" ", numbers
                .AsEnumerable()
                .Reverse()
                .Where(x => x % n != 0)
                .ToList()
            ));
        }
    }
}
