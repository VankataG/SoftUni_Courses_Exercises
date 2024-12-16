namespace _02._Knights_of_Honor
{
    internal class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<string> printNameAction = PrintName;

            foreach (var name in names)
            {
                printNameAction(name);
            }
        }

        static void PrintName(string name)
        {
            Console.WriteLine("Sir " + name);
        }
    }
}
