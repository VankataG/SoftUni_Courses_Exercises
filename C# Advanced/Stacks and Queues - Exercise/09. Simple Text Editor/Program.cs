using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            StringBuilder text = new();
            stack.Push(text.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                
                switch (commands[0])
                {
                    case "1":
                        string str = commands[1];
                        text.Append(str);
                        stack.Push(text.ToString());
                        break;
                    case "2":
                        int count = int.Parse(commands[1]);
                        text.Remove(text.Length - count, count);
                        stack.Push(text.ToString());
                        break;
                    case "3":
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        stack.Pop();
                        text = new StringBuilder();
                        text.Append(stack.Peek());
                        break;
                }
            }
        }
    }
}
