namespace _02._Basic_Queue_Operations
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
            Queue<int> numberQueue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                numberQueue.Enqueue(integers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                numberQueue.Dequeue();
            }

            if (numberQueue.Count <= 0)
                Console.WriteLine(0);

            else if (numberQueue.Contains(x))
                Console.WriteLine("true");

            else
                Console.WriteLine(numberQueue.Min());
        }
    }
}
