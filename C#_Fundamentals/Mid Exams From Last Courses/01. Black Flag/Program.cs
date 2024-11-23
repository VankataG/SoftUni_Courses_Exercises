namespace _01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double plunderPerDay = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double plunder = default;

            for (int i = 1; i <= days; i++)
            {
                plunder += plunderPerDay;
                if (i % 3 == 0)
                {
                    plunder += plunderPerDay / 2;
                }
                if (i % 5 == 0)
                {
                    plunder *= 0.7;
                }
            }
            if (plunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {plunder:f2} plunder gained.");

            }
            else
            {
                Console.WriteLine($"Collected only {plunder/expectedPlunder * 100:f2}% of the plunder.");
            }

        }
    }
}
