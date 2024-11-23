using System.Net.Http.Headers;

namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();
            string input;
            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] commands = input.Split(" - ");
                switch (commands[0])
                {
                    case "Collect":
                        if (!items.Contains(commands[1]))
                        items.Add(commands[1]);
                        break;

                    case "Drop":
                        items.Remove(commands[1]);
                        break;

                    case "Combine Items":
                        string[] oldNewItems = commands[1].Split(":");
                        string oldItem = oldNewItems[0];
                        string newItem = oldNewItems[1];
                        if (items.Contains(oldItem))
                        {
                            items.Insert(items.IndexOf(oldItem) + 1, newItem);
                        }
                        break;

                    case "Renew":
                        if (items.Contains(commands[1]))
                        {
                            items.Remove(commands[1]);
                            items.Add(commands[1]);
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", items));
        }
    }
}
