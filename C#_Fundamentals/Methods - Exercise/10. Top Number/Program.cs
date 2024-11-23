namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 8; i <= n; i++)
            {
                bool rule1 = SumOfDigDivisibleBy8(i);
                bool rule2 = OneOddDig(i);
                if (rule1 && rule2)
                {
                    Console.WriteLine(i);
                }
            }
            
        }
        static bool SumOfDigDivisibleBy8(int n)
        {
            int sumOfDig = default;
            while (n != 0)
            {
                sumOfDig += n % 10;
                n /= 10;
            }
            if (sumOfDig % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            } 
                
        }
        static bool OneOddDig(int n)
        {
            while (n != 0)
            {
                if ((n % 10) % 2 != 0)
                {
                    return true;
                }
                else
                {
                    n /= 10;
                }
            }
            return false;
        }
        
    }
}
