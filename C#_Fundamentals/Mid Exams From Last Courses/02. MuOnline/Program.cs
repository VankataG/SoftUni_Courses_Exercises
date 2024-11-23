namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            List<string> rooms = Console.ReadLine().Split("|").ToList();
            bool ifDead = false;

            for (int i = 0; i < rooms.Count; i++)
            {
                if (ifDead)
                {
                    break;
                }
                string[] commands = rooms[i].Split();
                switch (commands[0])
                {
                  
                    case "potion":
                        int heal = int.Parse(commands[1]);
                       
                        if (health + heal > 100)
                        {
                            heal = 100 - health;
                            health = 100; 
                        }
                        else
                        { 
                            health += heal; 
                        }
                        Console.WriteLine($"You healed for {heal} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;

                    case "chest":
                        int foundBC = int.Parse(commands[1]);
                        bitcoins += foundBC;
                        Console.WriteLine($"You found {foundBC} bitcoins.");
                        break;

                    default:
                        string monster = commands[0];
                        int attack = int.Parse(commands[1]);
                        health -= attack;
                        if (health <= 0)
                        {
                            ifDead = true;
                            Console.WriteLine($"You died! Killed by {monster}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {monster}.");
                        }
                        break;
                }
            }
             if (!ifDead)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }

        }
    }
}
