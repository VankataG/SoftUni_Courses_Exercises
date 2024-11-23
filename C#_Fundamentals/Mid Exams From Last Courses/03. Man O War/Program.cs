namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());
            string input;
            bool youWin = false;
            bool youLose = false;
            
            while((input = Console.ReadLine()) != "Retire")
            {
                if (youLose)
                    break;

                string[] commands = input.Split();
                int index = -1;
                int dmg = 0;
                switch (commands[0])
                {
                    case "Fire":
                        index = int.Parse(commands[1]);
                        dmg = int.Parse(commands[2]);

                        if (index >= 0 && index < warShip.Count)
                        {
                            warShip[index] -= dmg;
                            if (warShip[index] <= 0)
                            {
                                youWin = true;
                                break;
                            }
                        }
                        else
                            continue;
                        break;

                    case "Defend":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        dmg = int.Parse(commands[3]);

                        if (startIndex >= 0 && startIndex < pirateShip.Count &&
                            endIndex >= 0 && endIndex < pirateShip.Count)
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= dmg;
                                if (pirateShip[i] <= 0)
                                {
                                    youLose = true;
                                    break;
                                }
                            }
                        }
                        else
                            continue;
                        break;

                    case "Repair":
                        index = int.Parse(commands[1]);
                        int heal = int.Parse(commands[2]);

                        if (index >=0 && index < pirateShip.Count)
                        {
                            pirateShip[index] += heal;
                            if (pirateShip[index] > maxHealth)
                            {
                                pirateShip[index] = maxHealth;
                            }
                        }
                        break;

                    case "Status":
                        double needRepair = maxHealth * 0.2;
                        int count = 0;
                        for (int i = 0; i < pirateShip.Count; i++)
                        {
                            if (pirateShip[i] < needRepair)
                            {
                                count++;
                            }
                        }
                        Console.WriteLine($"{count} sections need repair.");
                        break;

                }

            }
            if (youWin)
            {
                Console.WriteLine("You won! The enemy ship has sunken.");
            }
            else if (youLose)
            {
                Console.WriteLine("You lost! The pirate ship has sunken.");
            }
            else
            {
                int pirateSum = pirateShip.Sum();
                int warSum = warShip.Sum();
                Console.WriteLine($"Pirate ship status: {pirateSum}");
                Console.WriteLine($"Warship status: {warSum}");
            }
        }
    }
}
