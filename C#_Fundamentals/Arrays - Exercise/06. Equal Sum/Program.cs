namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j <= i - 1; j++)
                {
                    leftSum += numbers[j];
                }
                for (int j = i + 1; j <= numbers.Length - 1; j++)
                {
                    rightSum += numbers[j];
                }
                if (leftSum == rightSum)
                {
                    index = i;
                }

            }
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
