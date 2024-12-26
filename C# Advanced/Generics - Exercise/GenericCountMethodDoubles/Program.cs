namespace GenericCountMethodDoubles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Values.Add(input);
            }

            double comparer = double.Parse(Console.ReadLine());

            int result = box.CountOfGreaterElements(comparer);
            Console.WriteLine(result);
        }
    }
}
