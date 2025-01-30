namespace PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> pies = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int contestant = contestants.Dequeue();
                int pie = pies.Pop();

                if (contestant >= pie)
                {
                    contestant -= pie;
                    if (contestant > 0)
                        contestants.Enqueue(contestant);
                }
                else
                {
                    pie -= contestant;
                    if (pie == 1 && pies.Count > 1)
                        pies.Push(pies.Pop() + 1);

                    else
                        pies.Push(pie);
                }
            }

            if (pies.Count == 0 && contestants.Count == 0)
                Console.WriteLine("We have a champion!");
            else if (pies.Count == 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!");
                Console.WriteLine($"Contestants left: {string.Join(", ", contestants)}");
            }
            else if (contestants.Count == 0)
            {
                Console.WriteLine("Our contestants need to rest!");
                Console.WriteLine($"Pies left: {string.Join(", ", pies)}");
            }
        }
    }
}
