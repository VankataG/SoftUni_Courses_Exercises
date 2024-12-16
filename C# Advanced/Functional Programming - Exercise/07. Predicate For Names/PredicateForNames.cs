namespace _07._Predicate_For_Names
{
    internal class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> ApplyFilter = x => x.Length <= n;

            Console.WriteLine(String.Join("\n", names.FindAll(ApplyFilter)));
        }
    }
}
