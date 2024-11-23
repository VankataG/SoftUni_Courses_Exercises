namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MiddleCharactersPrint(input);
        }

        static void MiddleCharactersPrint(string input)
        {
            if (input.Length % 2 != 0)
            {
                Console.WriteLine(input[(input.Length -1) / 2]);
            }
            else
            {
                Console.Write(input[(input.Length / 2) - 1]);
                Console.Write(input[input.Length / 2]);
                

            }
        }
    }
}
