namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int longestSeq = 0;
            int number = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int count = 1;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }

                    if (count > longestSeq)
                    {
                        longestSeq = count;
                        number = numbers[i];
                    }
                }
            }
            for (int i = 0; i < longestSeq; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
