using System.ComponentModel.DataAnnotations;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void VowelsFind(string str)
        {
            int vowels = 0;
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case 'a': vowels++; break;
                    case 'A': vowels++; break;
                    case 'e': vowels++; break;
                    case 'E': vowels++; break;
                    case 'i': vowels++; break;
                    case 'I': vowels++; break;
                    case 'o': vowels++; break;
                    case 'O': vowels++; break;
                    case 'u': vowels++; break;
                    case 'U': vowels++; break;
                }
            }
            Console.WriteLine(vowels);
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            VowelsFind(input);        }
    }
}
