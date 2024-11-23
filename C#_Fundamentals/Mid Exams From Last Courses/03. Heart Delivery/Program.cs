namespace _03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(int.Parse).ToList();
            int cupidIndex = 0;
            string command;
            int houseCount = 0;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] commands = command.Split();
                int length = int.Parse(commands[1]);
                cupidIndex += length;
                if (cupidIndex >= houses.Count)
                {
                    cupidIndex = 0;
                }
                if (houses[cupidIndex] == 0)
                {
                    Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                }
                else
                {
                    houses[cupidIndex] -= 2;
                    if (houses[cupidIndex] == 0)
                    {
                        Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                        houseCount++;
                    }
                }
            }
            Console.WriteLine($"Cupid's last position was {cupidIndex}.");
            if (houseCount == houses.Count)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Count - houseCount} places.");
            }
        }
    }
}
