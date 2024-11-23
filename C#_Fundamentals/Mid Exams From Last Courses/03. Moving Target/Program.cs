namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commands = command.Split();
                int index = int.Parse(commands[1]);
                switch (commands[0])
                {
                    case "Shoot":
                        int power = int.Parse(commands[2]);
                        if (index >= 0 && index < targets.Count)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;

                    case "Add":
                        int value = int.Parse(commands[2]);
                        if (index >= 0 && index < targets.Count)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }

                        break;

                    case "Strike":
                        int radius = int.Parse(commands[2]);
                        int leftIndex = index - radius;
                        int rightIndex = index + radius;
                        if (index < 0 || index >= targets.Count
                            || leftIndex < 0
                            || rightIndex >= targets.Count)
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        else
                        {
                            targets.RemoveRange(leftIndex, radius * 2 + 1);
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join("|", targets));
        }
    }
}
