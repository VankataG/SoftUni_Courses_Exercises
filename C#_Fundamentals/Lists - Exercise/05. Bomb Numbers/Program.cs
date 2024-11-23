namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = commands[0];
            int power = commands[1];

            while (numbers.Contains(bomb))
            {
                int index = numbers.IndexOf(bomb);
                int left = Math.Max(0, index - power);
                int right = Math.Min(numbers.Count - 1, index + power);
                int range = right - left + 1;

                numbers.RemoveRange(left, range);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
