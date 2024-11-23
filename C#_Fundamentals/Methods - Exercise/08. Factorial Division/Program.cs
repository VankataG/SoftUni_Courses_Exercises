namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long a = int.Parse(Console.ReadLine());
            long b = int.Parse(Console.ReadLine());

            Console.WriteLine($"{Factoriel(a) / Factoriel(b):f2}");
            
        
        }
        static double Factoriel(long n)
        {
            double result = n;

            for (long i = n - 1; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
