namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read matrix
            int[] matrixInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int rowsCount = matrixInfo[0];
            int colsCount = matrixInfo[1];

            int[,] matrix = new int[rowsCount, colsCount];

            //Populate the matrix
            for (int row = 0; row < rowsCount; row++)
            {
                int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    {
                        matrix[row, col] = numbers[col];
                    }
                }
            }

            //Find the biggest sum and the square of it
            int biggestSum = int.MinValue;
            int sumRow = 0;
            int sumCol = 0;

            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        sumRow = row;
                        sumCol = col;
                    }
                }
            }

            //Output
            Console.WriteLine(matrix[sumRow, sumCol] + " " + matrix[sumRow, sumCol + 1]);
            Console.WriteLine(matrix[sumRow + 1, sumCol] + " " + matrix[sumRow + 1, sumCol + 1]);
            Console.WriteLine(biggestSum);
        }
    }
}
