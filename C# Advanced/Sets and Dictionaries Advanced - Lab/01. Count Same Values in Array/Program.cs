namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            Dictionary<double, int> numsCount = new();
            foreach (double number in numbers)
            {
                if (numsCount.ContainsKey(number))
                {
                    numsCount[number]++;
                }
                else
                {
                    numsCount[number] = 1;
                }
            }

            foreach (var num in numsCount)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }

        }
    }
}
