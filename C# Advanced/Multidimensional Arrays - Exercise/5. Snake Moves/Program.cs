namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read the matrix from console
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            char[,] matrix = new char[rowsCount, colsCount];

            //Read the snake
            string snake = Console.ReadLine();
            int index = 0;
            //Fill the snake zig-zag movement into the matrix
            for (int row = 0; row < rowsCount; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        matrix[row, col] = snake[index];
                        index++;
                        if (index >= snake.Length)
                            index = 0;
                    }

                }
                else
                {
                    for (int col = colsCount - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[index];
                        index++;
                        if (index >= snake.Length)
                            index = 0;
                    }
                }
            }

            //Print the result
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
