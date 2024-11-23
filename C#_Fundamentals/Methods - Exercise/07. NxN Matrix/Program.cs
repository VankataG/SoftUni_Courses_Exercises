namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                SquareHeight(n);
            }
        }
        static void SquareHeight(int n)
        {
            for (int i= 0 ; i < n; i++)
            {
                Console.Write(n + " ");
            }
        }
    }
}
