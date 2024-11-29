namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] startNumbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbersStack = new Stack<int>(startNumbers);

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] commands = input.Split(' ');
                switch (commands[0])
                {
                    case "add":
                        int n1 = int.Parse(commands[1]);
                        int n2 = int.Parse(commands[2]);
                        numbersStack.Push(n1);
                        numbersStack.Push(n2);
                        break;
                    case "remove":
                        int elements = int.Parse(commands[1]);
                        if (numbersStack.Count >= elements)
                        {
                            for (int i = 0; i < elements; i++)
                            {
                                numbersStack.Pop();
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"Sum: {numbersStack.Sum()}");
        }
    }
}
