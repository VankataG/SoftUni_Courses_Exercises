namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split().ToArray();
                int element = int.Parse(commands[1]);
                switch (commands[0])
                {
                    case "Delete":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == element)
                            { numbers.RemoveAt(i); }
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(commands[2]);
                        numbers.Insert(index, element);
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
