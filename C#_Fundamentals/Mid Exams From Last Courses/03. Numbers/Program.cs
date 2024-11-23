namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new();
            double average = numbers.Average();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    result.Add(numbers[i]);
                }
            }
            result.Sort();
            result.Reverse();
            while (result.Count > 5)
            {
                result.RemoveAt(result.Count - 1);
            }
            if (result.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
                Console.WriteLine(String.Join(" ", result));
        }
    }
}
