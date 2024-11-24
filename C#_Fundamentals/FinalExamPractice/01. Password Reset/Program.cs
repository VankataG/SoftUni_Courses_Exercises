using System.Text;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string str;
            while ((str = Console.ReadLine()) != "Done")
            {
                string[] commands = str.Split();
                switch (commands[0])
                {
                    case "TakeOdd":
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i <= password.Length - 1; i+=2)
                        {
                            if (i % 2 != 0)
                            {
                                sb.Append(password[i]);
                            }
                        }

                        password = sb.ToString();
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        password = password.Remove(index, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substring = commands[1];
                        string substitute = commands[2];
                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;

                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
