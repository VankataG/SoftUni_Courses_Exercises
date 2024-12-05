namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            //Read matrix
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = input[0];
            int colsCount = input[1];
            if (rowsCount < 3 && colsCount < 3) return;

            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
               
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            //Find the max sum of 3x3 square in matrix
            for (int row = 0; row < rowsCount - 2; row++)
            {
                for (int col = 0; col < colsCount - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                              matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                              matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestCol = col;
                        bestRow = row;
                    }
                }
            }
            //Print the output
            
                Console.WriteLine($"Sum = {maxSum}");
                for (int row = bestRow; row <= bestRow + 2; row++)
                {
                    for (int col = bestCol; col <= bestCol + 2; col++)
                    {
                        Console.Write(matrix[row,col] + " ");
                    }
                    Console.WriteLine();
                }
            
        }
    }
}
