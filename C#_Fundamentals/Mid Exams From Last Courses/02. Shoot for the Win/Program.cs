using System.Security.Cryptography;

namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;
            int shots = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);
                
                if (index >= 0 && index < targets.Count)
                {
                    if (targets[index] != -1)
                    {
                        int value = targets[index];
                        for (int i = 0; i < targets.Count; i++)
                        {
                            if (targets[i] != -1)
                            {
                                
                                if (targets[i] <= value)
                                {
                                    targets[i] += value;
                                }
                                else if (targets[i] > value)
                                {
                                    targets[i] -= value;
                                }
                            }
                        }
                        shots++;
                        targets[index] = -1;
                    }

                }
            }
            Console.WriteLine($"Shot targets: {shots} -> {String.Join(" ", targets)}");
        }
    }
}
