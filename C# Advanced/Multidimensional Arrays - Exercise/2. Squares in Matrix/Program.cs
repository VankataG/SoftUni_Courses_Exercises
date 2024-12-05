namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int outputCount = 0;

            //Read matrix
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = input[0];
            int colsCount = input[1];
            
            char[,] matrix = new char[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                char[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            //Search for 2x2 squares in the matrix
            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && 
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                        outputCount++;
                }
            }

            //Print the output score
            Console.WriteLine(outputCount);
        }
    }
}
