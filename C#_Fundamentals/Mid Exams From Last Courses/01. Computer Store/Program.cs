namespace Problem_1___Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double sum = 0;
            while ((input = Console.ReadLine()) != "special" && input != "regular")
            {
                double partPrice = double.Parse(input);
                if (partPrice < 0)
                {
                    Console.WriteLine("Invalid price!");

                }
                else
                {
                    sum += partPrice;
                }
            }
            double taxes = sum * 0.2;
            double totalSum = sum + taxes;
            if (totalSum == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                if (input == "special")
                {
                    totalSum -= totalSum * 0.1;
                }

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalSum:f2}$");

            }
        }
    }
}
