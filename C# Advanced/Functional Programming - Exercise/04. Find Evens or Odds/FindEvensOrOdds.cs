using System.Security.Cryptography.X509Certificates;

namespace _04._Find_Evens_or_Odds
{
    internal class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            //Create Predicates for easy finding
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            //Read input
            List<int> info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int start = info[0];
            int end = info[1];

            string command = Console.ReadLine();


            //Find all evens or all odds
            List<int> results = new();
            if (start <= end)
            {
                if (command == "even")
                {
                    results = Enumerable.Range(start, end - start + 1)
                        .Where(x => isEven(x))
                        .ToList();
                }
                else if (command == "odd")
                {
                    results = Enumerable.Range(start, end - start + 1)
                        .Where(x => isOdd(x))
                        .ToList();
                }
            }

            //Print the result
            Console.WriteLine(String.Join(" ", results));
        }
    }
}
