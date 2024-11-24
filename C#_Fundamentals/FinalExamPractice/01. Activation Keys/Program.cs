using System.Text;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] commands = input.Split(">>>");
                switch (commands[0])
                {
                    case "Contains":
                        string substr = commands[1];
                        if (key.Contains(substr))
                        {
                            Console.WriteLine($"{key} contains {substr}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;

                    case "Flip":
                        int startIndex = int.Parse(commands[2]);
                        int endIndex = int.Parse(commands[3]);
                        switch (commands[1])
                        {
                            case "Upper":
                                StringBuilder upperSb = new();
                                for (int i = 0; i < key.Length; i++)
                                {
                                    if (i >= startIndex && i < endIndex)
                                    {
                                        upperSb.Append(key[i].ToString().ToUpper());
                                    }
                                    else
                                    {
                                        upperSb.Append(key[i]);
                                    }
                                }
                                key = upperSb.ToString();
                                Console.WriteLine(key);
                                break;
                            case "Lower":
                                StringBuilder lowerSb = new();
                                for (int i = 0; i < key.Length; i++)
                                {
                                    if (i >= startIndex && i < endIndex)
                                    {
                                        lowerSb.Append(key[i].ToString().ToLower());
                                    }
                                    else
                                    {
                                        lowerSb.Append(key[i]);
                                    }
                                }
                                key = lowerSb.ToString();
                                Console.WriteLine(key);
                                break;
                        }
                        break;

                    case "Slice":
                        int start = int.Parse(commands[1]);
                        int end = int.Parse(commands[2]);
                        StringBuilder sliceSb = new();
                        for (int i = 0; i < key.Length; i++)
                        {
                            if (i < start || i >= end)
                            {
                                sliceSb.Append(key[i]);
                            }
                        }
                        key = sliceSb.ToString();
                        Console.WriteLine(key);
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
