namespace _05._Applied_Arithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = AddFunc(numbers);
                        break;
                    case "multiply":
                        numbers = MultFunc(numbers);
                        break;
                    case "subtract":
                        numbers = SubFunc(numbers);
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                }
            }
        }

        static List<int> AddFunc(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i]++;
            }

            return nums;
        }

        static List<int> MultFunc(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i] *= 2;
            }

            return nums;
        }
        static List<int> SubFunc(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i]--;
            }

            return nums;
        }
    }
}
