namespace _03._Custom_Min_Function
{
    internal class MinFunction
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> getMinValue = MinValue;

            int minNum = getMinValue(nums);
            Console.WriteLine(minNum);
        }

        static int MinValue(int[] nums)
        {
            return nums.Min();
        }
    }
}
