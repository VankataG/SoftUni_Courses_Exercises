namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numStack = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "1":
                        int x = int.Parse(input[1]);
                        numStack.Push(x);
                        break;
                    case "2":
                        numStack.Pop();
                        break;
                    case "3":
                        if (numStack.Count > 0)
                            Console.WriteLine(numStack.Max());
                        break;

                    case "4":
                        if (numStack.Count > 0)
                            Console.WriteLine(numStack.Min());
                        break;

                }
            }

            Console.WriteLine(String.Join(", ", numStack));
        }
    }
}
