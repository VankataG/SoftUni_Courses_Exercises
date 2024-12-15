namespace _02._Sum_Numbers
{
    internal class SumNumbers
    {
        static void Main(string[] args)
        {
            //Read all numbers
            List<int> nums = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            //Print numbers count
            Console.WriteLine(nums.Count);

            //Print numbers sum
            Console.WriteLine(nums.Sum());
        }
    }
}
