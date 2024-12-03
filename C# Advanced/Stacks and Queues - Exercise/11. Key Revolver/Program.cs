namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletsTotal = 0;
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligence = int.Parse(Console.ReadLine());

            int shoots = 0;
            while (true)
            {
                if (bullets.Count == 0 || locks.Count == 0) break;
                
                int currBullet = bullets.Pop();
                int currLock = locks.Peek();
                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                shoots++;
                bulletsTotal += bulletPrice;
                if (shoots == gunBarrel && bullets.Count > 0)
                {
                    shoots = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                int moneyEarned = intelligence - bulletsTotal;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
