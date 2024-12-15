namespace _04._Add_VAT
{
    internal class AddVAT
    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToList();

            prices.ForEach(x => Console.WriteLine($"{x:f2}"));
            
        }
    }
}
