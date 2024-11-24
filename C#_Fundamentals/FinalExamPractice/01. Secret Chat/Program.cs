namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] commands = input.Split(":|:");
                string substring = default;
                switch (commands[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        substring = commands[1];
                        if (message.Contains(substring))
                        {
                            int startIndex = message.IndexOf(substring[0]);
                            string reversedSubstring = new string(substring.Reverse().ToArray());
                            message += reversedSubstring;
                            message = message.Remove(startIndex, substring.Length);
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        substring = commands[1];
                        string replacement = commands[2];
                        message = message.Replace(substring, replacement);
                        Console.WriteLine(message);
                        break;
                }
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
