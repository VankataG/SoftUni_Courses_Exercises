namespace _3._Primary_Diagonal
{
    internal class Program
    {
        /*
            3
           11 2 4
           4 5 6
           10 8 -12
         */
        static void Main(string[] args)
        {
            //Read matrix
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }

            //Sum the primary diagonal of the matrix
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i,i];
            }
            Console.WriteLine(sum);
        }
    }
}
