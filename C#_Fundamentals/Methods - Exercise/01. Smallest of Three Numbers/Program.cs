namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static int SmallestNumber(int a, int b, int c)
        {
            if (a < b && a < c) return a;
            else if (b < a && b < c) return b;
            else if (c < a && c < b) return c;
            else return a;
        }
        static void Main(string[] args)
        { 
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestNumber(a, b, c));
        }
    }
}
