namespace GenericCountMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Values.Add(input);
            }

            string comparer = Console.ReadLine();

            int result = box.CountOfGreaterElements(comparer);
            Console.WriteLine(result);
        }
    }
}
