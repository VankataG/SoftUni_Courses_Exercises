using System.Numerics;

namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] commands = input.Split('|');
                switch (commands[0])
                {
                    case "Move":
                        int nLetters = int.Parse(commands[1]);

                        string toMove = message.Substring(0, nLetters);
                        message = message.Substring(nLetters) + toMove;
                        break;
                    case "Insert":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];
                        message = message.Insert(index , value);
                        break;
                    case "ChangeAll":
                        string substring = commands[1];
                        string replacement = commands[2];
                        message = message.Replace(substring, replacement);
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
