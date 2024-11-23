namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = default;
            while ((command = Console.ReadLine()) != "END")
            {
                Console.WriteLine(IsPalindrome(command));
            }
        }
        static bool IsPalindrome(string number)
        {
                int length = number.Length;
                for (int i = 0; i < length / 2; i++)
                {
                    if (number[i] != number[length - 1 - i])
                    {
                        return false;
                    }
                }

                return true;

        }
    }
}
