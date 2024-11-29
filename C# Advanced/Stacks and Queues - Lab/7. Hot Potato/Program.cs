namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> childrenQ = new Queue<string>(children);

            while (childrenQ.Count > 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == n)
                    {
                       Console.WriteLine($"Removed {childrenQ.Dequeue()}");
                    }
                    else
                    {
                        childrenQ.Enqueue(childrenQ.Dequeue());
                    }
                }
            }
            Console.WriteLine($"Last is {childrenQ.Dequeue()}");


        }
    }
}
