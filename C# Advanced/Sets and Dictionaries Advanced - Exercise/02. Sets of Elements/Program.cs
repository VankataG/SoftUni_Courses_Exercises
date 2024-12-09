namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new();
            HashSet<int> set2 = new();
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < lengths[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < lengths[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var element in set1)
            {
                if (set2.Contains(element))
                    Console.Write(element + " ");
            }
        }
    }
}
