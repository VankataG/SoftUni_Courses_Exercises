namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input;
            int wins = 0;
            bool youLose = false;
            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance <= energy)
                {
                    wins++;
                    energy -= distance;
                    
                }
                else if (distance > energy)
                {
                    youLose = true;
                    break;
                }
                if (wins % 3 == 0)
                {
                    energy += wins;
                }



                
            }
            if (youLose)
            {
                Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
