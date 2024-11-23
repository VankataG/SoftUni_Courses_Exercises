using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int result = 0;
            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int firstElement = numbers[0];
                    result += firstElement;
                    numbers[0] = numbers[numbers.Count - 1];

                    IncreaseOrDecrease(numbers, firstElement);
                }
                else if (index > numbers.Count - 1)
                {
                    int lastElement = numbers[numbers.Count - 1];
                    numbers[numbers.Count - 1] = numbers[0];
                    result += lastElement;
                    IncreaseOrDecrease(numbers, lastElement);
                }
                else
                {
                    int curNumber = numbers[index];
                    result += curNumber;
                    numbers.RemoveAt(index);
                    IncreaseOrDecrease(numbers, curNumber);
                }



            }
            Console.WriteLine(result);
        }

        private static void IncreaseOrDecrease(List<int> numbers, int curNumber)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (curNumber >= numbers[i])
                {
                    numbers[i] += curNumber;
                }
                else
                {
                    numbers[i] -= curNumber;
                }
            }
        }
    }
}
