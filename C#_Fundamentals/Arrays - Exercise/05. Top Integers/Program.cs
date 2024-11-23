namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string output = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isTopInt = true;
                for ( int j = i + 1; j < numbers.Length ; j++ )
                { 
                    if ( numbers[i] <= numbers[j])
                    {
                        isTopInt = false;
                        break;
                    }
                }
                if ( isTopInt )
                {
                    output += numbers[i] + " ";
                }

            }
            string[] topIntegers = output.Split();
            Console.WriteLine((string.Join(" ", topIntegers)) + $"{numbers[numbers.Length - 1]}");
        }
    }
}
