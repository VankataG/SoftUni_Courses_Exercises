using System.ComponentModel.Design;

namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = Console.ReadLine().Split().ToList();
            string commands;
            while ((commands = Console.ReadLine()) != "3:1")
            {
                string[] command = commands.Split().ToArray();
                switch (command[0])
                {
                    case "merge":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        if (startIndex < 0) startIndex = 0;
                        if (endIndex >= inputs.Count) endIndex = inputs.Count - 1;

                        for (int i = startIndex + 1; i <= endIndex; i++)
                        {
                            inputs[startIndex] += inputs[i];
                        }
                        for (int i = startIndex + 1; i <= endIndex; i++)
                        {
                            inputs.RemoveAt(i);
                        }
                        break;

                    case "divide":
                        int index = int.Parse(command[1]);
                        int partitions = int.Parse(command[2]);
                        
                        
                        break;
                }

            }
        }
    }

}
