using System.Security.Cryptography.X509Certificates;

namespace _08._List_Of_Predicates
{
    internal class ListOfPredicates
    {
        static void Main(string[] args)
        {

            //Read the end of the sequence
            int endNum = int.Parse(Console.ReadLine());

            //Create the sequence from 1 to End in List
            List<int> nums = Enumerable.Range(1, endNum - 1 + 1).ToList();

            //Read the dividers List
            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            //Create Function to check if every number is divisible by every divider
            Func<int, List<int>, bool> isDivisible = (num, dividers) => dividers
                                                                          .All(divider => num % divider == 0);

            //Print the List using the checking function
            Console.WriteLine(String.Join(" ", nums.Where(num => isDivisible(num, dividers))));

        }

    }
}
