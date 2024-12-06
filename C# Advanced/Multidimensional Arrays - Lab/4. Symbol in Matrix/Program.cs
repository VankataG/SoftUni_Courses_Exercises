namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read matrix
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string inputNumbers = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }


            //Find symbol
            bool isFound = false;
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                if (isFound) break;
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
