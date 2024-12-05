namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read matrix data
            int dimensions = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimensions,dimensions];

            //Populate the matrix
            for (int row = 0; row < dimensions; row++)
            {
                int[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = inputs[col];
                }
            }

            //Read the bombs and process exploding
            string[] bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string bomb in bombs)
            {
                int[] bombInfo = bomb.Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int value = matrix[bombInfo[0], bombInfo[1]];
                int bombRow = bombInfo[0];
                int bombCol = bombInfo[1];
                if (value <= 0)    //Skip if already dead
                    continue;


                for (int row = bombRow - 1; row <= bombRow + 1; row++)
                {
                    for (int col = bombCol - 1; col <= bombCol + 1; col++)
                    {
                        if (row >= 0 && row < dimensions && col >= 0 && col < dimensions)
                        {
                            if (matrix[row, col] > 0)
                            {
                                matrix[row, col] -= value;
                            }
                        }
                    }
                }
            }

            //Sum the alive cells in the matrix
            int sum = 0;
            int count = 0;
            for(int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        count++;
                    }
                }
            }

            //Print the results
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
