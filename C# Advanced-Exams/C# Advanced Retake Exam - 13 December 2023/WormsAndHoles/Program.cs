namespace WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matches = 0;

            Stack<int> worms = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int totalWorms = worms.Count;
            Queue<int> holes = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (worms.Count > 0 && holes.Count > 0)
            {
                int worm = worms.Pop();
                int hole = holes.Dequeue();

                if (worm == hole) matches++;
                else
                {
                    worm -= 3;
                    if (worm > 0) worms.Push(worm);
                }
            }

            Console.WriteLine(matches > 0 ? $"Matches: {matches}" : "There are no matches.");

            if (worms.Count == 0 && totalWorms == matches) 
                Console.WriteLine("Every worm found a suitable hole!");
            else if (worms.Count > 0)
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            else
                Console.WriteLine("Worms left: none");

            Console.WriteLine(holes.Count == 0 ? "Holes left: none" : $"Holes left: {string.Join(", ", holes)}");
        }
    }
}
