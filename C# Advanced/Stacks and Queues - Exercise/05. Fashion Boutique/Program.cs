using System.ComponentModel.DataAnnotations;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothesStack = new Stack<int>(clothesArr);
            int capacity = int.Parse(Console.ReadLine());
            int value = 0;
            int racks = 1;

            while (clothesStack.Count > 0)
            {
                    if (value + clothesStack.Peek() <= capacity)
                        value += clothesStack.Pop();
                    
                    else if (value + clothesStack.Peek() > capacity)
                    {
                        racks++;
                        value = 0;
                        value += clothesStack.Pop();
                    }
            }
            Console.WriteLine(racks);

        }
    }
}
