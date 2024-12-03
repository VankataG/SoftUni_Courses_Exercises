namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] ordersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(ordersArray);

            Console.WriteLine(ordersQueue.Max());

            while (food > 0 && ordersQueue.Count > 0)
            {
                if (food >= ordersQueue.Peek())
                {
                    food -= ordersQueue.Dequeue();
                }
                else 
                    break;
            }

            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", ordersQueue)}");
            }
        }
    }
}
