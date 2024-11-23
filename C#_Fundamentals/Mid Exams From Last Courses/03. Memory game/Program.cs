namespace Problem_3___Memory_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            string command;
            int moves = 0;
            while((command = Console.ReadLine()) !="end")
            {
                string[] ints = command.Split().ToArray();
                int int1 = int.Parse(ints[0]);
                int int2 = int.Parse(ints[1]);
                moves++;
                if (int1 == int2
                    || int1 < 0 || int1 > numbers.Count - 1
                    || int2 < 0 || int2 > numbers.Count - 1)
                {
                    string[] additionalElements = { $"-{moves}a" , $"-{moves}a" };
                    numbers.InsertRange(numbers.Count / 2, additionalElements);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }
                else
                {
                    if (numbers[int1] == numbers[int2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {numbers[int1]}!");
                        numbers.RemoveAt(Math.Max(int1, int2));
                        numbers.RemoveAt(Math.Min(int1, int2));
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine($"You have won in {moves} turns!");
                            break;
                        }
                    }
                    else if (numbers[int1] != numbers[int2])
                    {
                        Console.WriteLine("Try again!");
                        continue;
                    }

                }
            }
            if (numbers.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(String.Join(" ", numbers));
            }
        }
    }
}
