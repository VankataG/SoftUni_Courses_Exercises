namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string[] input = Console.ReadLine().Split(" ");
            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);

            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numberStack = new Stack<int>(integers);

            for (int i = 0; i < s; i++)
            {
                numberStack.Pop();
            }

            if (numberStack.Count <= 0)
                Console.WriteLine(0);

            else if (numberStack.Contains(x))
                Console.WriteLine("true");

            else 
                Console.WriteLine(numberStack.Min());
        }
    }
}
