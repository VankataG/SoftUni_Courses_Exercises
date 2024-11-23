namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int sum = default;
            for (int i = 0; i < wagons; i++)
            {
                int passengers = int.Parse(Console.ReadLine());
                sum += passengers;
                Console.Write(passengers + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
