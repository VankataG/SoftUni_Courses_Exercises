namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("!").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] commands = command.Split();
                string item = commands[1];
                switch (commands[0])
                {
                    case "Urgent":
                        if (!(list.Contains(item)))
                        {
                            list.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        list.Remove(item);
                        break;
                    case "Correct":
                        string newItem = commands[2];
                        if (list.Contains(item))
                        {
                            list[list.IndexOf(item)] = newItem;
                        }
                        break;
                    case "Rearrange":
                        if (list.Contains(item))
                        {
                            list.Remove(item);
                            list.Add(item);
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", list));
        }
    }
}
