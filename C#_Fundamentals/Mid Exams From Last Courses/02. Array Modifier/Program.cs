namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commands = command.Split();
                int index1;
                int index2;
                switch (commands[0])
                {
                    case "swap":
                        index1 = int.Parse(commands[1]);
                        index2 = int.Parse(commands[2]);
                        int number1Copy = numbers[index1];
                        numbers[index1] = numbers[index2];
                        numbers[index2] = number1Copy;
                        break;
                    case "multiply":
                        index1 = int.Parse(commands[1]);
                        index2 = int.Parse(commands[2]);
                        numbers[index1] *= numbers[index2];
                        break;
                    case "decrease":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i]--;
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
