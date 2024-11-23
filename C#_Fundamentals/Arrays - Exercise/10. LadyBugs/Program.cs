using System.ComponentModel;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] bugsIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < bugsIndexes.Length; i++)
            {
                int currentIndex = bugsIndexes[i];
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    field[currentIndex] = 1;
                }

            }

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split();
                int bugIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int step = int.Parse(commands[2]);

                if (bugIndex >= 0 && bugIndex < field.Length && field[bugIndex] == 1)
                {
                    field[bugIndex] = 0;

                    if (direction == "right")
                    {
                        int landIndex = bugIndex + step;

                        if (landIndex >= 0 && landIndex < field.Length)
                        {


                            while (field[landIndex] == 1)
                            {
                                landIndex += step;
                                if (landIndex > field.Length - 1)
                                {
                                    break;
                                }
                            }

                            if (landIndex <= field.Length - 1)
                            { field[landIndex] = 1; }

                        }

                    }
                    else if (direction == "left")
                    {
                        int landIndex = bugIndex - step;

                        if (landIndex >= 0 && landIndex < field.Length)
                        {
                            while (field[landIndex] == 1)
                            {
                                landIndex -= step;
                                if (landIndex < 0)
                                {
                                    break;
                                }
                            }
                            if (landIndex >= 0)
                            { field[landIndex] = 1; }

                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
