namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] commands = input.Split();
                int index = default;
                char ch = default;
                switch (commands[0])
                {
                    case "Make":
                        index = int.Parse(commands[2]);
                        switch (commands[1])
                        {
                            case "Upper":
                                ch = char.ToUpper(password[index]);
                                password = password.Remove(index, 1);
                                password = password.Insert(index, ch.ToString());
                                Console.WriteLine(password);
                                break;
                            case "Lower":
                                ch = char.ToLower(password[index]);
                                password = password.Remove(index, 1);
                                password = password.Insert(index, ch.ToString());
                                Console.WriteLine(password);
                                break;
                        }
                        break;
                    case "Insert":
                        index = int.Parse(commands[1]);
                        ch = char.Parse(commands[2]);
                        if (index >= 0 && index < password.Length)
                        {
                            password = password.Insert(index, ch.ToString());
                            Console.WriteLine(password);
                        }
                        break;
                    case "Replace":
                        ch = char.Parse(commands[1]);
                        int value = int.Parse(commands[2]);
                        if (password.Contains(ch))
                        {
                            int newChInt = ch + value;
                            char newCh = (char)newChInt;
                            password = password.Replace(ch, newCh);
                            Console.WriteLine(password);
                        }
                        break;
                    case "Validation":
                        if (password.Length < 8)
                        {
                            Console.WriteLine("Password must be at least 8 characters long!");
                        }
                        if (!password.All(c => char.IsLetterOrDigit(c) || c == '_'))
                        {
                            Console.WriteLine("Password must consist only of letters, digits and _!");
                        }

                        if (!password.Any(char.IsUpper))
                        {
                            Console.WriteLine("Password must consist at least one uppercase letter!");
                        }

                        if (!password.Any(char.IsLower))
                        {
                            Console.WriteLine("Password must consist at least one lowercase letter!");
                        }

                        if (!password.Any(char.IsDigit))
                        {
                            Console.WriteLine("Password must consist at least one digit!");
                        }
                        break;
                }
            }
        }
    }
}
